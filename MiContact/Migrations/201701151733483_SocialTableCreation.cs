namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SocialTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Social",
                c => new
                {
                    SocialID = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                    Link = c.String(maxLength: 50),
                    URL = c.String(maxLength: 300),
                    LinkType = c.String(maxLength: 100),
                    CreatedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedOn = c.DateTime(nullable: true),
                    Status = c.Byte(nullable: true, defaultValue: 1),
                })
                .PrimaryKey(t => t.SocialID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Social", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Social", new[] { "ApplicationUserID" });
            DropTable("dbo.Social");
        }
    }
}
