﻿using System.Diagnostics;
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

        public JsonResult GetData(string q, int page = 1)
        {
            int pageSize = 10; // Number of items per page
            var data = new List<Select2Item>
               {
                     new Select2Item { id = 1, text = "Option 1" },
                     new Select2Item { id = 2, text = "Option 2" },
                     new Select2Item { id = 3, text = "Option 3" },
                     new Select2Item { id = 4, text = "Option 4" },
                     new Select2Item { id = 5, text = "Option 5" },
                        new Select2Item { id = 6, text = "Option 6" },
                        new Select2Item { id = 7, text = "Option 7" },
                        new Select2Item { id = 8, text = "Option 8" },
                        new Select2Item { id = 9, text = "Option 9" },
                        new Select2Item { id = 10, text = "Option 10" },
                        new Select2Item { id = 11, text = "Option 11" },
                        new Select2Item { id = 12, text = "Option 12" },
                        new Select2Item { id = 13, text = "kin2" },

               };
            var query = data.Where(data => data.text.ToLower().Contains(q.ToLower()));
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();



            return Json(new
            {
                items = paginatedData,
                total_count = totalCount
            });
        }


        public JsonResult GetData2(string q = "", int page = 1)
        {
            int pageSize = 10; // Number of items per page
            var data = new List<Select2Item>
               {

                            new Select2Item { id = 13, text = "kin2fewewewewewewfewfewfewfwef"},
                            new Select2Item { id = 14, text = "kin3" },
                            new Select2Item { id = 15, text = "kin4" },
                            new Select2Item { id = 16, text = "kin5" },
                            new Select2Item { id = 17, text = "kin6" },
                            new Select2Item { id = 18, text = "kin7" },
                            new Select2Item { id = 19, text = "kin8" },
                            new Select2Item { id = 20, text = "kin9" },
                            new Select2Item { id = 21, text = "kin10" },
                            new Select2Item { id = 22, text = "kin11" },
                            new Select2Item { id = 23, text = "kin12" },
                            new Select2Item { id = 24, text = "kin13" },
                            new Select2Item { id = 25, text = "kin14" },
                            new Select2Item { id = 26, text = "kin15" },
                            new Select2Item { id = 27, text = "kin16" },
                            new Select2Item { id = 28, text = "kin17" },



               };

            var query = q == "" ? data : data.Where(data => data.text.ToLower().Contains(q.ToLower()));
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var paginatedData = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            List<Select2Item> data2 = new List<Select2Item>();
            if (page == 1) data2.Add(new Select2Item { id = -1, text = "-1", disabled = true });
            data2.AddRange(paginatedData);



            return Json(new
            {
                items = data2,
                total_count = totalCount,
                header_code = "Code",
                header_name = "Name Kien",
            });
        }

        [HttpPost]

        public JsonResult GetInfor()
        {
            return Json(new
            {
                id = 1,
                name = "kin",
                age = 20,
                address = "Hà Nội",
                phone = "0123456789",
            });

        }

        public JsonResult GetDataTable()
        {
          List<User> users =new List<User>();
            for (int i = 0; i < 50; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = "User " + i,
                    Email = "user" + i + "@example.com",
                    Phone = "123456789" + i,
                    Address = "Address " + i,
                    City = "City " + i,
                    State = "State " + i,
                    ZipCode = "ZipCode " + i,
                    CreatedAt = DateTime.Now.AddDays(-i),
                    UpdatedAt = DateTime.Now.AddDays(-i)
                });
            }
            return Json(new { data = users });  
        }
    }
}
