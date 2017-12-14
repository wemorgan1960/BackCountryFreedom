using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.Models
{
    public class ActivityType: BaseEntity
    {
        [Required]
        [StringLength (255)]
        [DisplayName("ActivityType")]
        public string Description { get; set; }
    }
}