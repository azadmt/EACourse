using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Domain
{
    public class Entity<TKey>
    {


        public TKey Id { get; protected set; }


        public override bool Equals(object obj)
        {
            var other = (Entity<TKey>)obj;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
       // [TimeStamp]
        public  byte[] Version { get; set; }
        List<IDomainEvent> _changes = new();

        protected void AddChanges(IDomainEvent @event)
        {
            _changes.Add(@event);
        }

        public ReadOnlyCollection<IDomainEvent> GetChanges()
        {
            return _changes.AsReadOnly();
        }
    }


    public interface IAggregateRoot
    {
        ReadOnlyCollection<IDomainEvent> GetChanges();
    }
    public interface IDomainEvent
    {
        Guid Id { get; }
    }
}
