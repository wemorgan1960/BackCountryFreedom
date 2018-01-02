namespace BackCountryFreedom.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Observations", "Trail_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Observations", "Trail_Id");
            AddForeignKey("dbo.Observations", "Trail_Id", "dbo.Trails", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Observations", "Trail_Id", "dbo.Trails");
            DropIndex("dbo.Observations", new[] { "Trail_Id" });
            DropColumn("dbo.Observations", "Trail_Id");
        }
    }
}
