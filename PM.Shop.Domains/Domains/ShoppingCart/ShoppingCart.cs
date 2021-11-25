

using PM.Shop.Core.Domains.Product;
using PM.Shop.Core.Domains.User;
using PM.Shop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using static PM.Shop.Core.Domains.ShoppingCartProduct;

namespace PM.Shop.Core.Domains
{
    public class ShoppingCart
    {
        public ShoppingCart(List<ShoppingCartProduct> products, decimal totalAmount)
        {
            this.Products = products;
            this.TotalAmount = totalAmount;
        }

       public List<ShoppingCartProduct> Products { get; private set; }


       public decimal TotalAmount { get; private set; }

        public void AddNoramlProduct(NormalProduct product, decimal price, int quantity)
        {
            product.CheckAvliable(quantity);
            product.DecreaseStock(quantity);
            this.AddProduct(product, price, quantity, ProductType.Normal);
        }

        public void RemoveNoramlProduct(NormalProduct product, decimal price, int quantity)
        {
            product.IncreaseStock(quantity);
            this.RemoveProduct(product, price, quantity);
        }

        public void AddDigitalProduct(DigitalProduct product, decimal price, int quantity)
        {
            this.AddProduct(product, price, quantity, ProductType.Digital);
        }

        public void RemoveDigitalProduct(DigitalProduct product, decimal price, int quantity)
        {
            this.RemoveProduct(product, price, quantity);
        }

        public void Empty()
        {
            this.Products = new List<ShoppingCartProduct>();
            this.TotalAmount = 0;
        }

        public bool CheckHasNoramlProduct()
        {
            return this.Products.Any(x => x.Type == ProductType.Normal);
        }

        public bool CheckHasDigitalProduct()
        {
            return this.Products.Any(x => x.Type == ProductType.Digital);
        }


        private void AddProduct(BaseProduct product,  decimal price, int quantity, ProductType productType)
        {
            product.CheckPrice(price);
            this.TotalAmount += price * quantity;
            this.AddToList(product.Name, price, quantity, productType);
        }

        private void RemoveProduct(BaseProduct product, decimal price, int quantity)
        {
            this.TotalAmount -= price * quantity;
            this.RemoveFormList(product.Name);
        }

        private void AddToList(string productName, decimal price, int quantity, ProductType productType)
        {
            var shoppingCartProduct = new ShoppingCartProduct(productName, price, quantity, productType);
            this.Products.Add(shoppingCartProduct);
        }

        private void RemoveFormList(string prodcutName)
        {
            var obj = this.Products.FirstOrDefault(x => x.ProductName == prodcutName);

            if(obj == null)
            {
                throw new NotFoundException("Product Not Found");
            }
            
            this.Products.Remove(obj);
        }

      
    }
}
