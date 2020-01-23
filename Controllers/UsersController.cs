using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace LibraryManagement.Controllers
{
    public class UsersController : Controller
    {
        private LibraryDatabaseEntities8 db = new LibraryDatabaseEntities8();


        // login 
       [OutputCache(Duration= 60)]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LibraryUsers LibraryUsers)
        {
            if(string.IsNullOrEmpty(LibraryUsers.UserName))
            {
                ModelState.AddModelError("UserName", "User name is required");
            }

            if (string.IsNullOrEmpty(LibraryUsers.Password))
            {
                ModelState.AddModelError("UserName", "Password is required");
            }
            if (ModelState.IsValid)
            {
                
                var objuser = db.LibraryUsers.Where(x => x.UserName == LibraryUsers.UserName && x.Password == LibraryUsers.Password);

                Session["UserName"] = LibraryUsers.UserName;
                
                
                db.SaveChanges();
                return RedirectToAction("Index", "Books", new { user = Session["UserName"] });
            }

            else
            {
                ModelState.AddModelError("Login","Please add correct information");
                return View();
            }
               
        }     

        //Registrtion Action 
        [HttpGet]
        [OutputCache(Duration= 60)]
        public ActionResult Registration()
        {
      
                return View();
         }

        // Registration Post Action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(LibraryUsers users)
        {
            users.CreateDate = DateTime.Now;
            db.LibraryUsers.Add(users);
           
            db.SaveChanges();
            Session["UserName"] = users.UserName;
            
            return RedirectToAction("Index", "Books", new { User = Session["UserName"]});
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
