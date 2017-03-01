namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicInfoAddOnAllTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Email", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Image", "ApplicationUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Social", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Email", new[] { "ApplicationUserID" });
            DropIndex("dbo.Image", new[] { "ApplicationUserID" });
            DropIndex("dbo.Social", new[] { "ApplicationUserID" });
            AddColumn("dbo.Email", "BasicInfoID", c => c.Int(nullable: false));
            AddColumn("dbo.Image", "BasicInfoID", c => c.Int(nullable: false));
            AddColumn("dbo.Social", "BasicInfoID", c => c.Int(nullable: false));
            DropColumn("dbo.Email", "ApplicationUserID");
            DropColumn("dbo.Image", "ApplicationUserID");
            DropColumn("dbo.Social", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Social", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Image", "ApplicationUserID", c => c.String(maxLength: 128));
            AddColumn("dbo.Email", "ApplicationUserID", c => c.String(maxLength: 128));
            DropColumn("dbo.Social", "BasicInfoID");
            DropColumn("dbo.Image", "BasicInfoID");
            DropColumn("dbo.Email", "BasicInfoID");
            CreateIndex("dbo.Social", "ApplicationUserID");
            CreateIndex("dbo.Image", "ApplicationUserID");
            CreateIndex("dbo.Email", "ApplicationUserID");
            AddForeignKey("dbo.Social", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Image", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Email", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
