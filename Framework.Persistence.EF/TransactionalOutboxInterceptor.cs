using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text;
using Microsoft.Data.SqlClient;
using Framework.Core.Domain;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
namespace Framework.Persistence.EF
{
    internal class TransactionalOutboxInterceptor : SaveChangesInterceptor
    {
        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            var dbcontext = (eventData.Context as ApplicationDbContext);
            var outbox = dbcontext
                   .ChangeTracker
                   .Entries<IAggregateRoot>()
                   .Select(entry => entry.Entity)
                       .SelectMany(entity =>
                       {
                           var domainEvents = entity.GetChanges();
                           return domainEvents;
                       })
                       .ToList();

            StringBuilder sb = new StringBuilder();
            sb.Append($"INSERT INTO outbox (EventId,EventType,EventBody) VALUES ");
            var paramItems = new List<SqlParameter>();
            for (int i = 0; i < outbox.Count; i++)
            {
                paramItems.Add(new SqlParameter($"@EventId{i}", outbox[i].Id.ToString()));
                paramItems.Add(new SqlParameter($"@EventType{i}", outbox[i].GetType().AssemblyQualifiedName));
                paramItems.Add(new SqlParameter($"@EventBody{i}", JsonConvert.SerializeObject(outbox[i])));

                sb.AppendLine($" (@EventId{i},@EventType{i},@EventBody{i}) ");
                if (i != outbox.Count - 1)
                    sb.Append($" , ");
            }

            dbcontext
                     .Database
                     .ExecuteSqlRaw(sb.ToString(), paramItems.ToArray());

            return base.SavedChanges(eventData, result);
        }
    }
}
