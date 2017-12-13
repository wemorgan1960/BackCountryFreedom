using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackCountryFreedom.Models;

namespace BackCountryFreedom.Core.ViewModels
{
    public class TrailManagerViewModel
    {
        public Trail Trails { get; set; }

        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Difficulty> Difficulties { get; set; }
        public IEnumerable<DistanceScale> DistanceScales { get; set; }
        public IEnumerable<ElevationScale> ElevationScales { get; set; }
        public IEnumerable<EventType> EventTypes { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
