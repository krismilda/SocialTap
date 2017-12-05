namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.News",
                 c => new
                 {           
                     Id = c.Int(nullable: false, identity: true),
                     User_Id = c.String(maxLength: 128),
                     Date = c.DateTime(nullable: false),
                     Text = c.String(nullable: false),
                 })
    .PrimaryKey(t => t.Id)
    .ForeignKey("dbo.AspNetUsers", t => t.User_Id);
        }

        public override void Down()
        {
        }
    }
}
