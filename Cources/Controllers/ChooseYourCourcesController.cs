using Cources.Areas.Admin.Models;
using Cources.Data;
using Cources.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cources.Controllers
{
    public class ChooseYourCourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChooseYourCourcesController(ApplicationDbContext context)
        {
      
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult save(string UserName,string CourseName)
        {
            Category dbCategory = (Category)_context.Category.Where(a => a.Title == CourseName);
            var dbUser = _context.Users.Where(a => a.UserName== UserName);
            UserCategory accounts1 = new UserCategory();
            if (ModelState.IsValid)
            {
                foreach (var i in dbUser)
                {
                    accounts1.UserId = i.Id;
                }
               accounts1.CategoryId = dbCategory.Id;
                _context.UserCategory.Add(accounts1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
     
    }
}



