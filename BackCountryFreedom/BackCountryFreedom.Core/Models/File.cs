﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Models
{
    public class File: BaseEntity
    {
        public string PictureName { get; set; }
        public byte[] Picture { get; set; }
        public int ConditionId { get; set; }
        public virtual Condition Condition { get; set; }
    }
}