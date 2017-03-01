namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class EmailTableCreations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Email",
                c => new
                {
                    EmailID = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                    Email = c.String(maxLength: 50),
                    EmailType = c.String(maxLength: 100),
                    CreatedOn = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedOn = c.DateTime(nullable: true),
                    Status = c.Byte(nullable: true, defaultValue: 1),
                })
                .PrimaryKey(t => t.EmailID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Email", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Email", new[] { "ApplicationUserID" });
            DropTable("dbo.Email");
        }
    }
}
