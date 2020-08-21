using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartBreadcrumbs.Attributes;

namespace OCMS03.Controllers
{
    public class SidebarController : Controller
    {
        [DefaultBreadcrumb("My home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
