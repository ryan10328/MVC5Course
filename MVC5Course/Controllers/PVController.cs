using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class PVController : Controller
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Products.Find(id);
            Product product = repo.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult OrderLines(int id)
        {
            var orderlines = repo.Get(id).OrderLines;
            return View(orderlines);
        }
    }
}