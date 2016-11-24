using System.Linq;
using NUnit.Framework;
using Test.Unit.InMemoryAdapters;

namespace Tests.Unit
{
    public class ItemScannerTests
    {
        [Test]
        public void should_scan_one_product_when_input_contains_one_item()
        {
            var scanner = new ItemScanner(new InMemoryAdapters.InMemoryProductRepository());
            var products = scanner.Scan("A");
            Assert.That(products.Count, Is.EqualTo(1));
            Assert.That(products.First().Name, Is.EqualTo("A"));
        }

        [Test]
        public void should_scan_all_goods_at_checkout()
        {
            var scanner = new ItemScanner(new InMemoryAdapters.InMemoryProductRepository());
            var products = scanner.Scan("ABDC");
            Assert.That(products.Count, Is.EqualTo(4));
            Assert.That(products.ElementAt(1).Name, Is.EqualTo("B"));
            Assert.That(products.ElementAt(2).Name, Is.EqualTo("D"));
        }
    }
}
