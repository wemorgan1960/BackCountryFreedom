using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackCountryFreedom.Models;

namespace BackCountryFreedom.Core.ViewModels
{
    class ConditionManger
    {
        public Condition Condition { get; set; }

        public IEnumerable<Season> Seasons { get; set; }
    }
}
