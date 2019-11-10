using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SVEA_App.Models;

namespace SVEA_App.Controllers
{
    public class PersonTablesController : Controller
    {
        private PersonsDBEntities2 db = new PersonsDBEntities2();

        // GET: PersonTbl
        public ActionResult Index()
        {
            var personTables = db.PersonTables.Include(p => p.DepartmentTable);
            return View(personTables.ToList());
        }

        // GET: PersonTbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonTable personTable = db.PersonTables.Find(id);
            if (personTable == null)
            {
                return HttpNotFound();
            }
            return View(personTable);
        }

        // GET: PersonTbl/Create
        public ActionResult Create()
        {
            ViewBag.Department = new SelectList(db.DepartmentTables, "DepartmentName", "DepartmentName");
            return View();
        }

        // POST: PersonTbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,Name,Birthdate,Department")] PersonTable personTable)
        {
            if (ModelState.IsValid)
            {
                db.PersonTables.Add(personTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Department = new SelectList(db.DepartmentTables, "DepartmentName", "DepartmentName", personTable.Department);
            return View(personTable);
        }

        // GET: PersonTbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonTable personTable = db.PersonTables.Find(id);
            if (personTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.Department = new SelectList(db.DepartmentTables, "DepartmentName", "DepartmentName", personTable.Department);
            return View(personTable);
        }

        // POST: PersonTbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonId,Name,Birthdate,Department")] PersonTable personTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = new SelectList(db.DepartmentTables, "DepartmentName", "DepartmentName", personTable.Department);
            return View(personTable);
        }

        // GET: PersonTbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonTable personTable = db.PersonTables.Find(id);
            if (personTable == null)
            {
                return HttpNotFound();
            }
            return View(personTable);
        }

        // POST: PersonTbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonTable personTable = db.PersonTables.Find(id);
            db.PersonTables.Remove(personTable);
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
        /*
        [HttpPost]
        public ActionResult Process (ProcessModel[] selectedRow)
        {
            foreach( var row in selectedRow )
            {
                if(row.IsSelected)
                {
                    var selectedId = row.Id;
                }
            }
            return View();
        }*/
    }
}
