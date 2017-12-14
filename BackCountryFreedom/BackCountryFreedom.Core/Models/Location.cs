using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.Models
{
    public class Location: BaseEntity
    {
        [Required]
        [StringLength(255)]
        [DisplayName("Location")]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Province { get; set; }
    }
}