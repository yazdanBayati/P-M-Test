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
        public BaseProduct(string name, int articleNumber, List<decimal> prices, List<string> pictures)
        {
            this.Validate(pictures);
            this.Name = name;
            this.ArticleNumber = articleNumber;
            this.Prices = prices;
            this.Pictures = pictures;
            this.Subscibers = new List<string>();
        }

        public BaseProduct(string name, int articleNumber)
        {
            this.Name = name;
            this.ArticleNumber = articleNumber;
            this.Subscibers = new List<string>();
            this.Pictures= new List<string>();
            this.Prices = new List<decimal>();
        }

        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public List<decimal> Prices { get; set; }
        public List<string> Pictures { get; set; }

        public List<string> Subscibers { get; set; }

        private void Validate(List<string> pictures)
        {
            if (pictures.Count > 5)
            {
                throw new InvalidItemException("each product can have max 5 pic");
            }
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
                Console.WriteLine($"Send Email to {subscriber}");
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
