using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class SupplierPanelController : Controller
    {
        [Authorize(Roles ="Supplier,Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
