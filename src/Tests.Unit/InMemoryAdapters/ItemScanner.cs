using System.Collections.Generic;
using System.Linq;
using Checkout.Domain;
using Checkout.Domain.Ports;

namespace Test.Unit.InMemoryAdapters
{
    public class ItemScanner : IScanItems
    {
        public ItemScanner(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IProductRepository ProductRepository { get; private set; }

        public IList<Product> Scan(string goods)
        {
            return ProductRepository.Get(goods.ToArray());
        }
    }
}
