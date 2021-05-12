using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWebUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
    
        
        [HttpGet]
        public IActionResult Get()
        {
            using var context = new NorthwindContext();
            return Ok(context.Categories.ToList());              
        }

        [HttpGet("{id}/products")]
        public IActionResult GetWithProductById(int id)
        {
            using var context = new NorthwindContext();
            var products =   context.Products.Where((p => p.CategoryID == id)).ToList();

            if (products == null)
            {

                return NotFound();
            }
            return Ok(products);

        }
    }
}
