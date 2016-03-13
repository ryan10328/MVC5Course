using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class AFController : Controller
    {
        [SharedViewBag]
        public ActionResult Index()
        {
            return View();
        }

        [SharedViewBag]
        public ActionResult About()
        {
            return View();
        }
    }
}