using PM.Shop.Core.Domains.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.Product
{
    public class DigitalProduct : BaseProduct
    {
        public DigitalProduct(string name, int articleNumber, List<decimal> prices, List<string> pictures, ProvideType provideBy):
            base(name, articleNumber, prices, pictures)
        {
            this.ProvideBy = provideBy;
        }
        public ProvideType ProvideBy { get; private set; }

        public void SendProduct()
        {
            if(this.ProvideBy == ProvideType.Email)
            {
                Console.WriteLine("Send Email");
            }
            else
            {

            }
        }
        public enum ProvideType
        {
            Email,
            Link
        }
        
    }
}
