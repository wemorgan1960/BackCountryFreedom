using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Models
{
    public class Season: BaseEntity
    {
        [Required]
        [StringLength (100)]
        public String Description { get; set; }
    }
}