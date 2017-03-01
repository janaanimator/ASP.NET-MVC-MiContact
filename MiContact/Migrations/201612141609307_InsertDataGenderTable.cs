namespace MiContact.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InsertDataGenderTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Gender (Gender)VALUES('Male')");
            Sql("INSERT INTO Gender (Gender)VALUES('Female')");
            Sql("INSERT INTO Gender (Gender)VALUES('TransGender')");
        }

        public override void Down()
        {
            Sql("DELETE Gender WHERE GenderID IN(1,2,3)");
        }
    }
}
