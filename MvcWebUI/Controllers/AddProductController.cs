using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MvcWebUI.Data;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    [Authorize(Roles = "Admin,Supplier")]
    public class AddProductController : Controller
    {

        //IProductService _productService;
        //ICategoryService _categoryservice;
        private readonly ApplicationDbContext _db;
        public AddProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        //    public AddProduct(IProductService productService, ICategoryService categoryService)
        //{
        //    _productService = productService;
        //    _categoryservice = categoryService;

        //}
        
        public IActionResult Index()
        {



            //var model = objProductList.Join(objCatList, p => p.CategoryID, c => c.CategoryID, (p, c) => new

            //{
            //    CategoryName = c.CategoryName,
            //    ProductName = p.ProductName

            //}
            //);
       
            IEnumerable<Product> objProductList = _db.Products;

            return View(objProductList);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
           
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        [Authorize]
        public IActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim>()
                {

                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "Bob@fmail.com"),
                new Claim("Grandma.Says", "Very nice boi"),

            };
            var licenceClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob K Foo"),
                new Claim("DrivingLicence","A+")

            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var LicenceIdentity = new ClaimsIdentity(licenceClaims, "Goverment");

            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity ,LicenceIdentity});


            HttpContext.SignInAsync(User);

            return RedirectToAction("index","product");
        }
      
    }
    
       
}
