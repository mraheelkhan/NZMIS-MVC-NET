using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NZMIS.Models
{
    public class State
    {
        public Int64 ID { get; set; }

        public Country Country { get; set; }

        public Int64 CountryID { get; set; }

        [Required]
        public string StateName { get; set; }

        [Required]
        public string StateCode { get; set; }
    }
}