namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemodel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActivityTypes", "Trail_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Observations", "DistanceScale", c => c.String());
            AddColumn("dbo.Observations", "ElevationScale", c => c.String());
            CreateIndex("dbo.ActivityTypes", "Trail_Id");
            AddForeignKey("dbo.ActivityTypes", "Trail_Id", "dbo.Trails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActivityTypes", "Trail_Id", "dbo.Trails");
            DropIndex("dbo.ActivityTypes", new[] { "Trail_Id" });
            DropColumn("dbo.Observations", "ElevationScale");
            DropColumn("dbo.Observations", "DistanceScale");
            DropColumn("dbo.ActivityTypes", "Trail_Id");
        }
    }
}
