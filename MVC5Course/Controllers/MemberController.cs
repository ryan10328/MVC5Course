using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (CheckLogin(model.Email, model.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(model.Email, false);
                //RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Password", "登入失敗，請重新登入");

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool CheckLogin(string email, string password)
        {
            return (email == "ryan10328@gmail.com" && password == "123");
        }

        public ActionResult RazorTest()
        {
            int[] data = new[] { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
    }
}