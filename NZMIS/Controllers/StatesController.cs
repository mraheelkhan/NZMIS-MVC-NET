using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NZMIS.Models;

namespace NZMIS.Controllers
{
    public class StatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: States
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "States";
            ViewBag.Function = "List";
            var state = db.State.Include(s => s.Country);
            return View(state.ToList());
        }

        // GET: States/Details/5
        public ActionResult Details(long? id)
        {
            ViewBag.BreadCrumb = "States";
            ViewBag.Function = "Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "States";
            ViewBag.Function = "Create";
            ViewBag.CountryID = new SelectList(db.Country, "ID", "CountryName");
            return View();
        }

        // POST: States/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountryID,StateName,StateCode")] State state)
        {
            if (ModelState.IsValid)
            {
                db.State.Add(state);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Country, "ID", "CountryName", state.CountryID);
            return View(state);
        }

        // GET: States/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.BreadCrumb = "States";
            ViewBag.Function = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Country, "ID", "CountryName", state.CountryID);
            return View(state);
        }

        // POST: States/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountryID,StateName,StateCode")] State state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(state).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Country, "ID", "CountryName", state.CountryID);
            return View(state);
        }

        // GET: States/Delete/5
        public ActionResult Delete(long? id)
        {
            ViewBag.BreadCrumb = "States";
            ViewBag.Function = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = db.State.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            State state = db.State.Find(id);
            db.State.Remove(state);
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
