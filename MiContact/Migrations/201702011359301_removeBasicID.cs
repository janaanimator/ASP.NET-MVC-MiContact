namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeBasicID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contact", "BasicInfo_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "BasicInfo_ID", c => c.Int(nullable: false));
        }
    }
}
