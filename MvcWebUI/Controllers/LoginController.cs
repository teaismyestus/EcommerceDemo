using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Areas.Identity.Data;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        public IActionResult Index()
        {
            return View(new UserSignInViewModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserSignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                //if(identityResult.IsLockedOut)
                //{
                //    ModelState.AddModelError("","5 kez yanlış denemede bulunduğunuz için hesabınız geçici süreliğine dondurulmuştur.");
                //    return RedirectToAction("Index", model);
                //}
                if(identityResult.Succeeded)
                {
                    
                    if(User.IsInRole("Admin"))
                    {

                        return RedirectToAction("Index", "Admin");
                    }
                    if(User.IsInRole("Supplier"))
                    {
                        return RedirectToAction("Index", "Supplier");
                    }
                    return RedirectToAction("Index", "Panel");

                }
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            }
            return View("Index", model);

        }


        public IActionResult SignUp()
        {

            return View(new UserSignUpViewModel());

        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Username,

                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }


            }
            return View(model);

        }

    }


}
