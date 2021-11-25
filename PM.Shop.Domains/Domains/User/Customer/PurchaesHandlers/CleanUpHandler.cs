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
    public class CleanUpHandler : Handler
    {
        public new void Handle(ShoppingCart shoppingCart)
        {
            shoppingCart.Empty();
           
            base.Handle(shoppingCart);
        }
    }
}
