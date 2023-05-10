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
    public class ProductImagesController : Controller
    {
        private Entities db = new Entities();

        // GET: ProductImages
        public ActionResult Index(int? id)
        {
            var productImages = db.ProductImages.Include(p => p.Product);

            if (id != null)
            {
                productImages = productImages.Where(pi => pi.productId == id);
            }
            ViewBag.Position = "ProductImages";
            return View(productImages.ToList());
        }


        // GET: ProductImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "ProductImages";
            return View(productImage);
        }

        // GET: ProductImages/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.Products, "productId", "productName");
            ViewBag.Position = "ProductImages";
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductImage productImage, HttpPostedFileBase imagePath)
        {
            if (ModelState.IsValid && imagePath != null)
            {
                // Save image file to server
                string fileName = Path.GetFileName(imagePath.FileName);
                string path = Path.Combine(Server.MapPath("~/images/product/"), fileName);
                imagePath.SaveAs(path);

                // Set imagePath property to uploaded file's name
                productImage.imagePath = fileName;

                db.ProductImages.Add(productImage);
                db.SaveChanges();
                ViewBag.Position = "ProductImages";
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.Products, "productId", "productName", productImage.productId);
            ViewBag.Position = "ProductImages";
            return View(productImage);
        }


        // GET: ProductImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.Products, "productId", "productName", productImage.productId);
            ViewBag.Position = "ProductImages";
            return View(productImage);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductImage model, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                // Check if a new image file is uploaded
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    // Delete the old product image from the "images/product" folder
                    var oldImagePath = Server.MapPath("~/images/product/") + model.imagePath;
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    // Save the uploaded image to the "images/product" folder
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/product"), fileName);
                    imageFile.SaveAs(path);
                    model.imagePath = fileName;

                }

                // Update the product image in the database
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Position = "ProductImages";
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.Products, "id", "name", model.productId);
            ViewBag.Position = "ProductImages";
            return View(model);
        }



        // GET: ProductImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImages.Find(id);
            if (productImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "ProductImages";
            return View(productImage);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductImage productImage = db.ProductImages.Find(id);
            db.ProductImages.Remove(productImage);
            db.SaveChanges();
            ViewBag.Position = "ProductImages";
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
