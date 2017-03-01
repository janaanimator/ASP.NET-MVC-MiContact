namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ImageTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                {
                    ImageID = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                    Name = c.String(maxLength: 50),
                    URL = c.String(maxLength: 100),
                    Description = c.String(maxLength: 1000),
                    CreatedOn = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedOn = c.DateTime(nullable: true),
                    Status = c.Byte(nullable: true, defaultValue: 1),
                })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Image", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Image", new[] { "ApplicationUserID" });
            DropTable("dbo.Image");
        }
    }
}
