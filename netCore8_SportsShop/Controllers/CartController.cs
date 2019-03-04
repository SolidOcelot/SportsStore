﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using netCore8_SportsShop.Models;
using netCore8_SportsShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using netCore8_SportsShop.Models.ViewModels;

namespace netCore8_SportsShop.Controllers
{
    public class CartController :Controller
    {
        private IProductRepository repository;
        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                //Cart cart = GetCart();
                //cart.AddItem(product, 1);
                //SaveCart(cart);
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                //Cart cart = GetCart();
                //cart.RemoveLine(product);
                //SaveCart(cart);
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult ToAdminController() => RedirectToAction("Index", "Admin");

        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //    return cart;
        //}

        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart", cart);
        //}
    }
}