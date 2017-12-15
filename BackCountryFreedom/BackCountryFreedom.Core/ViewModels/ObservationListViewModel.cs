using BackCountryFreedom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCountryFreedom.Core.ViewModels
{
    public class ObservationListViewModel
    {
        public IEnumerable<Observation> Observations { get; set; }

        public IEnumerable<ActivityType> ActivityTypes { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public IEnumerable<DistanceScale> DistanceScales { get; set; }
        public IEnumerable<ElevationScale> ElevationScales { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}
