namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetUsersProfileTableCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsersProfiles",
                c => new
                    {
                        AspNetUsersProfileID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        Dob = c.String(),
                        GenderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AspNetUsersProfileID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .ForeignKey("dbo.Gender", t => t.GenderID, cascadeDelete: true)
                .Index(t => t.ApplicationUserID)
                .Index(t => t.GenderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsersProfiles", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.AspNetUsersProfiles", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsersProfiles", new[] { "GenderID" });
            DropIndex("dbo.AspNetUsersProfiles", new[] { "ApplicationUserID" });
            DropTable("dbo.AspNetUsersProfiles");
        }
    }
}
