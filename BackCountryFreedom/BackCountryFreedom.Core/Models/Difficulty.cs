using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.Models
{ 
    public class Difficulty:BaseEntity
    {
        [Required]
        [StringLength (255)]
        [DisplayName("Difficulty")]
        public String Description { get; set; }
    }
}