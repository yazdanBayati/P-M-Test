using PM.Shop.Core.Domains.User;
using PM.Shop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains.Product
{
    public class NormalProduct : BaseProduct
    {
        public NormalProduct(string name, int articleNumber, List<decimal> prices, List<string> pictures, int stock):
            base(name, articleNumber, prices, pictures)
        {
            this.Stock = stock;
        }

        public int Stock { get; private set; }

        public StateEnum State { get; private set; }


        public void CheckAvliable(int quantity)
        {
            if(quantity > this.Stock)
            {
                throw new InvalidItemException("there is not enough Stock");
            }
        }

        public void DecreaseStock(int quantity)
        {
            this.Stock -= quantity;
            if(this.Stock == 0)
            {
                this.State = StateEnum.TemporarySoldout;
            }
        }

        public void CheckState()
        {
            if(this.State == StateEnum.TemporarySoldout)
            {
                this.State = StateEnum.Soldout;
                this.SendEmailToSeller();
            }
        }

        private void SendEmailToSeller()
        {
            Console.WriteLine("send email to seller");
        }
            

        public void IncreaseStock(int quantity)
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
