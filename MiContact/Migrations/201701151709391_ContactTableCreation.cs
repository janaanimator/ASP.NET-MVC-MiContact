namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ContactTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                {
                    ContactID = c.Int(nullable: false, identity: true),
                    ApplicationUserID = c.String(maxLength: 128),
                    Name = c.String(maxLength: 50),
                    Number = c.String(maxLength: 50),
                    ContactType = c.String(maxLength: 100),
                    CreatedOn = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                    UpdatedOn = c.DateTime(nullable: true),
                    Status = c.Byte(nullable: true, defaultValue: 1),
                })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Contact", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Contact", new[] { "ApplicationUserID" });
            DropTable("dbo.Contact");
        }
    }
}
