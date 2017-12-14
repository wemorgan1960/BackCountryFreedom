using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<DistanceScale> DistanceScales { get; set; }
        public DbSet<ElevationScale> ElevationScales { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Trail> Trails { get; set; }

    }
}
