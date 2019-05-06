using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Package.UI.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class DashboardController : Controller
    { 
        public DashboardController()
        {
            //
        }

        [Authorize(Roles = "Administrator")]
        [Route("{page:int?}")]
        public IActionResult Index()
        {
            return View();
        }

    }
}