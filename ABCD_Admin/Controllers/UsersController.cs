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
    public class UsersController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userData = db.Users
                .Include(u => u.Employee)
                .FirstOrDefault(u => u.userName == user.userName && u.password == user.password);

            if (userData != null)
            {
                Session["employeeId"] = userData.Employee.employeeId;
                Session["fullName"] = userData.Employee.fullName;
                return RedirectToAction("Index", "Orders");
            }

            ModelState.AddModelError("", "Invalid login credentials.");
            return View(user);
        }


        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login", "Users");
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Employee);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<Group> groups = user.Groups.ToList();
            List<Function> functions = user.Functions.ToList();
            ViewBag.groups = groups;
            ViewBag.functions = functions;
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.employeeId = new SelectList(db.Employees, "employeeId", "email");
            ViewBag.groups = new SelectList(db.Groups, "groupId", "groupName");
            ViewBag.functions = new SelectList(db.Functions, "functionId", "functionName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userName,password,employeeId")] User user, int[] Groups, int[] Functions)
        {
            if (ModelState.IsValid)
            {
                // Ensure the selected employee exists
                var employee = db.Employees.Find(user.employeeId);
                if (employee == null)
                {
                    ModelState.AddModelError(string.Empty, "The selected employee does not exist.");
                    ViewBag.employeeId = new SelectList(db.Employees, "employeeId", "email", user.employeeId);
                    ViewBag.groups = new MultiSelectList(db.Groups, "groupId", "groupName", Groups);
                    ViewBag.functions = new MultiSelectList(db.Functions, "functionId", "functionName", Functions);
                    return View(user);
                }

                // Add the new user to the database
                db.Users.Add(user);
                db.SaveChanges();

                // Add the new user's group memberships to the Groups table
                if (Groups != null)
                {
                    foreach (var groupId in Groups)
                    {
                        var group = db.Groups.Find(groupId);
                        if (group != null)
                        {
                            group.Users.Add(user);
                        }
                    }
                    db.SaveChanges();
                }

                // Add the new user's function memberships to the Functions table
                if (Functions != null)
                {
                    foreach (var functionId in Functions)
                    {
                        var function = db.Functions.Find(functionId);
                        if (function != null)
                        {
                            function.Users.Add(user);
                        }
                    }
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.employeeId = new SelectList(db.Employees, "employeeId", "email", user.employeeId);
            ViewBag.groups = new MultiSelectList(db.Groups, "groupId", "groupName", Groups);
            ViewBag.functions = new MultiSelectList(db.Functions, "functionId", "functionName", Functions);

            return View(user);
        }




        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeId = new SelectList(db.Employees, "employeeId", "email", user.employeeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userName,password,employeeId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeId = new SelectList(db.Employees, "employeeId", "email", user.employeeId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
