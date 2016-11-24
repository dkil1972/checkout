using System.Collections.Generic;
using Checkout.Domain;
using NUnit.Framework;
using Tests.Unit.InMemoryAdapters;

namespace Tests.Unit
{
    public class PricingServiceTests
    {
        [Test]
        public void should_return_product_prices()
        {
            var pricingService = new PricingService(new InMemoryPricingRepository());
            var products = new List<Product>() { new Product('A', 50), new Product('B', 30) };

            var totalPrice = pricingService.TotalCostOf(products);

            Assert.That(totalPrice, Is.EqualTo(80));
        }
    }
}
