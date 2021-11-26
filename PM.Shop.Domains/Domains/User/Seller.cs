using PM.Shop.Core.Domains.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Shop.Core.Domains.User
{
    public class Seller:User
    {
        public Seller(string userName, string emailAddress):base(userName,emailAddress)
        {
            this.Products = new List<BaseProduct>();
        }
        public List<BaseProduct> Products { get; set; }
        public void CreateNormalProduct(string name,int articleNumber, List<decimal> prices, List<string> pictures, int stock)
        {
            var product = new NormalProduct(name, articleNumber, prices, pictures, stock);
            this.Products.Add(product);
        }

        public void CreateDigitalProduct(string name, int articleNumber, List<decimal> prices, List<string> pictures, DigitalProduct.ProvideType provideType)
        {
            var product = new DigitalProduct(name, articleNumber, prices, pictures, provideType);
            this.Products.Add(product);
        }

        public void AddNewPriceToProduct(string productName, decimal newPrice)
        {
            var product = this.Products.FirstOrDefault(x => x.Name == productName);
            product.AddPrice(newPrice);
        }

        public void AddPictureToProduct(string productName, string url)
        {
            var product = this.Products.FirstOrDefault(x => x.Name == productName);
            product.AddPictures(url);
        }
    }
}
