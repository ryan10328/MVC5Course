using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        public ActionResult Index()
        {
            var db = new FabricsDbConext();

            db.Products.Add(new Product()
            {
                ProductName = "Water",
                Price = 3,
                Stock = 1,
                Active = true
            });

            db.SaveChanges();

            var data = db.Products.ToList();
            return View(data);
        }
    }
}