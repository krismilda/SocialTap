namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnsToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Sum", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "Times", c => c.Int(nullable: false));
            DropColumn("dbo.Restaurants", "Percentage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Percentage", c => c.Int(nullable: false));
            DropColumn("dbo.Restaurants", "Times");
            DropColumn("dbo.Restaurants", "Sum");
        }
    }
}
