using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CategoryController:Controller
    {

        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public IActionResult Index (int property)
        {
            var model = new CategoryListViewModel
            {

                Categories = property > 0 ? _categoryService.GetByProperty(property) : _categoryService.GetAll()


            };

            return View(model);




        }
        
    }
}
