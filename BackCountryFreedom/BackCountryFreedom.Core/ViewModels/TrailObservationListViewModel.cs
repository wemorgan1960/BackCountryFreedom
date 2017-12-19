using BackCountryFreedom.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCountryFreedom.Core.ViewModels
{
    public class TrailObservationListViewModel
    {
        public Trail Trail { get; set; }
        public IEnumerable<Observation> Observations { get; set; }
    }
}
