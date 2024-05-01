using Framework.Core.Domain;

namespace OrdeManagement.Domain
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

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}