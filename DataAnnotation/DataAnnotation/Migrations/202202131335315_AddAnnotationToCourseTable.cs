namespace DataAnnotation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationToCourseTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "author_ID", newName: "authorID");
            RenameIndex(table: "dbo.Courses", name: "IX_author_ID", newName: "IX_authorID");
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Courses", "Title", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Title", c => c.String());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            RenameIndex(table: "dbo.Courses", name: "IX_authorID", newName: "IX_author_ID");
            RenameColumn(table: "dbo.Courses", name: "authorID", newName: "author_ID");
        }
    }
}
