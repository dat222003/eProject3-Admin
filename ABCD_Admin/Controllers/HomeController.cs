using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCD_Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Position = "Dashboard";
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Position = "Dashboard";
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.Position = "Dashboard";
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                ViewBag.Position = "Dashboard";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Position = "Dashboard";
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Position = "Dashboard";
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ViewBag.Position = "Dashboard";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Position = "Dashboard";
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Position = "Dashboard";
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ViewBag.Position = "Dashboard";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Position = "Dashboard";
                return View();
            }
        }
    }
}
