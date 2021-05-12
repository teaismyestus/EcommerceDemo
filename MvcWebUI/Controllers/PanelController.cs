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
    [Authorize]
    public class PanelController : Controller
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public PanelController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
          var user= await _userManager.FindByNameAsync(User.Identity.Name);
            
            return View(user);
        }
        public async Task<IActionResult> UpdateUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel
            {
                Email=user.Email,
                FirstName=user.FirstName,
                LastName=user.LastName,
                PhoneNumber=user.PhoneNumber,
                PictureUrl=user.PictureUrl

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserUpdateViewModel model)
        {
          
            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if(model.Picture!=null)
                {
                    var adres =  Directory.GetCurrentDirectory();
                    var uzanti = Path.GetExtension(model.Picture.FileName);
                    var resimAd = Guid.NewGuid() + uzanti;
                    var kaydedilecekYer = adres + "/wwwroot/img/" + resimAd;
                    
                    using var stream = new FileStream(kaydedilecekYer, FileMode.Create);
                    await model.Picture.CopyToAsync(stream);
                    user.PictureUrl = resimAd;

                }
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

              var result =  await _userManager.UpdateAsync(user);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Panel");
                }
                foreach(var item in result.Errors)
                {

                    ModelState.AddModelError("", item.Description);
                }

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Order()
        {
            var userid = Convert.ToInt32(_userManager.GetUserId(HttpContext.User));
           
          
            OrderDetailViewModel model = new OrderDetailViewModel
            {

                Orders = _db.OrderDetails.Where(I=>I.UserID==userid).ToList()

        };
                return View(model);
           
            
        }
    }
}
