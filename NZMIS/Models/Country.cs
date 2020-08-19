using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NZMIS.Models
{
    public class Country
    {
        public Int64 ID { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string ISO3166_1 { get; set; }
        [Required]
        public string CountryCode { get; set; }
        public bool IsDefault { get; set; }

    }
}