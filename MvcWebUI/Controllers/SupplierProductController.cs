using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class SupplierProductController : Controller
    {

        IProductService _productService;
        public SupplierProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int supplier)
        {
            var model = new ProductListViewModel
            {
                Products = supplier > 0 ? _productService.GetBySupplier(supplier) : _productService.GeTAll()
            };
            
            return View(model);
        }
    }
}
