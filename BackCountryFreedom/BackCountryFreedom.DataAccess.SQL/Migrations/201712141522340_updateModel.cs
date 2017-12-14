namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventTypes", newName: "ActivityTypes");
            DropForeignKey("dbo.Events", "DistanceScale_Id", "dbo.DistanceScales");
            DropForeignKey("dbo.Events", "ElevationScale_Id", "dbo.ElevationScales");
            DropForeignKey("dbo.Conditions", "EventType_Id", "dbo.EventTypes");
            DropForeignKey("dbo.Files", "Condition_Id", "dbo.Conditions");
            DropForeignKey("dbo.Conditions", "Season_Id", "dbo.Seasons");
            DropIndex("dbo.Conditions", new[] { "EventType_Id" });
            DropIndex("dbo.Conditions", new[] { "Season_Id" });
            DropIndex("dbo.Events", new[] { "DistanceScale_Id" });
            DropIndex("dbo.Events", new[] { "ElevationScale_Id" });
            DropIndex("dbo.Files", new[] { "Condition_Id" });
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ObservationDate = c.DateTime(nullable: false),
                        User = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Distance = c.Single(nullable: false),
                        Elevation = c.Single(nullable: false),
                        ActivityType = c.String(),
                        Season = c.String(),
                        Hazards = c.String(maxLength: 255),
                        Weather_Conditions = c.String(maxLength: 255),
                        Trail_Conditions = c.String(maxLength: 255),
                        Rating = c.Int(nullable: false),
                        Image = c.String(),
                        File = c.String(),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Files", "fileName", c => c.String());
            AddColumn("dbo.Files", "file", c => c.Binary());
            AddColumn("dbo.Trails", "DistanceScale", c => c.String());
            AddColumn("dbo.Trails", "ElevationScale", c => c.String());
            AddColumn("dbo.Trails", "Location", c => c.String());
            AddColumn("dbo.Trails", "Difficulty", c => c.String());
            AddColumn("dbo.Trails", "Type", c => c.String());
            AddColumn("dbo.Trails", "Image", c => c.String());
            DropColumn("dbo.Files", "PictureName");
            DropColumn("dbo.Files", "Picture");
            DropColumn("dbo.Files", "ConditionId");
            DropColumn("dbo.Files", "Condition_Id");
            DropTable("dbo.Conditions");
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        Distance = c.Single(nullable: false),
                        Elevation = c.Single(nullable: false),
                        Lat = c.Decimal(precision: 18, scale: 2),
                        Long = c.Decimal(precision: 18, scale: 2),
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        DistanceScale_Id = c.String(maxLength: 128),
                        ElevationScale_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreateAt = c.DateTimeOffset(nullable: false, precision: 7),
                        EventType_Id = c.String(maxLength: 128),
                        Season_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Files", "Condition_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Files", "ConditionId", c => c.Int(nullable: false));
            AddColumn("dbo.Files", "Picture", c => c.Binary());
            AddColumn("dbo.Files", "PictureName", c => c.String());
            DropColumn("dbo.Trails", "Image");
            DropColumn("dbo.Trails", "Type");
            DropColumn("dbo.Trails", "Difficulty");
            DropColumn("dbo.Trails", "Location");
            DropColumn("dbo.Trails", "ElevationScale");
            DropColumn("dbo.Trails", "DistanceScale");
            DropColumn("dbo.Files", "file");
            DropColumn("dbo.Files", "fileName");
            DropTable("dbo.Observations");
            CreateIndex("dbo.Files", "Condition_Id");
            CreateIndex("dbo.Events", "ElevationScale_Id");
            CreateIndex("dbo.Events", "DistanceScale_Id");
            CreateIndex("dbo.Conditions", "Season_Id");
            CreateIndex("dbo.Conditions", "EventType_Id");
            AddForeignKey("dbo.Conditions", "Season_Id", "dbo.Seasons", "Id");
            AddForeignKey("dbo.Files", "Condition_Id", "dbo.Conditions", "Id");
            AddForeignKey("dbo.Conditions", "EventType_Id", "dbo.EventTypes", "Id");
            AddForeignKey("dbo.Events", "ElevationScale_Id", "dbo.ElevationScales", "Id");
            AddForeignKey("dbo.Events", "DistanceScale_Id", "dbo.DistanceScales", "Id");
            RenameTable(name: "dbo.ActivityTypes", newName: "EventTypes");
        }
    }
}
