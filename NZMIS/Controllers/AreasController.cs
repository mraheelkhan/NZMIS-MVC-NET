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
    public class AreasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Areas
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "Areas";
            ViewBag.Function = "List";
            var areas = db.Areas.Include(a => a.City);
            return View(areas.ToList());
        }

        // GET: Areas/Details/5
        public ActionResult Details(long? id)
        {
            ViewBag.BreadCrumb = "Areas";
            ViewBag.Function = "Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // GET: Areas/Create
        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Areas";
            ViewBag.Function = "Create";
            ViewBag.CityID = new SelectList(db.Cities, "ID", "CityName");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CityID,AreaName,AreaCode")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Areas.Add(area);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "CityName", area.CityID);
            return View(area);
        }

        // GET: Areas/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.BreadCrumb = "Areas";
            ViewBag.Function = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "CityName", area.CityID);
            return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CityID,AreaName,AreaCode")] Area area)
        {
            if (ModelState.IsValid)
            {
                db.Entry(area).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "CityName", area.CityID);
            return View(area);
        }

        // GET: Areas/Delete/5
        public ActionResult Delete(long? id)
        {
            ViewBag.BreadCrumb = "Areas";
            ViewBag.Function = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Area area = db.Areas.Find(id);
            if (area == null)
            {
                return HttpNotFound();
            }
            return View(area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Area area = db.Areas.Find(id);
            db.Areas.Remove(area);
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
