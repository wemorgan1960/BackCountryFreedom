using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.Core.ViewModels
{
    public class ObservationManagerViewModel
    {
        public Observation Observation { get; set; }

        public IEnumerable<ActivityType> ActivityTypes { get; set; }
        public IEnumerable<Season> Seasons { get; set; }
        public IEnumerable<DistanceScale> DistanceScales { get; set; }
        public IEnumerable<ElevationScale> ElevationScales { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }

    }
}
