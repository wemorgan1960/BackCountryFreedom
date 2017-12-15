namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BackCountryFreedom.Core.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BackCountryFreedom.DataAccess.SQL.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackCountryFreedom.DataAccess.SQL.DataContext context)
        {

            context.DistanceScales.AddOrUpdate(x => x.Id,
                new DistanceScale() { Id = Guid.NewGuid().ToString(), Description = "Kilometers", CreateAt = DateTime.Now },
                new DistanceScale() { Id = Guid.NewGuid().ToString(), Description = "Miles", CreateAt = DateTime.Now }
                );

            context.ElevationScales.AddOrUpdate(x => x.Id,
                new ElevationScale() { Id = Guid.NewGuid().ToString(), Description = "Meters", CreateAt = DateTime.Now },
                new ElevationScale() { Id = Guid.NewGuid().ToString(), Description = "Feet", CreateAt = DateTime.Now }
                );

            context.Seasons.AddOrUpdate(x => x.Id,
                new Season() { Id = Guid.NewGuid().ToString(), Description = "Spring", CreateAt = DateTime.Now },
                new Season() { Id = Guid.NewGuid().ToString(), Description = "Summer", CreateAt = DateTime.Now },
                new Season() { Id = Guid.NewGuid().ToString(), Description = "Fall", CreateAt = DateTime.Now },
                new Season() { Id = Guid.NewGuid().ToString(), Description = "Winter", CreateAt = DateTime.Now }
                );

            context.Provinces.AddOrUpdate(x => x.Id,
                new Province() { Id = Guid.NewGuid().ToString(), Description = "Alberta", CreateAt = DateTime.Now },
                new Province() { Id = Guid.NewGuid().ToString(), Description = "British Columbia", CreateAt = DateTime.Now },
                new Province() { Id = Guid.NewGuid().ToString(), Description = "Washington", CreateAt = DateTime.Now },
                new Province() { Id = Guid.NewGuid().ToString(), Description = "Montana", CreateAt = DateTime.Now },
                new Province() { Id = Guid.NewGuid().ToString(), Description = "Idaho", CreateAt = DateTime.Now }
                );

            context.Countries.AddOrUpdate(x => x.Id,
                new Country() { Id = Guid.NewGuid().ToString(), Description = "Canada", CreateAt = DateTime.Now },
                new Country() { Id = Guid.NewGuid().ToString(), Description = "USA", CreateAt = DateTime.Now }
                );

            context.Difficulties.AddOrUpdate(x => x.Id,
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Easy", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Easy to Moderate", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Moderate", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Moderate to Hard", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Hard", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Hard to Advanced", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Advanced", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Advanced to Extreme", CreateAt = DateTime.Now },
                new Difficulty() { Id = Guid.NewGuid().ToString(), Description = "Extreme", CreateAt = DateTime.Now }
                );

            context.ActivityTypes.AddOrUpdate(x => x.Id,
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Walking", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Hiking", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Scrambling", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Climbing - Traditional", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Climbing - Sport", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Climbing - Absailing", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Climbing - Ascending", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Mountaineering", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Backpacking", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Mountain Biking", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Mountain Biking - Hard Tail", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Mountain Biking - Downhill", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Mountain Biking - Fat Tire", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Touring Bike", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Ski Touring - AT", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Ski Touring - NT", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Ski Touring - Light", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Cross Country Skiing - Classical", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Cross Country Skiing - Skating", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "SnowShoing", CreateAt = DateTime.Now },
                new ActivityType() { Id = Guid.NewGuid().ToString(), Description = "Skating", CreateAt = DateTime.Now }
    );

            context.Locations.AddOrUpdate(x => x.Id,
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Banff NP", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Kootenay NP", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Jasper NP", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Yoho NP", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Kananaskis-Bow Valley", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Kananaskis-Canmore", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Kananaskis-Spray Lakes", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Kananaskis-Peter Lougheed Area", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Kananaskis-Highwood Pass", CreateAt = DateTime.Now },
                new Location() { Id = Guid.NewGuid().ToString(), Description = "Waterton NP", CreateAt = DateTime.Now }
                 );
        }
    }
}
