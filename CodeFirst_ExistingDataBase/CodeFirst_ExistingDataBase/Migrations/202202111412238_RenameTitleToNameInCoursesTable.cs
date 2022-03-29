namespace CodeFirst_ExistingDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            Sql("Update Courses set Name = Title");
            
            DropColumn("dbo.Courses", "Title");


            //RenameColumn("dbo.Courses", "Title", "Name"); //FirstMethode



        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable:false));
            Sql("Update Courses set Title = Name");

            DropColumn("dbo.Courses", "Name");
        }
    }
}
