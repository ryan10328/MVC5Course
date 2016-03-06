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
            //var product = new Product()
            //{
            //    ProductName = "Beer",
            //    Price = 2,
            //    Stock = 1,
            //    Active = true
            //};

            //db.Products.Add(product);
            var products = db.Products.OrderByDescending(x => x.ProductId).Take(5);

            foreach (var item in products)
            {
                item.Price = item.Price + 1;
            }

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
            // var singleProduct = db.Products.Where(x => x.ProductId == product.ProductId).ToList();
            return View(db.Products.OrderByDescending(x => x.ProductId).Take(5));
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return View();
            }
            var product = db.Products.Find(id);
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            var product = db.Products.Find(id);

            //1. 土法煉鋼版
            //var ol = db.OrderLines.Where(x => x.ProductId == product.ProductId);
            //foreach(var item in ol)
            //{
            //    db.OrderLines.Remove(item);
            //}

            // 2. 稍微改進版
            //foreach (var item in product.OrderLines)
            //{
            //    db.OrderLines.Remove(item);
            //}

            // 3. 一行幹掉版
            // 有FK所以要先刪除子表資料
            db.OrderLines.RemoveRange(product.OrderLines);

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}