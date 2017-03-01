namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutMeAddOnBasicInfoTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfo", "AboutMe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasicInfo", "AboutMe");
        }
    }
}
