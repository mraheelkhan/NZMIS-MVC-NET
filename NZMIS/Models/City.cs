using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NZMIS.Models
{
    public class City
    {
        public Int64 ID { get; set; }

        public State State{ get; set; }

        public Int64 StateID { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string CityCode { get; set; }

        [Required]
        public string ShortName { get; set; }

        public bool IsActive { get; set; }
    }
}