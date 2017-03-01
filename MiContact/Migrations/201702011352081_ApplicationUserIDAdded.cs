namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserIDAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contact", "ApplicationUserID");
            AddForeignKey("dbo.Contact", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Contact", "BasicInfoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "BasicInfoID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contact", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Contact", new[] { "ApplicationUserID" });
            DropColumn("dbo.Contact", "ApplicationUserID");
        }
    }
}
