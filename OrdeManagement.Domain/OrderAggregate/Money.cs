using Framework.Core.Domain;

namespace OrdeManagement.Domain
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get; private set; }

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