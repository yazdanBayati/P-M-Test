
using PM.Shop.Core.Domains.Product;
using PM.Shop.Core.Domains.User.Customers.PurchaesHandlers;
using PM.Shop.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PM.Shop.Core.Domains.User
{
    public class Customer:User
    {
        private readonly IProductRepository _productRepositroy;
       
        public Customer(IProductRepository productRepository, string userName, string emailAddress, ShoppingCart shoppingCart, string address, List<string> subscribedProducts)
            :base(userName, emailAddress)
        {
            // validate
            this.ShoppingCart = shoppingCart;
            this.SubscribedProducts = subscribedProducts;
            this.Address = address;
            this._productRepositroy = productRepository;
        }
        public string Address { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public List<string> SubscribedProducts { get; set; } 

        public void SubscribeToProduct(string productName)
        {
            this.SubscribedProducts.Add(productName);
        }

        public void Purchages()
        {
            Handler handler = BuildPurchaesChain();
            handler.Handle(this.ShoppingCart);

        }

        public List<ShoppingCartProduct> GetAddedProducts()
        {
            return this.ShoppingCart.Products;
        }

        public void AddNormalProductToShoppingCart(NormalProduct product, decimal price, int quantity)
        {
            this.ShoppingCart.AddNoramlProduct(product, price, quantity);
        }

        public void AddDigitalProductToShoppingCart(DigitalProduct product, decimal price, int quantity)
        {
            this.ShoppingCart.AddDigitalProduct(product, price, quantity);
        }

        public void RemoveNormalProductFromShoppingCart(NormalProduct product, decimal price, int quantity)
        {
            this.ShoppingCart.RemoveNoramlProduct(product, price, quantity);
        }

        public void RemoveDigitalProductFromShoppingCart(DigitalProduct product, decimal price, int quantity)
        {
            this.ShoppingCart.RemoveDigitalProduct(product, price, quantity);
        }

        private Handler BuildPurchaesChain()
        {
            var handlerList = new List<Handler>();
            handlerList.Add(new PaymentHandler());

            if (this.ShoppingCart.CheckHasNoramlProduct())
            {
                AddNormalProductHandlers(handlerList);
            }
            if (this.ShoppingCart.CheckHasDigitalProduct())
            {
                AddDigitalProductHandlers(handlerList);
            }

            handlerList.Add(new CleanUpHandler());

            ChainHandlers(handlerList);

            return handlerList.First();
        }

        private void ChainHandlers(List<Handler> handlerList)
        {
            for (var i = 0; i < handlerList.Count; i++)
            {
                var currentHandler = handlerList[i];
                if (i < handlerList.Count - 1)
                {
                    currentHandler.SetNext(handlerList[i + 1]);
                }
                else
                {
                    currentHandler.SetNext(null);
                }
            }
        }

        private void AddDigitalProductHandlers(List<Handler> handlerList)
        {
            handlerList.Add(new DigitalProdutDeliveryHandler(this._productRepositroy));
        }

        private void AddNormalProductHandlers(List<Handler> handlerList)
        {
            var soldOutHandler = new NoramlProductSoldoutHandler(this._productRepositroy);
            var noramlProductHandler = new NoramlProductDeliveryHandler();
            handlerList.Add(soldOutHandler);
            handlerList.Add(noramlProductHandler);
        }

      
    }
}
