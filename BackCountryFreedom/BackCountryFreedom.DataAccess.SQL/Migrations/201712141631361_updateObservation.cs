namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateObservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observations", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Observations", "WeatherConditions", c => c.String(maxLength: 255));
            AddColumn("dbo.Observations", "TrailConditions", c => c.String(maxLength: 255));
            DropColumn("dbo.Observations", "ObservationDate");
            DropColumn("dbo.Observations", "Weather_Conditions");
            DropColumn("dbo.Observations", "Trail_Conditions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Observations", "Trail_Conditions", c => c.String(maxLength: 255));
            AddColumn("dbo.Observations", "Weather_Conditions", c => c.String(maxLength: 255));
            AddColumn("dbo.Observations", "ObservationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Observations", "TrailConditions");
            DropColumn("dbo.Observations", "WeatherConditions");
            DropColumn("dbo.Observations", "Date");
        }
    }
}
