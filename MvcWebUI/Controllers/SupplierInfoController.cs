using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    
    public class SupplierInfoController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public SupplierInfoController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var suppliers = _db.SupplierInfo.ToList();
            return View();
        }


        public IActionResult AddInfo()
        {

            return View(new SupplierInfoModel());


        }


        [HttpPost]
        public async Task<IActionResult> AddInfo(SupplierInfoModel model)
        {
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
                    _db.SupplierInfo.Add(supplier);
                    _db.SaveChanges();
                    return RedirectToAction("Index");


                }
            }

            return View();
        }
    }
    }
