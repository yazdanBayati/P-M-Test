using PM.Shop.Core.Domains.User.Customers.PurchaesHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.User.Customers.PurchaesHandlers
{
    public class PaymentHandler:Handler
    {
        public PaymentHandler()
        {
        }
        public new void Handle(ShoppingCart shoppingCart)
        {
            Console.WriteLine($"Payment is done !!!!");
            base.Handle(shoppingCart);
        }
    }
}
