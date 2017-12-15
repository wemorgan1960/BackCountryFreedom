namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActivityTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Trail_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trails", t => t.Trail_Id)
                .Index(t => t.Trail_Id);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DistanceScales",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ElevationScales",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        fileName = c.String(),
                        file = c.Binary(),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        User = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Distance = c.Single(nullable: false),
                        DistanceScale = c.String(),
                        Elevation = c.Single(nullable: false),
                        ElevationScale = c.String(),
                        ActivityType = c.String(),
                        Season = c.String(),
                        Hazards = c.String(maxLength: 255),
                        WeatherConditions = c.String(maxLength: 255),
                        TrailConditions = c.String(maxLength: 255),
                        Rating = c.Int(nullable: false),
                        Image = c.String(),
                        File = c.String(),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 100),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Distance = c.Single(nullable: false),
                        DistanceScale = c.String(),
                        Elevation = c.Single(nullable: false),
                        ElevationScale = c.String(),
                        Location = c.String(),
                        ProvState = c.String(),
                        Country = c.String(),
                        Difficulty = c.String(),
                        ActivityType = c.String(),
                        Lat = c.Decimal(precision: 18, scale: 2),
                        Long = c.Decimal(precision: 18, scale: 2),
                        Image = c.String(),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityTypes", "Trail_Id", "dbo.Trails");
            DropIndex("dbo.ActivityTypes", new[] { "Trail_Id" });
            DropTable("dbo.Trails");
            DropTable("dbo.Seasons");
            DropTable("dbo.Observations");
            DropTable("dbo.Locations");
            DropTable("dbo.Files");
            DropTable("dbo.ElevationScales");
            DropTable("dbo.DistanceScales");
            DropTable("dbo.Difficulties");
            DropTable("dbo.ActivityTypes");
        }
    }
}
