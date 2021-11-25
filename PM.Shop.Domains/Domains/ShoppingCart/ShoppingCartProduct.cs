

namespace PM.Shop.Core.Domains
{
   public  class ShoppingCartProduct
    {
        public ShoppingCartProduct(string name, decimal price, int quantity, ProductType type)
        {
            this.ProductName = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Type = type;
        }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public ProductType Type { get; private set; }

        public enum ProductType
        {
            Normal,
            Digital
        }
    }
}
