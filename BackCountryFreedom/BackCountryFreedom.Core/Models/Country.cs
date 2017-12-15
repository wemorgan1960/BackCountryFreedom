using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCountryFreedom.Core.Models
{
    public class Country:BaseEntity
    {
        [Required]
        [StringLength(255)]
        [DisplayName("Country")]
        public string Description { get; set; }
    }
}
