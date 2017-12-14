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
        public Trail Trail { get; set; }

        public IEnumerable<Difficulty> Difficulties { get; set; }
        public IEnumerable<DistanceScale> DistanceScales { get; set; }
        public IEnumerable<ElevationScale> ElevationScales { get; set; }
        public IEnumerable<ActivityType> ActivityTypes { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
