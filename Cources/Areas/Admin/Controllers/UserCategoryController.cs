using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cources.Areas.Admin.Models;
using Cources.Data;
using Cources.Entities;
using System.Collections;

namespace Cources.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserCategoryController :Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/UserCategory
        public async Task<IActionResult> Index()
        {

            IQueryable<Category> dbList = _context.Category;


            return View(dbList.ToList());
        }
        public async Task<IActionResult> save(string CourseName, string FirstName,string LastName)
        {
           Category dbCategory = (Category)_context.Category.Where(a => a.Title == CourseName);
            var dbUser =_context.Users.Where(a => a.FirstName == FirstName && a.LastName==LastName );

            UserCategory accounts1 = new UserCategory();
            if (ModelState.IsValid)
            {
                foreach(var i in dbUser)
                {
                    accounts1.UserId = i.Id;
                }
                accounts1.CategoryId = dbCategory.Id;
                _context.UserCategory.Add(accounts1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return  RedirectToAction("Index");

        }
        public async Task<JsonResult>  getCategoryUsers(string CourseName)
        {
           Category categoryid =(Category)_context.Category.Where(a => a.Title == CourseName);

            IQueryable<UserCategory> dbList = (IQueryable<UserCategory>)_context.UserCategory.Where(a => a.CategoryId == categoryid.Id);
            ArrayList lst1 = new ArrayList();

            if (dbList != null)
            {

                foreach (var i in dbList)
                {
                    var dbUser = _context.Users.Where(a => Convert.ToInt32(a.Id) == i.Id);
                    string[] LittleLst= new string[2]; 
                    foreach (var j in dbUser)
                    {
                        LittleLst[0]=j.FirstName;
                        LittleLst[1]=j.FirstName;
                    }
                    int x = LittleLst.Length;
                    lst1.Add(LittleLst);

                }

            }
            ViewBag.getUsers = lst1;

            //ViewBag.Acc_Id = new System.Web.Mvc.SelectList(_context.UserModel, "Id", "FirstName",dbList);

            //foreach (var i in dbList)
            //{
            //    UserModel dbUser = (UserModel)_context.UserModel.Where(a => a.Id==i.UserId);

            //}
            return Json("hello");

        }
        public async Task<JsonResult> getAllUsers()
        {

            var dbUser = _context.Users.ToList();
            return Json(dbUser);

        }
    }
}
