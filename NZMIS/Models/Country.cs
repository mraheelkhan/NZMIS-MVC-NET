using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NZMIS.Models
{
    public class Country
    {
        public Int64 ID { get; set; }
        public string CountryName { get; set; }
        public string ISO3166_1 { get; set; }
        public string CountryCode { get; set; }
        public bool IsDefault { get; set; }

    }
}