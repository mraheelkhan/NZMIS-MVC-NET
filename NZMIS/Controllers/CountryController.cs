using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NZMIS.Models;
using System.Data.SqlClient;
using System.Data.Entity;

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
            var countries  = _context.Country.ToList();

            //return View();
            // return Json(countries, JsonRequestBehavior.AllowGet);
            return View("Index", countries);
        }

        public ActionResult New(Country country)
        {
            return View("New");
        }

        public ActionResult Test()
        {
            return Content("TEsting content here");
        }
    }
}