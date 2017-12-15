using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.ViewModels
{
    public class TrailListViewModel
    {
        public IEnumerable<Trail> Trails { get; set; }
        public IEnumerable<Difficulty> Difficulties { get; set; }
        public IEnumerable<DistanceScale> DistanceScales { get; set; }
        public IEnumerable<ElevationScale> ElevationScales { get; set; }
        public IEnumerable<ActivityType> ActivityTypes { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<Country> Countries { get; set; }
    }
}
