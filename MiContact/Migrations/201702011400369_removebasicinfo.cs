namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removebasicinfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contact", "BasicInfo_BasicInfoID", "dbo.BasicInfo");
            DropIndex("dbo.Contact", new[] { "BasicInfo_BasicInfoID" });
            DropColumn("dbo.Contact", "BasicInfo_BasicInfoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "BasicInfo_BasicInfoID", c => c.Int());
            CreateIndex("dbo.Contact", "BasicInfo_BasicInfoID");
            AddForeignKey("dbo.Contact", "BasicInfo_BasicInfoID", "dbo.BasicInfo", "BasicInfoID");
        }
    }
}
