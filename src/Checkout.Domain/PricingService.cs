using System.Collections.Generic;
using System.Linq;
using Checkout.Domain.Ports;

namespace Checkout.Domain
{
    public interface IPricingService
    {
        int TotalCostOf(IList<Product> products);
    }

    public class PricingService : IPricingService
    {
        public PricingService(IPricingRepository repository)
        {
            Repository = repository;
        }

        private IPricingRepository Repository { get; set; }

        public int TotalCostOf(IList<Product> products)
        {

            var SpecialOffers = Repository.Get(products
                .Select(p => p.Name).Distinct().ToList());

            var productGroups = products.GroupBy(p => p.Name).ToDictionary(gr => gr.Key);

            return SpecialOffers.Sum(so => so.ApplyDiscountTo(MatchingProducts(productGroups, so)));
        }

        private static IGrouping<string, Product> MatchingProducts(
            Dictionary<string, IGrouping<string, Product>> productGroups, SpecialOffer so)
        {
            return productGroups.First(pg => pg.Key == so.ProductName).Value;
        }
    }
}
