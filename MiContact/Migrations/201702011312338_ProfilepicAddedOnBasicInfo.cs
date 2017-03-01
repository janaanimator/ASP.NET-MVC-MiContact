namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilepicAddedOnBasicInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfo", "ProfilePic", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasicInfo", "ProfilePic");
        }
    }
}
