using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NZMIS.Models
{
    public class Spot
    {
        public Int64 ID { get; set; }

        public Area Area { get; set; }

        public Int64 AreaID { get; set; }

        [Required]
        public string SpotName { get; set; }

        [Required]
        public string SpotCode { get; set; }
    }
}