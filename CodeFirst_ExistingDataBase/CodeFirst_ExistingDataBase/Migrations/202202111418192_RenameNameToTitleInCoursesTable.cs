namespace CodeFirst_ExistingDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameNameToTitleInCoursesTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Courses", "Name", "Title"); //FirstMethode

        }

        public override void Down()
        {
            RenameColumn("dbo.Courses", "Title", "Name"); //FirstMethode

        }
    }
}
