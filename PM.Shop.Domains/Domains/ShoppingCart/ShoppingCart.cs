

using PM.Shop.Core.Domains.Product;
using PM.Shop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PM.Shop.Core.Domains.ShoppingCart
{
    public class ShoppingCart
    {
       public string UserName { get; set; }

       public List<ShoppingCartProduct> Products { get; set; }

       public decimal TotalAmount { get; set; }

       private void AddProduct(BaseProduct product,  decimal price, int quantity)
        {
            product.CheckPrice(price);
            this.TotalAmount += price * quantity;
            this.AddToList(product.Name, price, quantity);
        }

        private void RemoveProduct(BaseProduct product, decimal price, int quantity)
        {
            this.TotalAmount -= price * quantity;
            this.RemoveFormList(product.Name);
        }

        private void AddToList(string productName, decimal price, int quantity)
        {
            var shoppingCartProduct = new ShoppingCartProduct();
            shoppingCartProduct.Fill(productName, price, quantity);
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

        public void AddNoramlProduct(NormalProduct product, decimal price , int quantity)
        {
            product.CheckAvliable(quantity);
            product.DeductStock(quantity);
            this.AddProduct(product, price, quantity);
        }

        public void RemoveNoramlProduct(NormalProduct product, decimal price, int quantity)
        {
            product.BuyBack(quantity);
            this.RemoveProduct(product, price, quantity);
        }

        public void AddDigitalProduct(DigitalProduct product, decimal price, int quantity)
        {
            this.AddProduct(product, price, quantity);
        }

        public void RemoveDigitalProduct(DigitalProduct product, decimal price, int quantity)
        {
            this.RemoveProduct(product, price, quantity);
        }
    }
}
