using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class ProductController : Controller
    {

        IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;


        }
        public IActionResult Index(int category)

        {
            //using var httpClient = new HttpClient();
            //var responspe = await httpClient.GetAsync("https://localhost:44362/api/product");
            //var data = await responspe.Content.ReadAsStringAsync();


           

            var model = new ProductListViewModel
            {
                Products = category > 0 ? _productService.GetByCategory(category) : _productService.GeTAll()
              };

            return View(model);


        }




    }
}
