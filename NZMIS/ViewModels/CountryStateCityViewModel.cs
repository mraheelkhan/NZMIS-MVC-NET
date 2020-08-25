using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NZMIS.Models;

namespace NZMIS.ViewModels
{
    public class CountryStateCityViewModel
    {
        public List<State> State { get; set; }

        public List<Country> Country { get; set; }

        public List<City> City { get; set; }

        public List<City> AllCities { get; set; }

    }
}