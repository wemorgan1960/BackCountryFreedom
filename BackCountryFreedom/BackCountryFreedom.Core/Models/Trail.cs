using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Models
{

    public class Trail: BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public float Distance { get; set; }
        public string DistanceScale { get; set; }
        
        public float Elevation { get; set; }
        public string ElevationScale { get; set; }

        public string Location { get; set; }

        public string Difficulty { get; set; }
        public string Type { get; set; }


        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Decmial Format 15.12345")]
        [Display(Name = "Latitude")]
        [Range(0, 180.99999)]
        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal? Lat { get; set; }

        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$", ErrorMessage = "Decimal Format -115.12345")]
        [Display(Name = "Longitude")]
        [Range(0, 180.99999)]
        [DisplayFormat(DataFormatString = "{0:0.00000}")]
        public decimal? Long { get; set; }

        public string Image { get; set; }

    }
}