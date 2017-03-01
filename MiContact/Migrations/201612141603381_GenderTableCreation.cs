namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class GenderTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gender",
                c => new
                {
                    GenderID = c.Int(nullable: false, identity: true),
                    Gender = c.String(maxLength: 100),
                    Status = c.Byte(nullable: false, defaultValueSql: "1"),
                    CreatedOn = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                })
                .PrimaryKey(t => t.GenderID);

        }

        public override void Down()
        {
            DropTable("dbo.Gender");
        }
    }
}
