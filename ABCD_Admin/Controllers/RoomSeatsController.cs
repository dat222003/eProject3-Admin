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
    public class RoomSeatsController : Controller
    {
        private Entities db = new Entities();

        // GET: RoomSeats
        public ActionResult Index()
        {
            var roomSeats = db.RoomSeats.Include(r => r.Room).Include(r => r.Seat);
            ViewBag.Position = "Rooms";
            return View(roomSeats.ToList());
        }

        // GET: RoomSeats/Details/5?roomId=1&seatId=1
        public ActionResult Details(int? roomId, int? seatId)
        {
            if (roomId == null || seatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RoomSeat roomSeat = db.RoomSeats.SingleOrDefault(rs => rs.roomId == roomId && rs.seatId == seatId);

            if (roomSeat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Position = "Rooms";
            return View(roomSeat);
        }

        // GET: RoomSeats/Edit/5?roomId=1&seatId=1
        public ActionResult Edit(int? roomId, int? seatId)
        {
            if (roomId == null || seatId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RoomSeat roomSeat = db.RoomSeats.SingleOrDefault(rs => rs.roomId == roomId && rs.seatId == seatId);

            if (roomSeat == null)
            {
                return HttpNotFound();
            }

            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", roomSeat.roomId);
            ViewBag.seatId = new SelectList(db.Seats, "seatId", "seatName", roomSeat.seatId);
            ViewBag.Position = "Rooms";
            return View(roomSeat);
        }

        // POST: RoomSeats/Edit/5?roomId=1&seatId=1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "roomId,seatId,isAvailable")] RoomSeat roomSeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomSeat).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Position = "Rooms";
                return RedirectToAction("Index");
            }

            ViewBag.roomId = new SelectList(db.Rooms, "roomId", "roomId", roomSeat.roomId);
            ViewBag.seatId = new SelectList(db.Seats, "seatId", "seatName", roomSeat.seatId);
            ViewBag.Position = "Rooms";
            return View(roomSeat);
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
