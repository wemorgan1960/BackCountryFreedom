using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BackCountryFreedom.Core.Models;
using System.ComponentModel;

namespace BackCountryFreedom.Core.Models
{
    public class Season: BaseEntity
    {
        [Required]
        [StringLength (100)]
        [DisplayName("Season")]
        public String Description { get; set; }
    }
}