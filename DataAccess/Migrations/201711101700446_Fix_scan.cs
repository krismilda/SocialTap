namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fix_scan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Scans", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Scans", "User_Id");
            AddForeignKey("dbo.Scans", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Scans", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Scans", "Username", c => c.String());
            DropForeignKey("dbo.Scans", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Scans", new[] { "User_Id" });
            DropColumn("dbo.Scans", "User_Id");
        }
    }
}
