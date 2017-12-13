using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Models
{
    public class Condition:BaseEntity
    {
        public DateTime ObservationDate { get; set; }

        [StringLength (255)]
        public String Hazard { get; set; }

        [StringLength(255)]
        public string Weather_Conditions { get; set; }

        [StringLength(255)]
        public string Trail_Conditions { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        public int SeasonId { get; set; }

        public virtual Season Season { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }

        public int DifficultyId { get; set; }
        public virtual Difficulty Difficulty { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

    }
}