using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Identity.Data;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductController(IProductService productService, UserManager<ApplicationUser> userManager)
        {
            _productService = productService;
            _userManager = userManager;
        }


        public IActionResult Get()
        {
            using var context = new NorthwindContext();
            return Ok(context.Products.ToList());



        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            using var context = new NorthwindContext();
            var product = context.Products.Find(id);

            if (product == null)
            {
                

                return NotFound();
            }

            return Ok(product);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(CategoryProductViewModel model, int? id)
        {
            using var context = new NorthwindContext();
            var updatedProduct = context.Products.Find(id);
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

                    var product = context.Products.Find(id);
                    product.PictureUrl = resimAd;
                    product.ProductName = model.ProductName;
                    product.SupplierID = supplierid;
                    product.UnitPrice = model.UnitPrice;
                    product.CategoryID = model.CategoryID;
                    product.Description = model.Description;
                    product.QuantityPerUnit = model.QuantityPerUnit;



                    context.Products.Update(product);
                    context.SaveChanges();

                    return NoContent();


                }


            }
            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            using var context = new NorthwindContext();
            var deletedProduct = context.Products.Find(id);
            if (deletedProduct == null)
            {

                return NotFound();
            }

            context.Remove(deletedProduct);
            context.SaveChanges();
            return NoContent();
        }

        public  async Task<IActionResult> AddProduct(CategoryProductViewModel model)
        {
            using var context = new NorthwindContext();
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
                    context.Products.Add(product);
                    context.SaveChanges();
                    return Created("", product);
                    


                }

               
            }

            return NotFound();

        }
    }
   
   
}
    

       
   