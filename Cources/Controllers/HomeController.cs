using Cources.Data;
using Cources.Entities;
using Cources.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cources.Controllers
{
    public class HomeController :Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

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
        //public System.Web.Mvc.JsonResult getCategoryItems(string CourseName)
        //{
        //    Category categoryid = (Category)_context.Category.Where(a => a.Title == CourseName);

        //    IQueryable<CategoryItem> dbList = (IQueryable<CategoryItem>)_context.CategoryItem.Where(a => a.CategoryId == categoryid.Id);


        //    return Json(dbList.ToList(), JsonRequestBehavior.AllowGet);
        //}
    }
}
