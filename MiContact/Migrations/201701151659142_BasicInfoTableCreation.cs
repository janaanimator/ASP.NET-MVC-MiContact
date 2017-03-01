namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class BasicInfoTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasicInfo",
                c => new
                {
                    BasicInfoID = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                    FirstName = c.String(maxLength: 100),
                    LastName = c.String(maxLength: 100),
                    GenderID = c.Int(nullable: false),
                    DateOfBirth = c.String(maxLength: 50),
                    Profession = c.String(maxLength: 1000),
                    Mobile = c.String(maxLength: 50),
                    Address = c.String(maxLength: 1000),
                    CreatedOn = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedOn = c.DateTime(nullable: true),
                    Status = c.Byte(nullable: true, defaultValue: 1),
                })
                .PrimaryKey(t => t.BasicInfoID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Gender", t => t.GenderID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.GenderID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.BasicInfo", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.BasicInfo", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.BasicInfo", new[] { "GenderID" });
            DropIndex("dbo.BasicInfo", new[] { "ApplicationUserID" });
            DropTable("dbo.BasicInfo");
        }
    }
}
