namespace Checkout.Domain
{
    public class Product
    {
        public Product(char name, int price)
        {
            Name = name.ToString();
            Price = price;
        }
        public int Price { get; private set; }
        public string Name { get; private set; }
    }
}
