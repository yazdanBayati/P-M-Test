using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.User
{
    public class Customer:User
    {
        public Customer()
        {
            this.SubscribedProducts = new List<CustomerProduct>();
        }
        public string Address { get; set; }

        public List<CustomerProduct> SubscribedProducts { get; set; } 

        public void SubscribeToProduct(string productName)
        {
            this.SubscribedProducts.Add(new CustomerProduct()
            {
                ProductName = productName,
                SubscriberEmailAddress = this.EmailAddress
            });
        }
    }
}
