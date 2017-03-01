namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAltered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Email", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Email", "Description");
        }
    }
}
