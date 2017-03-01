namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AspNetUsersProfileColumsAdded1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsersProfiles", "Status", c => c.Byte(nullable: false, defaultValueSql: "1"));
            AddColumn("dbo.AspNetUsersProfiles", "CreatedOn", c => c.DateTime(defaultValueSql: "GETDATE()"));
            AddColumn("dbo.AspNetUsersProfiles", "UpdatedOn", c => c.DateTime());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsersProfiles", "UpdatedOn");
            DropColumn("dbo.AspNetUsersProfiles", "CreatedOn");
            DropColumn("dbo.AspNetUsersProfiles", "Status");
        }
    }
}
