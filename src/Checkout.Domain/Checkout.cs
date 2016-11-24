using Checkout.Domain.Ports;

namespace Checkout.Domain
{
    public class Checkout
    {
        public Checkout(IScanItems itemScanner, IPricingService pricingService)
        {
            ItemScanner = itemScanner;
            PricingService = pricingService;
        }

        private IScanItems ItemScanner { get; }
        private IPricingService PricingService { get; }
        public int TotalCostOf(string goods)
        {
            var products = ItemScanner.Scan(goods);
            return PricingService.TotalCostOf(products);
        }
    }
}
