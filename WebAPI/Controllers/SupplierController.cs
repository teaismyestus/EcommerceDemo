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
    public class SupplierController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public SupplierController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]

        public IActionResult Get()
        {

            using var context = new NorthwindContext();
            return Ok(context.Suppliers.ToList());

        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            using var context = new NorthwindContext();
            var supplier = context.Suppliers.Find(id);
            if(supplier == null)
            {

                return NotFound();

            }
            return Ok(supplier);


        }

        [HttpGet]
        public IActionResult AddInfo()
        {

            return Ok(new SupplierInfoModel());

        }

        [HttpPost]
        public async Task <IActionResult> AddInfo(SupplierInfoModel model)
        {
            using var context = new NorthwindContext();

            if (ModelState.IsValid)
            {
                if (model.Picture != null)
                {


                    var adres = Directory.GetCurrentDirectory();
                    var uzanti = Path.GetExtension(model.Picture.FileName);
                    var resimAd = Guid.NewGuid() + uzanti;
                    var kaydedilecekYer = adres + "/wwwroot/img/firmaimg" + resimAd;

                    using var stream = new FileStream(kaydedilecekYer, FileMode.Create);
                    await model.Picture.CopyToAsync(stream);



                    var supplierid = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));

                    SupplierInfo supplier = new SupplierInfo()
                    {

                        CompanyName = model.CompanyName,

                        ContactName = model.ContactName,
                        ContactTitle = model.ContactTitle,
                        Phone = model.Phone,
                        LogoUrl = resimAd,
                        Adress = model.Adress,
                        TaxNumber = model.TaxNumber,
                        TaxOffice = model.TaxOffice

                    };
                    context.SupplierInfos.Add(supplier);
                    context.SaveChanges();
                    return Created("", supplier);


                }
            }

            return NotFound();
        }

    }


    }
}
