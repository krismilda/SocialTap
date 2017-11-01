namespace SocialTap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRestaurantInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Percentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantInformations");
        }
    }
}
