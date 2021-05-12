using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.ViewComponents
{
    public class PropertyListViewComponent:ViewComponent
    {

        private IPropertyService _propertyService;
        public PropertyListViewComponent(IPropertyService propertyService)
        {
            _propertyService = propertyService;

        }

        public ViewViewComponentResult Invoke ()
        {

            var model = new PropertyListViewModel
            {
                Properties = _propertyService.GetAll(),
                CurrentProperty = Convert.ToInt32(HttpContext.Request.Query["property"])


            };


            return View(model);


        }
    
       

    }
}
