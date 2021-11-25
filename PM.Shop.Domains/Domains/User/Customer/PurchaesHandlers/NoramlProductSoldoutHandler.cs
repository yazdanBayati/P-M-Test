using PM.Shop.Core.Domains.Product;
using PM.Shop.Core.Domains.User.Customers.PurchaesHandlers;
using PM.Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PM.Shop.Core.Domains.ShoppingCartProduct;

namespace PM.Shop.Core.Domains.User.Customers.PurchaesHandlers
{
    public class NoramlProductSoldoutHandler : Handler
    {
        private readonly IProductRepository _productRepositroy;
        public NoramlProductSoldoutHandler(IProductRepository productRepository)
        {
            this._productRepositroy = productRepository;
        }
        public new void Handle(ShoppingCart shoppingCart)
        {
            var products = shoppingCart.Products.Where(x => x.Type == ProductType.Normal).ToList();
            foreach(var shoppingProduct in products)
            {
                NormalProduct product = this._productRepositroy.LoadProduct(shoppingProduct.ProductName) as NormalProduct;
                product.CheckState();
            }
           
            base.Handle(shoppingCart);
        }
    }
}
