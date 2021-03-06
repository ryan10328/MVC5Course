﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        // GET: Products
        public ActionResult Index(int? id, bool? isActive, string keyword)
        {
            var result = repo.All().Take(20);
            if (id.HasValue)
            {
                ViewBag.SelectedProductId = id.Value;
            }

            var items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "是", Value = "true" });
            items.Add(new SelectListItem() { Text = "否", Value = "false" });
            ViewBag.isActive = new SelectList(items, "Value", "Text");

            if (isActive.HasValue)
            {
                result = result.Where(x => x.Active == isActive.Value);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(x => x.ProductName.Contains(keyword));
            }

            return View(result);
        }

        // GET: Products/Details/5
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

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                TempData["Message"] = "儲存成功";
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection from)
        {
            var product = repo.Get(id);
            //    [Bind(Include = "ProductId,ProductName,Price,Active,Stock")]
            //Product product
            if (TryUpdateModel<Product>(product, "ProductId,ProductName,Price,Active,Stock".Split(',').ToArray()))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }


            //if (ModelState.IsValid)
            //{
            //    var db = repo.UnitOfWork.Context as FabricsEntities;
            //    db.Entry(product).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = repo.Get(id);
            repo.Delete(product);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = repo.UnitOfWork.Context as FabricsEntities;
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
