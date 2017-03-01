namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contact", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Contact", new[] { "ApplicationUserID" });
            DropColumn("dbo.Contact", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Contact", "ApplicationUserID");
            AddForeignKey("dbo.Contact", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
