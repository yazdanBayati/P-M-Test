using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.ShoppingCart
{
   public  class ShoppingCartProduct
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public void Fill(string name, decimal price, int quantity)
        {
            this.ProductName = name;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
