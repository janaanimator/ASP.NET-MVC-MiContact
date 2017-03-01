namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SocialAltered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Social", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Social", "Description");
        }
    }
}
