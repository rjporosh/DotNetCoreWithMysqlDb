using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCoreWithMySql.Models;
using DotNetCoreWithMySql.Models.Students;
using DotNetCoreWithMySql.Models.DatabaseContext;

namespace DotNetCoreWithMySql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyDbContext context;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Student()
        {
            IEnumerable<Student> model = context.Set<Student>().ToList().Select(s => new Student
            {
                Id = s.Id,
                Name = $"{s.Name} ",
                Age = s.Age,
                Gender = s.Gender,
                Phone = s.Phone,
                Address = s.Address,
                Permanent_Address = s.Permanent_Address,
                E_Mail = s.E_Mail
            });
            return View("Student", model);
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
    }
}
