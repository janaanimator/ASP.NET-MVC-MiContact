namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicInfoAgain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "BasicInfoID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "BasicInfoID");
        }
    }
}
