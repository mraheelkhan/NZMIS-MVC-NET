using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NZMIS.Models
{
    public class Area
    {
        public Int64 ID { get; set; }

        public City City { get; set; }

        public Int64 CityID { get; set; }

        [Required]
        public string AreaName { get; set; }

        [Required]
        public string AreaCode { get; set; }
    }
}