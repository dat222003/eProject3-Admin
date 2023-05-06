using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCD_Admin.Models;

namespace ABCD_Admin.Controllers
{
    public class GalleriesController : Controller
    {
        private Entities db = new Entities();

        // GET: Galleries
        public ActionResult Index()
        {
            var galleries = db.Galleries.Include(g => g.Movy).Include(g => g.Product).Include(g => g.Shop);
            return View(galleries.ToList());
        }

        // GET: Galleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // GET: Galleries/Create
        public ActionResult Create()
        {
            ViewBag.objectId = new SelectList(db.Movies, "movieId", "movieTitle");
            ViewBag.objectId = new SelectList(db.Products, "productId", "productName");
            ViewBag.objectId = new SelectList(db.Shops, "shopId", "shopName");
            return View();
        }

        // POST: Galleries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imageId,imagePath,objectType,objectId")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Galleries.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.objectId = new SelectList(db.Movies, "movieId", "movieTitle", gallery.objectId);
            ViewBag.objectId = new SelectList(db.Products, "productId", "productName", gallery.objectId);
            ViewBag.objectId = new SelectList(db.Shops, "shopId", "shopName", gallery.objectId);
            return View(gallery);
        }

        // GET: Galleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            ViewBag.objectId = new SelectList(db.Movies, "movieId", "movieTitle", gallery.objectId);
            ViewBag.objectId = new SelectList(db.Products, "productId", "productName", gallery.objectId);
            ViewBag.objectId = new SelectList(db.Shops, "shopId", "shopName", gallery.objectId);
            return View(gallery);
        }

        // POST: Galleries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imageId,imagePath,objectType,objectId")] Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.objectId = new SelectList(db.Movies, "movieId", "movieTitle", gallery.objectId);
            ViewBag.objectId = new SelectList(db.Products, "productId", "productName", gallery.objectId);
            ViewBag.objectId = new SelectList(db.Shops, "shopId", "shopName", gallery.objectId);
            return View(gallery);
        }

        // GET: Galleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        // POST: Galleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
