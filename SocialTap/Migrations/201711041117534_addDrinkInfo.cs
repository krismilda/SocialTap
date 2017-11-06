namespace SocialTap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDrinkInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Volume = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Restaurant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RestaurantInformations", t => t.Restaurant_Id)
                .Index(t => t.Restaurant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drinks", "Restaurant_Id", "dbo.RestaurantInformations");
            DropIndex("dbo.Drinks", new[] { "Restaurant_Id" });
            DropTable("dbo.Drinks");
        }
    }
}
