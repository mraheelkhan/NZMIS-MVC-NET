﻿using System;
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
    public class CitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cities
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "Cities";
            ViewBag.Function = "List";
            var cities = db.Cities.Include(c => c.State);
            return View(cities.ToList());
        }

        // GET: Cities/Details/5
        public ActionResult Details(long? id)
        {
            ViewBag.BreadCrumb = "Cities";
            ViewBag.Function = "Detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Cities";
            ViewBag.Function = "Create";
            ViewBag.StateID = new SelectList(db.State, "ID", "StateName");
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StateID,CityName,CityCode,ShortName,IsActive")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateID = new SelectList(db.State, "ID", "StateName", city.StateID);
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.BreadCrumb = "Cities";
            ViewBag.Function = "Edit";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.State, "ID", "StateName", city.StateID);
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StateID,CityName,CityCode,ShortName,IsActive")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.State, "ID", "StateName", city.StateID);
            return View(city);
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(long? id)
        {
            ViewBag.BreadCrumb = "Cities";
            ViewBag.Function = "Delete";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CitiesByStateID(int id)
        {
            var cities = db.Cities.Where(c => c.StateID == id).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet); 
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
