using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCD_Admin.Models;

namespace ABCD_Admin.Controllers
{
    public class ShopsController : Controller
    {
        private Entities db = new Entities();

        // GET: Shops
        public ActionResult Index()
        {
            ViewBag.Position = "Shops";
            return View(db.Shops.ToList());
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Shops";
            return View(shop);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            ViewBag.Position = "Shops";
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shopId,shopName,shopAddress,phoneNumber,email,imagePath")] Shop shop, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var imagePath = Path.Combine(Server.MapPath("~/images/shop"), fileName);
                    imageFile.SaveAs(imagePath);
                    shop.imagePath = fileName;
                }

                db.Shops.Add(shop);
                db.SaveChanges();
                ViewBag.Position = "Shops";
                return RedirectToAction("Index");
            }
            ViewBag.Position = "Shops";
            return View(shop);
        }


        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Shops";
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shopId,shopName,shopAddress,phoneNumber,email,imagePath")] Shop shop, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                // Check if a new image file is uploaded
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    // Delete the old shop image from the "images/shop" folder
                    var oldImagePath = Server.MapPath("~/images/shop/") + shop.imagePath;
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    // Save the uploaded image to the "images/shop" folder
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/shop"), fileName);
                    imageFile.SaveAs(path);
                    shop.imagePath = fileName;

                }

                // Update the shop in the database
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Position = "Shops";
                return RedirectToAction("Index");
            }

            ViewBag.Position = "Shops";
            return View(shop);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Shops";
            return View(shop);
        }




        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
            db.SaveChanges();
            ViewBag.Position = "Shops";
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
