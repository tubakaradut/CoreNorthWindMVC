using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);

            if (cartLine != null)
            {
                cartLine.Quantity++;
                return;
            }
            else
            {
                cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
            }
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId);
            if (cartLine.Quantity>1)
            {
                cartLine.Quantity--;
            }
            else
            {
                cart.CartLines.Remove(cartLine);
            }
           
        }
    }
}
