using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using test_select2.Models;

namespace test_select2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult GetData()
        {
            var data = new List<Select2Item>
               {
                     new Select2Item { id = 1, text = "Option 1" },
                     new Select2Item { id = 2, text = "Option 2" },
                     new Select2Item { id = 3, text = "Option 3" },
                     new Select2Item { id = 4, text = "Option 4" },
                     new Select2Item { id = 5, text = "Option 5" }

               };
            return Json(data); // Removed the incorrect second parameter 'Json.Alowget'  
        }
    }
}
