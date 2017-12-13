using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Models
{
    public class EventType: BaseEntity
    {
        public EventType()
        {
            this.Conditions = new HashSet<Condition>();
        }
        [Required]
        [StringLength (255)]
        public string Description { get; set; }
        public virtual ICollection<Condition> Conditions { get; set; }
    }
}