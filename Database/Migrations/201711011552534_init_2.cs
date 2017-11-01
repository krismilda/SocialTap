namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drinks", "Restaurant_Id", c => c.Int());
            CreateIndex("dbo.Drinks", "Restaurant_Id");
            AddForeignKey("dbo.Drinks", "Restaurant_Id", "dbo.RestaurantInformations", "Id");
            DropColumn("dbo.Drinks", "RestaurantInformationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "RestaurantInformationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Drinks", "Restaurant_Id", "dbo.RestaurantInformations");
            DropIndex("dbo.Drinks", new[] { "Restaurant_Id" });
            DropColumn("dbo.Drinks", "Restaurant_Id");
        }
    }
}
