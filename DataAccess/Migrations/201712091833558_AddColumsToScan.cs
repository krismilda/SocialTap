namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumsToScan : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Scans", "Millimeters", c => c.Double(nullable: false));
            AddColumn("dbo.Scans", "Drink", c => c.String());
            AddColumn("dbo.Scans", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.News", new[] { "User_Id" });
            DropColumn("dbo.Scans", "Price");
            DropColumn("dbo.Scans", "Drink");
            DropColumn("dbo.Scans", "Millimeters");
            DropTable("dbo.News");
        }
    }
}
