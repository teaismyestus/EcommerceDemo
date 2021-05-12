using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
       private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult AddRole()
        {

            return View(new RoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {

            if(ModelState.IsValid)
            {
                AppRole role = new AppRole
                {

                    Name = model.Name
                };

            var rolResult =   await _roleManager.CreateAsync(role);

                if(rolResult.Succeeded)
                {

                    return RedirectToAction("Index");

                }
                foreach(var item in rolResult.Errors)
                {

                    ModelState.AddModelError("", item.Description);
                }
                
                

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
         var role = _roleManager.Roles.FirstOrDefault(I => I.Id == id);

            if(role!=null)
            {

                RoleUpdateViewModel model = new RoleUpdateViewModel
                {

                    Id = role.Id,
                    Name = role.Name
                };
                return View(model);



            }
            else
            {
                return RedirectToAction("Index");


            }
          

        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {

            var tobeUpdatedRole = _roleManager.Roles.Where(I => I.Id == model.Id).FirstOrDefault();

            tobeUpdatedRole.Name = model.Name;
            var identityResutlt =  await _roleManager.UpdateAsync(tobeUpdatedRole);
            if(identityResutlt.Succeeded)
            {

                return RedirectToAction("Index");
            }

            foreach(var error in identityResutlt.Errors)
            {
                ModelState.AddModelError("", error.Description);

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var toBeDeletedRole = _roleManager.Roles.FirstOrDefault(I => I.Id == id);
        var identityresult =  await  _roleManager.DeleteAsync(toBeDeletedRole);

            if(identityresult.Succeeded)
            {

                return RedirectToAction("Index");
            }
            TempData["Errors"] = identityresult.Errors;
            return RedirectToAction("Index");
        }

        public IActionResult UserList()
        {


            return View(_userManager.Users.ToList());
        }

        public async Task<IActionResult> AssignRole(int id)
        {

            var user=   _userManager.Users.FirstOrDefault(I => I.Id == id);
            TempData["UserId"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();
            
            foreach(var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.Name = item.Name;
                model.Exist = userRoles.Contains(item.Name);
                models.Add(model);

            }
            return View(models);
            
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> models)
        {
            var userId = (int)TempData["UserId"];

            var user = _userManager.Users.FirstOrDefault(I => I.Id == userId);
            foreach(var item in models)
            {
                if(item.Exist)
                {

                  await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);

                }

            }
            return RedirectToAction("UserList");


        }
    }
}
