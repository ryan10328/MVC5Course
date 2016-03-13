using AutoMapper;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        ProductRepository productDB = RepositoryHelper.GetProductRepository();
        MapperConfiguration config = new MapperConfiguration(
              x => x.CreateMap<ProductViewModel, Product>());
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ProductViewModel model)
        {
            var mapper = config.CreateMapper();
            var product = productDB.Get(model.ProductId);
            product = mapper.Map(model, product);

            return View();
        }

        public ActionResult MemberProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemberProfile(MemberViewModel member)
        {
            return View();
        }


    }
}