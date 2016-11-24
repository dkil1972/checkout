using System.Linq;

namespace Checkout.Domain
{
    public class Criteria
    {
        public Criteria(int threshold, int discountedTotal)
        {
            Threshold = threshold;
            DiscountedTotal = discountedTotal;
        }

        private int Threshold { get; set; }
        public int DiscountedTotal { get; private set; }

        public bool MetBy(IGrouping<string, Product> products)
        {
            return products.Count() >= Threshold;
        }

        public int ApplyDiscountTo(IGrouping<string, Product> products)
        {
            var productCount = products.Count();
            var numberTimesToApplyDiscount = Threshold == 0 ? Threshold : productCount / Threshold;
            var numberOfUnDiscountedProducts = Threshold == 0 ? productCount : productCount % Threshold;

            return (numberTimesToApplyDiscount * DiscountedTotal) + 
                numberOfUnDiscountedProducts * products.First().Price;
        }
    }
}
