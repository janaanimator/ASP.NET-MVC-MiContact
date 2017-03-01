namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AspNetUsersImagesTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsersImages",
                c => new
                {
                    AspNetUsersImagesID = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                    ImageURL = c.String(maxLength: 1000),
                    ImageType = c.String(maxLength: 1000),
                    ToSetProfilePic = c.String(maxLength: 50, defaultValue: "0"),
                    ToSetBannerPic = c.String(maxLength: 50, defaultValue: "0"),
                    ImageDescription = c.String(),
                    Status = c.Byte(nullable: false, defaultValueSql: "1"),
                    CreatedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                    UpdateOn = c.DateTime(nullable: true),
                })
                .PrimaryKey(t => t.AspNetUsersImagesID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);

            AddColumn("dbo.AspNetUsersProfiles", "Mobile", c => c.String(maxLength: 20));
            AlterColumn("dbo.AspNetUsersProfiles", "Dob", c => c.String(maxLength: 20));
        }
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsersImages", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsersImages", new[] { "ApplicationUserID" });
            AlterColumn("dbo.AspNetUsersProfiles", "Dob", c => c.String());
            DropColumn("dbo.AspNetUsersProfiles", "Mobile");
            DropTable("dbo.AspNetUsersImages");
        }
    }
}
