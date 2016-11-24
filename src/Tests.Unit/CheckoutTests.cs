using NUnit.Framework;
using Checkout.Domain;
using Tests.Unit.InMemoryAdapters;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Unit
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase(0, "")]
        [TestCase(50, "A")]
        [TestCase(80, "AB")]
        [TestCase(115, "CDBA")]
        [TestCase(100, "AA")]
        [TestCase(175, "AAABB")]
        [TestCase(205, "AAABBB")]
        public void Should_have_expected_total_cost_for_given_product_items(int expected, string items)
        {
            var checkout = new Checkout.Domain.Checkout(
                new Test.Unit.InMemoryAdapters.ItemScanner(new InMemoryProductRepository()), 
                new PricingService(new InMemoryPricingRepository()));
            Assert.That(expected, Is.EqualTo(checkout.TotalCostOf(items)));
        }

        [Test]
        public void should_apply_a_discount_when_the_order_contains_enough_products()
        {
            var checkout = new Checkout.Domain.Checkout(
                new Test.Unit.InMemoryAdapters.ItemScanner(new InMemoryProductRepository()), 
                new PricingService(new InMemoryPricingRepository()));
            Assert.That(130, Is.EqualTo(checkout.TotalCostOf("AAA")));
        }
    }

    public class SpecialOfferTests
    {
        [Test]
        public void should_total_full_product_price_for_any_products_over_the_special_offer_threshold()
        {
            var specialOffer = new SpecialOffer("A", new Criteria(3, 130));
            var products = new List<Product>
            {
                new Product('A', 50),
                new Product('A', 50),
                new Product('A', 50),
                new Product('A', 50),
            }.GroupBy(p => p.Name).First();

            var discountedTotal = specialOffer.ApplyDiscountTo(products);
            Assert.That(180, Is.EqualTo(discountedTotal));
        }
    }

    


    
}
