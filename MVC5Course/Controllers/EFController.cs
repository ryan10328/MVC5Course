using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsDbConext db = new FabricsDbConext();
        public ActionResult Index()
        {
            var product = new Product()
            {
                ProductName = "Beer",
                Price = 2,
                Stock = 1,
                Active = true
            };

            db.Products.Add(product);

          

            try
            {
                db.SaveChanges();
                // after executed savechanges, you can get product id
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;
                    foreach (var err in item.ValidationErrors)
                    {
                        throw new DbEntityValidationException($"Message: {err.ErrorMessage}, Model: { entityName }, PropName: {err.PropertyName}");
                    }
                }
            }
            var singleProduct = db.Products.Where(x => x.ProductId == product.ProductId).ToList();
            return View(singleProduct);
        }

        public ActionResult Details(int? id)
        {
            if(!id.HasValue)
            {
                return View();
            }
            var product = db.Products.Find(id);
            return View(product);
        }
    }
}