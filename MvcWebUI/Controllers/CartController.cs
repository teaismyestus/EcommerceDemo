using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Identity.Data;
using MvcWebUI.Data;
using MvcWebUI.Helpers;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class CartController:Controller
    {
       private ICartService _cartservice;
       private ICartSessionHelper _cartSessionHelper;
       private IProductService _productService;
       private readonly ApplicationDbContext _db;
       private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _cartservice = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
            _userManager = userManager;
            _db = db;

        }

        public IActionResult AddToCart(int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");

            _cartservice.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart",cart);
            TempData.Add("message", product.ProductName + "  "+ "Sepete Eklendi.");

            return RedirectToAction("Index", "Product");

        }
        public IActionResult Index()
        {

            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("cart")

        };
            return View(model);

        }
        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);
            var cart = _cartSessionHelper.GetCart("cart");
            _cartservice.RemoveFromCart(cart,productId);
            _cartSessionHelper.SetCart("cart",cart);
            TempData.Add("message", product.ProductName +" " + "Sepetten Silindi.");

            return RedirectToAction("Index", "Cart");
        }
        [Authorize]
        
        public IActionResult Complete(int productID)
        {
            var model = new ShippingDetailsViewModel
            {

                ShippingDetail = new ShippingDetail()

            };
           
            return View(model);

        }
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if(!ModelState.IsValid)
            {


                return View();

            }
            var Cart = _cartSessionHelper.GetCart("cart");
            var userid = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            foreach (var cartitem in Cart.CartLines)
            {
                var OrderDetail = new OrderDetail()
                {                  
                    ProductID = cartitem.Product.ProductID,
                    UserID = userid,
                    SupplierID=cartitem.Product.SupplierID,
                    quantity = cartitem.Quantity,
                    Price = cartitem.Product.UnitPrice


                };
                _db.OrderDetails.Add(OrderDetail);
                _db.SaveChanges();

                
            }

            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");

           

        }


    }
}
