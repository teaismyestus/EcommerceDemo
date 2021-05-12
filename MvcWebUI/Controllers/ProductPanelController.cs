using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcWebUI.Areas.Identity.Data;
using MvcWebUI.Data;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
   
    public class ProductPanelController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductPanelController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var products = _db.Products.ToList();

            return View(products);
        }

        public IActionResult CategoryIndex()
        {

            var categories = _db.Categories.ToList();
            return View(categories);

        }

        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_db.Categories, "CategoryID", "CategoryName");
            return View(new CategoryProductViewModel());


        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CategoryProductViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.Picture != null)
                {
                    var adres = Directory.GetCurrentDirectory();
                    var uzanti = Path.GetExtension(model.Picture.FileName);
                    var resimAd = Guid.NewGuid() + uzanti;
                    var kaydedilecekYer = adres + "/wwwroot/img/" + resimAd;

                    using var stream = new FileStream(kaydedilecekYer, FileMode.Create);
                    await model.Picture.CopyToAsync(stream);
                    var supplierid = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
                    Product product = new Product
                    {
                        PictureUrl = resimAd,
                        ProductName = model.ProductName,
                        SupplierID = supplierid,
                        UnitPrice = model.UnitPrice,
                        CategoryID = model.CategoryID,
                        Description = model.Description,
                        QuantityPerUnit = model.QuantityPerUnit


                    };
                    _db.Products.Add(product);
                    _db.SaveChanges();

                    return RedirectToAction("Index");


                }

               
            }

            return View(model);
        }

        public IActionResult ProductList()
        {
            var supplierid = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
            IEnumerable<Product> objList = _db.Products.Where(c => c.SupplierID == supplierid).ToList();

            return View(objList);

        }

        public IActionResult Update(int? id)
        {
            if(id==null|| id==0)
            {
                return NotFound();

            }
            var product = _db.Products.Find(id);
            CategoryProductViewModel obj = new CategoryProductViewModel
            {

                PictureUrl = product.PictureUrl,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                UnitPrice = product.UnitPrice,
                CategoryID = product.CategoryID,
                Description = product.Description,
                QuantityPerUnit = product.QuantityPerUnit


            };

           
            if(obj==null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(_db.Categories, "CategoryID", "CategoryName");
            return View(obj);


        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryProductViewModel model ,int? id)
        {
            if (ModelState.IsValid)
            {
                if (model.Picture != null)
                {
                    var adres = Directory.GetCurrentDirectory();
                    var uzanti = Path.GetExtension(model.Picture.FileName);
                    var resimAd = Guid.NewGuid() + uzanti;
                    var kaydedilecekYer = adres + "/wwwroot/img/" + resimAd;

                    using var stream = new FileStream(kaydedilecekYer, FileMode.Create);
                    await model.Picture.CopyToAsync(stream);
                    var supplierid = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

                    var product = _db.Products.Find(id);
                    product.PictureUrl = resimAd;
                        product.ProductName = model.ProductName;
                        product.SupplierID = supplierid;
                        product.UnitPrice = model.UnitPrice;
                        product.CategoryID = model.CategoryID;
                        product.Description = model.Description;
                        product.QuantityPerUnit = model.QuantityPerUnit;


                    
                    _db.Products.Update(product);
                    _db.SaveChanges();

                    return RedirectToAction("Index");


                }


            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var silinecek = _db.Products.Find(id);
            _db.Remove(silinecek);
            _db.SaveChanges();


            return RedirectToAction("Index");

        }

    }
}
