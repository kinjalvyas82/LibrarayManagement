using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{

    public class BooksController : Controller
    {
        private LibraryDatabaseEntities8 db = new LibraryDatabaseEntities8();




        //List of books page
        [OutputCache(Duration = 60)]
        public ActionResult Index(string searchby, string searching)
        {
            {

                if (searchby == "Title")
                {
                    var books = db.LibraryBooks.Where(x => x.Title.Contains(searching) || searching == null).ToList();
                    return View(books);

                }
                else if (searchby == "AuthorName")
                {
                    var books = db.LibraryBooks.Where(x => x.AuthorName.Contains(searching) || searching == null).ToList();
                    return View(books);

                }
                else if (searchby == "ISBN")
                {
                    var books = db.LibraryBooks.Where(x => x.ISBNID.Contains(searching) || searching == null).ToList();
                    return View(books);

                }
                else
                {
                    var books = db.LibraryBooks.ToList();
                    return View(books);
                }

            }
        }

        // GET: Books/Create new books
        [OutputCache(Duration = 60)]
        public ActionResult CreateBooks()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBooks(LibraryBooks books)
        {
            if (ModelState.IsValid)
            {
                db.LibraryBooks.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books);
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public ActionResult CheckOut(int? ID, int? BookID, int? librarycopyid)
        {
            
            var result = db.BookInventory.Where(x => x.Inventory_ID == ID).ToList();
            Session["InventoryID"] = ID;
            Session["BookID"] = BookID;
            Session["LibraryCopy"] = librarycopyid;

            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(int? ID, int? BookID, int? librarycopyid, CheckOut check, BookInventory BookInventory, string user)
        {
            //var result = db.BookInventory.Where(x => x.Inventory_ID == ID).ToList();

            Session["InventoryID"] = ID;
            Session["BookID"] = BookID;
            Session["LibraryCopy"] = librarycopyid;
            Session["UserName"] = user;


            BookInventory b = db.BookInventory.Where(x => x.LibraryCopy_ID == librarycopyid).FirstOrDefault();
            if (b != null)
            {
                b.Avaliable = "N";
                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();


                LibraryUsers users = db.LibraryUsers.Where(x => x.UserName == user).FirstOrDefault();
                if (users != null)
                {
                    check.Inventory_ID = int.Parse(ID.ToString());
                    check.UserID = users.UserID;
                    check.CheckOut_Date = DateTime.Today;
                    check.Return_Date = DateTime.Now.AddDays(7);
                    Session["ReturnDate"] = check.Return_Date;
                    db.CheckOut.Add(check);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("EndPage", "Books", new { UserName = Session["UserName"],libraryid = Session["LibraryCopy"]});
       }
    




        ////POST : Books/RequestBook
        public ActionResult RequestBook(int? BookID, BookInventory book)
        {

           
            var result = db.BookInventory.Where(x => x.BookID == BookID && x.Avaliable == "Y").ToList();


            return View(result);

        }

        [HttpGet]
        public ActionResult EndPage()
        {

            return View();
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




