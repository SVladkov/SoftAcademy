using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SecondDemo;

namespace SecondDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private CompanyEntities db = new CompanyEntities();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.City).Include(e => e.Employee1).Include(e => e.Position1).Include(e => e.Project);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName");
            ViewBag.Manager = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.Position = new SelectList(db.Positions, "PositionName", "PositionName");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Position,Salary,CityId,Email,Phone,ProjectId,Manager")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", employee.CityId);
            ViewBag.Manager = new SelectList(db.Employees, "Id", "FirstName", employee.Manager);
            ViewBag.Position = new SelectList(db.Positions, "PositionName", "PositionName", employee.Position);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", employee.ProjectId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", employee.CityId);
            ViewBag.Manager = new SelectList(db.Employees, "Id", "FirstName", employee.Manager);
            ViewBag.Position = new SelectList(db.Positions, "PositionName", "PositionName", employee.Position);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", employee.ProjectId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Position,Salary,CityId,Email,Phone,ProjectId,Manager")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "CityName", employee.CityId);
            ViewBag.Manager = new SelectList(db.Employees, "Id", "FirstName", employee.Manager);
            ViewBag.Position = new SelectList(db.Positions, "PositionName", "PositionName", employee.Position);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "ProjectName", employee.ProjectId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
