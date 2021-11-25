using PM.Shop.Core.Domains.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Domains
{
    public class Category
    {
        public Category(string id, string parnetId, string name,  List<BaseProduct> proucts)
        {
            this.Id = id;
            this.ParentId = parnetId;
            this.Name = name;
            this.Products = proucts;
        }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
       
        public List<BaseProduct> Products { get; private set; }

        public void AssignProduct(BaseProduct product)
        {
            // validate
            this.Products.Add(product);
        }

        public void UnassignProduct(BaseProduct product)
        {
            // validate
            this.Products.Remove(product);
        }


    }
}
