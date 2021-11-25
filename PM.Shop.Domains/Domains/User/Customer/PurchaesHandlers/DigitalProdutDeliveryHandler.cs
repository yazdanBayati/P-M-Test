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
    public class DigitalProdutDeliveryHandler : Handler
    {
        private readonly IProductRepository _productRepositroy;
        public DigitalProdutDeliveryHandler(IProductRepository productRepositroy)
        {
            this._productRepositroy = productRepositroy;
        }
        public new void Handle(ShoppingCart shoppingCart)
        {
            var products = shoppingCart.Products.Where(x => x.Type == ProductType.Digital).ToList();
            foreach (var shoppingProduct in products)
            {
                DigitalProduct product = this._productRepositroy.LoadProduct(shoppingProduct.ProductName) as DigitalProduct;
                if(product.ProvideBy == DigitalProduct.ProvideType.Email)
                {
                    Console.WriteLine("send email");
                }
                else
                {
                    Console.WriteLine("provide Url");
                }
            }

            base.Handle(shoppingCart);
        }
    }
}
