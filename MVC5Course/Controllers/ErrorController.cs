using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ErrorController : Controller
    {
        [HandleError(View = "Error2", ExceptionType = typeof(FormatException))]
        public ActionResult Index(string e)
        {
            if (string.IsNullOrEmpty(e))
            {
                return View();
            }
            else
            {
                if (e == "1")
                {
                    throw new FormatException("格式錯誤");
                }
                if (e == "2")
                {
                    throw new ArgumentException("參數錯誤");
                }
            }
         
            return View();
        }
    }
}