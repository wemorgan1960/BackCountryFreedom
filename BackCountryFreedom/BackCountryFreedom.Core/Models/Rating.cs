using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCountryFreedom.Core.Models
{
    public class Rating:BaseEntity
    {
        [StringLength(50)]
        [DisplayName("Rating")]
        public string Name { get; set; }
    }
}
