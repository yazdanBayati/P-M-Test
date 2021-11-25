using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.User.Customers.PurchaesHandlers
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        void Handle(ShoppingCart request);
    }
}
