namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicInfoIDAddeddOnContactTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "BasicInfo_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Contact", "BasicInfo_BasicInfoID", c => c.Int());
            CreateIndex("dbo.Contact", "BasicInfo_BasicInfoID");
            AddForeignKey("dbo.Contact", "BasicInfo_BasicInfoID", "dbo.BasicInfo", "BasicInfoID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "BasicInfo_BasicInfoID", "dbo.BasicInfo");
            DropIndex("dbo.Contact", new[] { "BasicInfo_BasicInfoID" });
            DropColumn("dbo.Contact", "BasicInfo_BasicInfoID");
            DropColumn("dbo.Contact", "BasicInfo_ID");
        }
    }
}
