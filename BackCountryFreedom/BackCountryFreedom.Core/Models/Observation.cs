using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.Models
{
    public class Observation:BaseEntity
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public float Distance { get; set; }

        public string DistanceScale { get; set; }

        public float Elevation { get; set; }

        public string ElevationScale { get; set; }

        public string ActivityType { get; set; }

        public string Season { get; set; }

        [StringLength (255)]
        public String Hazards { get; set; }

        [StringLength(255)]
        public string WeatherConditions { get; set; }

        [StringLength(255)]
        public string TrailConditions { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public string Image { get; set; }

        public string File { get; set; }
    }
}