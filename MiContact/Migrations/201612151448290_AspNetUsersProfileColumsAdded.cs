namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetUsersProfileColumsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsersProfiles", "FirstName", c => c.String(maxLength: 200));
            AddColumn("dbo.AspNetUsersProfiles", "LastName", c => c.String(maxLength: 200));
            AddColumn("dbo.AspNetUsersProfiles", "AboutMe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsersProfiles", "AboutMe");
            DropColumn("dbo.AspNetUsersProfiles", "LastName");
            DropColumn("dbo.AspNetUsersProfiles", "FirstName");
        }
    }
}
