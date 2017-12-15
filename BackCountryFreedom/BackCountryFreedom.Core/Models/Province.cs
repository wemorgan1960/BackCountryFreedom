﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackCountryFreedom.Core.Models
{
    public class Province:BaseEntity
    {
        [Required]
        [StringLength(255)]
        [DisplayName("ProvState")]
        public string Description { get; set; }
    }
}
