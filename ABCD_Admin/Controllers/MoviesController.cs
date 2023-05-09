using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABCD_Admin.Models;

namespace ABCD_Admin.Controllers
{
    public class MoviesController : Controller
    {
        private Entities db = new Entities();

        // GET: Movies
        public ActionResult Index()
        {
            ViewBag.Position = "Movies";
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Movies";
            return View(movy);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.Position = "Movies";
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movieId,movieTitle,movieDescription,releaseDate,duration,status,rating,trailerLink")] Movy movy, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var imagePath = Path.Combine(Server.MapPath("~/images/movie"), fileName);
                    imageFile.SaveAs(imagePath);
                    movy.imagePath = fileName;
                }

                db.Movies.Add(movy);
                db.SaveChanges();
                ViewBag.Position = "Movies";
                return RedirectToAction("Index");
            }
            ViewBag.Position = "Movies";
            return View(movy);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Movies";
            return View(movy);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "movieId,movieTitle,movieDescription,releaseDate,duration,status,rating,trailerLink")] Movy movy, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var imagePath = Path.Combine(Server.MapPath("~/images/movie"), fileName);
                    imageFile.SaveAs(imagePath);
                    movy.imagePath = fileName;
                }
                db.Entry(movy).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Position = "Movies";
                return RedirectToAction("Index");
            }
            ViewBag.Position = "Movies";
            return View(movy);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Movies";
            return View(movy);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movy movy = db.Movies.Find(id);
            db.Movies.Remove(movy);
            db.SaveChanges();
            ViewBag.Position = "Movies";
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
