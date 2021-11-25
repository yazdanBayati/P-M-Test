using PM.Shop.Core.Domains.Product;
using PM.Shop.Core.Domains.User.Customers.PurchaesHandlers;
using PM.Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PM.Shop.Core.Domains.ShoppingCartProduct;

namespace PM.Shop.Core.Domains.User.Customers.PurchaesHandlers
{
    public class NoramlProductDeliveryHandler : Handler
    {
        public NoramlProductDeliveryHandler()
        {
        }
        public new void Handle(ShoppingCart shoppingCart)
        {
            Console.WriteLine("Deliver noraml products");
           
            base.Handle(shoppingCart);
        }
    }
}
