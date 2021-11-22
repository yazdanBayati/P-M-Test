using PM.Shop.Core.Domains.User;
using PM.Shop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.Product
{
    public class NormalProduct : BaseProduct
    {
        public void Init(string name, int articleNumber, List<decimal> prices, List<string> pictures, Seller seller, int stock)
        {
            this.InitBase(name, articleNumber, prices, pictures, seller);
            this.Stock = stock;
            this.State = StateEnum.Availabe;
        }

        public int Stock { get; set; }

        public StateEnum State { get; set; }

        public void CheckAvliable(int quantity)
        {
            if(quantity > this.Stock)
            {
                throw new InvalidItemException("there is not enough Stock");
            }
        }

        public void DeductStock(int quantity)
        {
            this.Stock -= quantity;
            if(this.Stock == 0)
            {
                this.State = StateEnum.TemporarySoldout;
            }
        }

        public void BuyBack(int quantity)
        {
            this.Stock += quantity;
            if (this.State == StateEnum.TemporarySoldout)
            {
                this.State = StateEnum.Availabe;
            }
        }

        public enum StateEnum
        {
            Availabe,
            TemporarySoldout,
            Soldout
        }
    }

}
