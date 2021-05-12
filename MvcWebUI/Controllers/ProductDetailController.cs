using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Data;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductDetailController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return NotFound();

            }
            var products = _db.Products.Find(productId);

            ProductDetailViewModel model = new ProductDetailViewModel
            {

               ProductID = products.ProductID,
                ProductName =products.ProductName,
                Price = products.UnitPrice,
                Description=products.Description,
                Stock=products.UnitsInStock,
                quantity=products.QuantityPerUnit,
                PictureUrl=products.PictureUrl

                

            };

           
           
            return View(model);
        }
    }
}
