namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAddBasicInfoTbale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicInfo", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasicInfo", "Email");
        }
    }
}
