using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.User.Customers.PurchaesHandlers
{
    public abstract class Handler : IHandler
    {
        private IHandler _nextHandler;

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;

            return handler;
        }

        public void Handle(ShoppingCart request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle(request);
            }
        }
    }
}
