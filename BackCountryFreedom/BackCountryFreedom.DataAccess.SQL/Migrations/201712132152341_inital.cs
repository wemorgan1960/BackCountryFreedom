namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conditions",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ObservationDate = c.DateTime(nullable: false),
                        Hazard = c.String(maxLength: 255),
                        Weather_Conditions = c.String(maxLength: 255),
                        Trail_Conditions = c.String(maxLength: 255),
                        Rating = c.Int(nullable: false),
                        SeasonId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        DifficultyId = c.Int(nullable: false),
                        EventTypeId = c.Int(nullable: false),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Difficulty_Id = c.String(maxLength: 128),
                        Event_Id = c.String(maxLength: 128),
                        EventType_Id = c.String(maxLength: 128),
                        Season_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Difficulties", t => t.Difficulty_Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.EventTypes", t => t.EventType_Id)
                .ForeignKey("dbo.Seasons", t => t.Season_Id)
                .Index(t => t.Difficulty_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.EventType_Id)
                .Index(t => t.Season_Id);
            
            CreateTable(
                "dbo.Difficulties",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Event_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Distance = c.Single(nullable: false),
                        DistanceScaleId = c.Int(nullable: false),
                        Elevation = c.Single(nullable: false),
                        ElevationScaleId = c.Int(nullable: false),
                        Lat = c.Decimal(precision: 18, scale: 2),
                        Long = c.Decimal(precision: 18, scale: 2),
                        LocationId = c.Int(nullable: false),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        DistanceScale_Id = c.String(maxLength: 128),
                        ElevationScale_Id = c.String(maxLength: 128),
                        Location_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DistanceScales", t => t.DistanceScale_Id)
                .ForeignKey("dbo.ElevationScales", t => t.ElevationScale_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.DistanceScale_Id)
                .Index(t => t.ElevationScale_Id)
                .Index(t => t.Location_Id);
            
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
                "dbo.EventTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Event_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Description = c.String(nullable: false, maxLength: 255),
                        Province = c.String(nullable: false, maxLength: 255),
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
                "dbo.Files",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PictureName = c.String(),
                        Picture = c.Binary(),
                        ConditionId = c.Int(nullable: false),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Condition_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conditions", t => t.Condition_Id)
                .Index(t => t.Condition_Id);
            
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Distance = c.Single(nullable: false),
                        DistanceScaleId = c.Int(nullable: false),
                        Elevation = c.Single(nullable: false),
                        ElevationScaleId = c.Int(nullable: false),
                        Lat = c.Decimal(precision: 18, scale: 2),
                        Long = c.Decimal(precision: 18, scale: 2),
                        LocationId = c.Int(nullable: false),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        DistanceScale_Id = c.String(maxLength: 128),
                        ElevationScale_Id = c.String(maxLength: 128),
                        Location_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DistanceScales", t => t.DistanceScale_Id)
                .ForeignKey("dbo.ElevationScales", t => t.ElevationScale_Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .Index(t => t.DistanceScale_Id)
                .Index(t => t.ElevationScale_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trails", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Trails", "ElevationScale_Id", "dbo.ElevationScales");
            DropForeignKey("dbo.Trails", "DistanceScale_Id", "dbo.DistanceScales");
            DropForeignKey("dbo.Files", "Condition_Id", "dbo.Conditions");
            DropForeignKey("dbo.Conditions", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.EventTypes", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Conditions", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Events", "ElevationScale_Id", "dbo.ElevationScales");
            DropForeignKey("dbo.Events", "DistanceScale_Id", "dbo.DistanceScales");
            DropForeignKey("dbo.Difficulties", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Conditions", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Conditions", "Difficulty_Id", "dbo.Difficulties");
            DropIndex("dbo.Trails", new[] { "Location_Id" });
            DropIndex("dbo.Trails", new[] { "ElevationScale_Id" });
            DropIndex("dbo.Trails", new[] { "DistanceScale_Id" });
            DropIndex("dbo.Files", new[] { "Condition_Id" });
            DropIndex("dbo.EventTypes", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "Location_Id" });
            DropIndex("dbo.Events", new[] { "ElevationScale_Id" });
            DropIndex("dbo.Events", new[] { "DistanceScale_Id" });
            DropIndex("dbo.Difficulties", new[] { "Event_Id" });
            DropIndex("dbo.Conditions", new[] { "Season_Id" });
            DropIndex("dbo.Conditions", new[] { "EventType_Id" });
            DropIndex("dbo.Conditions", new[] { "Event_Id" });
            DropIndex("dbo.Conditions", new[] { "Difficulty_Id" });
            DropTable("dbo.Trails");
            DropTable("dbo.Files");
            DropTable("dbo.Seasons");
            DropTable("dbo.Locations");
            DropTable("dbo.EventTypes");
            DropTable("dbo.ElevationScales");
            DropTable("dbo.DistanceScales");
            DropTable("dbo.Events");
            DropTable("dbo.Difficulties");
            DropTable("dbo.Conditions");
        }
    }
}
