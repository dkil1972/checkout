using System.Linq;

namespace Checkout.Domain
{
    public class SpecialOffer
    {
        public SpecialOffer(string productName, Criteria discountCriteria)
        {
            ProductName = productName;
            DiscountCriteria = discountCriteria;
        }

        private Criteria DiscountCriteria { get; set; }

        public int ApplyDiscountTo(IGrouping<string, Product> pg)
        {
            return DiscountCriteria.ApplyDiscountTo(pg);
        }

        public string ProductName { get; private set; }

        public static SpecialOffer Empty(string productName)
        {
            return new SpecialOffer(productName, new Criteria(0, 0));
        }
    }
}
