using PM.Shop.Core.Domains.User;
using PM.Shop.Core.Exceptions;
using PM.Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Shop.Core.Domains.Product
{
    public abstract class BaseProduct
    {
        public BaseProduct()
        {
            this.Prices = new List<decimal>();
            this.Pictures = new List<string>();
            this.Seller = new Seller();
            this.Subscibers = new List<CustomerProduct>();
        }

       
        
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public List<decimal> Prices { get; set; }
        public List<string> Pictures { get; set; }

        public List<CustomerProduct> Subscibers { get; set; }

        public Seller Seller { get; set; }

        protected void InitBase(string name, int articleNumber, List<decimal> prices, List<string> pictures, Seller seller)
        {
            if (pictures.Count > 5)
            {
                throw new InvalidItemException("each product can have max 5 pic");
            }
            this.Name = name;
            this.ArticleNumber = articleNumber;
            this.Prices = prices;
            this.Seller = seller;
            this.Pictures = pictures;
        }

        public void CheckPrice(decimal price)
        {
            var isPriceExist = this.Prices.Any(x => x == price);
            if (!isPriceExist)
            {
                throw new InvalidItemException("Price is not valid");
            }
        }

        private void SendEmailToSubscribers()
        {
            foreach (var subscriber in this.Subscibers)
            {
                Console.WriteLine($"Send Email to {subscriber.SubscriberEmailAddress}");
            }
        }


        public void AddPrice(decimal newPrice) 
        {
            this.Prices.Add(newPrice);
            this.SendEmailToSubscribers();
            
        }
        public void AddPictures(string url)
        {
            if (this.Pictures.Count < 5)
            {
                this.Pictures.Add(url);
            }
            else
            {
                throw new InvalidItemException("each product can have max 5 pic");
            }
        }

       
    }
}
