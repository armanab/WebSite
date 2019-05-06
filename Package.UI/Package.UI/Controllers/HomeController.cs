using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Package.UI.Models;

namespace Package.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = " ";

            return View();
        }


        [HttpPost]
        public IActionResult TestApi(TestModel item)
        {
            //_context.TodoItems.Add(item);
            //_context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }





        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
