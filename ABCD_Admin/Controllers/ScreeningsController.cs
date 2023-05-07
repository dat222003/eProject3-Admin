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
    public class ScreeningsController : Controller
    {
        private Entities db = new Entities();

        // GET: Screenings
        public ActionResult Index()
        {
            var screenings = db.Screenings.Include(s => s.Movy).Include(s => s.Room);
            return View(screenings.ToList());
        }

        // GET: Screenings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screening screening = db.Screenings.Find(id);
            if (screening == null)
            {
                return HttpNotFound();
            }
            return View(screening);
        }

        // GET: Screenings/Create
        public ActionResult Create()
        {
            ViewBag.movieId = new SelectList(db.Movies, "movieId", "movieTitle");
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId");
            return View();
        }

        // POST: Screenings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "screeningId,movieId,roomId,reservedTime,price")] Screening screening)
        {
            if (ModelState.IsValid)
            {
                db.Screenings.Add(screening);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.movieId = new SelectList(db.Movies, "movieId", "movieTitle", screening.movieId);
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", screening.roomId);
            return View(screening);
        }

        // GET: Screenings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screening screening = db.Screenings.Find(id);
            if (screening == null)
            {
                return HttpNotFound();
            }
            ViewBag.movieId = new SelectList(db.Movies, "movieId", "movieTitle", screening.movieId);
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", screening.roomId);
            return View(screening);
        }

        // POST: Screenings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "screeningId,movieId,roomId,reservedTime,price")] Screening screening)
        {
            if (ModelState.IsValid)
            {
                db.Entry(screening).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.movieId = new SelectList(db.Movies, "movieId", "movieTitle", screening.movieId);
            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", screening.roomId);
            return View(screening);
        }

        // GET: Screenings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Screening screening = db.Screenings.Find(id);
            if (screening == null)
            {
                return HttpNotFound();
            }
            return View(screening);
        }

        // POST: Screenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Screening screening = db.Screenings.Find(id);
            db.Screenings.Remove(screening);
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
