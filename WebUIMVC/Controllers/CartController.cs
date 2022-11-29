using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUIMVC.Helpers;
using WebUIMVC.Models;

namespace WebUIMVC.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            Product product = _productService.GetById(productId);

            //product.UnitsInStock--;

            Cart cart = _cartSessionHelper.GetCart("cart");

            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + "sepete eklendi!");

            return RedirectToAction("index", "Product");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);

            Cart cart = _cartSessionHelper.GetCart("cart");

            _cartService.RemoveFromCart(cart, productId);
            _cartSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + "sepetten silindi!");

            return RedirectToAction("index", "Product");
        }
        public IActionResult Index()
        {
            var model = new CartListVM
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Complete()
        {
            var model = new ShippingDetailVM
            {
                ShippingDetail = new ShippingDetail()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            TempData.Add("message", "Siparişiniz Başarılı ile tamamlandı");
            _cartSessionHelper.Clear();

            return RedirectToAction("Index");

        }
    }
}
