using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OCMS03.Controllers
{
    public class NavBarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
