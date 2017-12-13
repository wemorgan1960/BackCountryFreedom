namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelsViewModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Conditions", "Difficulty_Id", "dbo.Difficulties");
            DropForeignKey("dbo.Conditions", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Difficulties", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventTypes", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.Trails", "DistanceScale_Id", "dbo.DistanceScales");
            DropForeignKey("dbo.Trails", "ElevationScale_Id", "dbo.ElevationScales");
            DropForeignKey("dbo.Trails", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Conditions", new[] { "Difficulty_Id" });
            DropIndex("dbo.Conditions", new[] { "Event_Id" });
            DropIndex("dbo.Difficulties", new[] { "Event_Id" });
            DropIndex("dbo.Events", new[] { "Location_Id" });
            DropIndex("dbo.EventTypes", new[] { "Event_Id" });
            DropIndex("dbo.Trails", new[] { "DistanceScale_Id" });
            DropIndex("dbo.Trails", new[] { "ElevationScale_Id" });
            DropIndex("dbo.Trails", new[] { "Location_Id" });
            DropColumn("dbo.Conditions", "SeasonId");
            DropColumn("dbo.Conditions", "EventId");
            DropColumn("dbo.Conditions", "DifficultyId");
            DropColumn("dbo.Conditions", "EventTypeId");
            DropColumn("dbo.Conditions", "Difficulty_Id");
            DropColumn("dbo.Conditions", "Event_Id");
            DropColumn("dbo.Difficulties", "Event_Id");
            DropColumn("dbo.Events", "DistanceScaleId");
            DropColumn("dbo.Events", "ElevationScaleId");
            DropColumn("dbo.Events", "LocationId");
            DropColumn("dbo.Events", "Location_Id");
            DropColumn("dbo.EventTypes", "Event_Id");
            DropColumn("dbo.Trails", "DistanceScaleId");
            DropColumn("dbo.Trails", "ElevationScaleId");
            DropColumn("dbo.Trails", "LocationId");
            DropColumn("dbo.Trails", "DistanceScale_Id");
            DropColumn("dbo.Trails", "ElevationScale_Id");
            DropColumn("dbo.Trails", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trails", "Location_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Trails", "ElevationScale_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Trails", "DistanceScale_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Trails", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Trails", "ElevationScaleId", c => c.Int(nullable: false));
            AddColumn("dbo.Trails", "DistanceScaleId", c => c.Int(nullable: false));
            AddColumn("dbo.EventTypes", "Event_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "Location_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Events", "LocationId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "ElevationScaleId", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "DistanceScaleId", c => c.Int(nullable: false));
            AddColumn("dbo.Difficulties", "Event_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Conditions", "Event_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Conditions", "Difficulty_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Conditions", "EventTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Conditions", "DifficultyId", c => c.Int(nullable: false));
            AddColumn("dbo.Conditions", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Conditions", "SeasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trails", "Location_Id");
            CreateIndex("dbo.Trails", "ElevationScale_Id");
            CreateIndex("dbo.Trails", "DistanceScale_Id");
            CreateIndex("dbo.EventTypes", "Event_Id");
            CreateIndex("dbo.Events", "Location_Id");
            CreateIndex("dbo.Difficulties", "Event_Id");
            CreateIndex("dbo.Conditions", "Event_Id");
            CreateIndex("dbo.Conditions", "Difficulty_Id");
            AddForeignKey("dbo.Trails", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.Trails", "ElevationScale_Id", "dbo.ElevationScales", "Id");
            AddForeignKey("dbo.Trails", "DistanceScale_Id", "dbo.DistanceScales", "Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Locations", "Id");
            AddForeignKey("dbo.EventTypes", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Difficulties", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Conditions", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Conditions", "Difficulty_Id", "dbo.Difficulties", "Id");
        }
    }
}
