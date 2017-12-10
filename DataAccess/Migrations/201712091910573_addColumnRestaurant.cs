namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "placesId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "placesId");
        }
    }
}
