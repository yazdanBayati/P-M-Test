using PM.Shop.Core.Domains.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Shop.Core.Domains.User
{
    public class Seller:User
    {
        public List<BaseProduct> Products { get; set; }
        public void CreateNormalProduct(string name,int articleNumber, List<decimal> prices, List<string> pictures, int stock)
        {
            var product = new NormalProduct();
            product.Init(name, articleNumber, prices, pictures, this, stock);
            this.Products.Add(product);
        }

        public void CreateDigitalProduct(string name, int articleNumber, List<decimal> prices, List<string> pictures, DigitalProduct.ProvideType provideType)
        {
            var product = new DigitalProduct();
            product.Init(name, articleNumber, prices, pictures, this, provideType);
            this.Products.Add(product);
        }

        public void AddNewPriceToProduct(string productName, decimal newPrice)
        {
            var product = this.Products.FirstOrDefault(x => x.Name == productName);
            product.AddPrice(newPrice);
        }
    }
}
