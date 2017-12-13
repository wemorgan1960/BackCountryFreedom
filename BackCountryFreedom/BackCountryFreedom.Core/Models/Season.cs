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
        public Season()
        {
            this.Conditions = new HashSet<Condition>();
        }
        [Required]
        [StringLength (100)]
        public String Description { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
    }
}