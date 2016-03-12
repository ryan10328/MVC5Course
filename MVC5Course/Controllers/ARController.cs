using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View("Index");
        }

        public ActionResult Index3()
        {
            return PartialView("Index");
        }

        public ActionResult Download()
        {
            var data = repo.All().Where(x => x.ProductId <= 50).ToList();
            StringBuilder sb = new StringBuilder();

            sb.Append("ProductName,Price,Stock \r\n");
            foreach (var d in data)
            {
                sb.Append($"{d.ProductName},{d.Price},{d.Stock} \r\n");
            }


            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "Product.csv");

        }

        public ActionResult GetJson()
        {
            var db = new FabricsEntities();
            //解決循環參考問題
            db.Configuration.LazyLoadingEnabled = false;
            var products = db.Products.Take(4);
            return Json(products, JsonRequestBehavior.AllowGet);

        }



    }
}