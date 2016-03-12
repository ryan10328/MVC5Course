using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(MemberViewModel model)
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(FormCollection model)
        //{
        //    var name = model["Name"];
        //    var birthday = model["Birthday"];

        //    return View();
        //}

        public ActionResult Index()
        {
            var result = repo.All().Take(5);
            return View(result);
        }

        [HttpPost]
        public ActionResult Index(IList<Product> data)
        {
            foreach (var item in data)
            {
                var product = repo.Get(item.ProductId);
                product.ProductName = item.ProductName;
                product.Price = item.Price;
            }

            repo.UnitOfWork.Commit();

            return RedirectToAction("Index","MB");
        }
    }
}