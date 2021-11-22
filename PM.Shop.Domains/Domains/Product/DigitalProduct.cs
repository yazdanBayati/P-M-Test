using PM.Shop.Core.Domains.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.Product
{
    public class DigitalProduct : BaseProduct
    {
        public ProvideType Provide { get; set; }
        public void Init(string name, int articleNumber, List<decimal> prices, List<string> pictures, Seller seller, )
        {
            this.InitBase(name, articleNumber, prices, pictures, seller);
            this.
        }

        public enum ProvideType
        {
            ByEmail,
            ByLink
        }
        
    }
}
