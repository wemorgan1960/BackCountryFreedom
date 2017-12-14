using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.Models
{
    public class ElevationScale:BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}