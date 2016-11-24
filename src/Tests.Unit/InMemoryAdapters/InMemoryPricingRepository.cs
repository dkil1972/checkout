using System.Collections.Generic;
using Checkout.Domain.Ports;
using Checkout.Domain;
using System.Linq;
using System;

namespace Tests.Unit.InMemoryAdapters
{
    public class InMemoryProductRepository : IProductRepository
    {
        private IDictionary<char, int> productBasePriceMap = new Dictionary<char, int>
        {
            {'A', 50},
            {'B', 30},
            {'C', 20},
            {'D', 15}
        };
        public IList<Product> Get(char[] goods)
        {
            return goods.Select(c => new Product(c, productBasePriceMap[c])).ToList();
        }
    }
    public class InMemoryPricingRepository : IPricingRepository
    {
        private IDictionary<string, int> productPricingMap = new Dictionary<string, int>
        {
            {"A", 50 },
            {"B", 30 },
            {"C", 20 },
            {"D", 15 }
        };

        private IDictionary<string, SpecialOffer> productOffersMap = new Dictionary<string, SpecialOffer>()
        {
            {"A", new SpecialOffer("A", new Criteria(3, 130)) },
            {"B", new SpecialOffer("B", new Criteria(2, 45)) },
        };

        public IList<SpecialOffer> Get(IList<string> productNames)
        {
            return productNames.Select(pn =>
            {
                if (productOffersMap.ContainsKey(pn))
                    return productOffersMap[pn];

                return SpecialOffer.Empty(pn);
            }).ToList();
        }

    }

   
}
