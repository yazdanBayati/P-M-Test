using PM.Shop.Core.Domains.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Shop.Core.Repositories
{
    public interface IProductRepository
    {
        public BaseProduct LoadProduct(string productId);
    }
}
