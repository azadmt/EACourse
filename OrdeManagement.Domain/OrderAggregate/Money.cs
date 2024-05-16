using Framework.Core.Domain;
using System.Security.AccessControl;

namespace OrderManagement.Domain.OrderAggregate
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }

        private Money()
        { }

        public Money(decimal value)
        {
            Value = value;
        }

        public static decimal operator *(Money left, Money right)
        {
            return left.Value * (right.Value);
        }

        public static decimal operator +(Money left, Money right)
        {
            return left.Value + (right.Value);
        }

        public static decimal operator -(Money left, Money right)
        {
            return left.Value - (right.Value);
        }

        public static implicit operator Money(decimal source)
        {
            return new Money(source);
        }

        public static explicit operator decimal(Money source)
        {
            return source.Value;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}