using System;
using System.Collections.Generic;
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
}
