using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NZMIS.Models;
using System.Data.SqlClient;
using System.Data.Entity;
using NZMIS.ViewModels;

namespace NZMIS.Controllers
{
    public class CountryController : Controller
    {
        private ApplicationDbContext _context;
        public CountryController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Country
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "Country";
            ViewBag.Function = "List";
            ViewBag.Success = "Country successfully added";
            var countries  = _context.Country.ToList();
            var states = _context.State.Include(c => c.Country).ToList();
            var cities = _context.Cities.Where(c => c.StateID == 5).ToList();

            var viewModel = new CountryStateCityViewModel
            {
                Country = countries,
                State = states,
                City = cities
            };
            //return View();
            // return Json(countries, JsonRequestBehavior.AllowGet);
            return View("Index", viewModel);
        }   

        public ActionResult New(Country country)
        {
            ViewBag.BreadCrumb = "Country";
            ViewBag.Function = "New";

           
            return View("New");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Store(Country country)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Invalid information";
                return View("New");
            }

            _context.Country.Add(country);
            _context.SaveChanges();

            ViewBag.Success = "Country successfully added";
            return RedirectToAction("Index", "Country");
        }
        public ActionResult Edit(int Id)
        {
            ViewBag.BreadCrumb = "Country";
            ViewBag.Function = "Edit";
            var country = _context.Country.SingleOrDefault(c => c.ID == Id);
            if (country == null)
                return HttpNotFound();
            return View(country);
        }

        public ActionResult Update(Country country)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

            var CountryInDb = _context.Country.Single(c => c.ID == country.ID);
            CountryInDb.CountryName = country.CountryName;
            CountryInDb.CountryCode = country.CountryCode;
            CountryInDb.ISO3166_1 = country.ISO3166_1;
            CountryInDb.IsDefault = country.IsDefault;

            _context.SaveChanges();
            return RedirectToAction("Index", "Country");
        }

        public ActionResult Destroy(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

            var countryInDb = _context.Country.Single(m => m.ID == Id);
            if (countryInDb == null)
                return HttpNotFound();
            _context.Country.Remove(countryInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Country");
        }
    }
}