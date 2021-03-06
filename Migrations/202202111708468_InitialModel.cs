namespace UpdateDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Level = c.Int(nullable: false),
                        FullPrice = c.Single(nullable: false),
                        author_ID = c.Int(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.author_ID)
                .Index(t => t.author_ID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo._Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagCourses",
                c => new
                    {
                        Course_ID = c.Int(nullable: false),
                        Tag_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_ID, t.Tag_ID })
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_ID, cascadeDelete: true)
                .Index(t => t.Course_ID)
                .Index(t => t.Tag_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "author_ID", "dbo.Authors");
            DropForeignKey("dbo.TagCourses", "Tag_ID", "dbo.Tags");
            DropForeignKey("dbo.TagCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.TagCourses", new[] { "Tag_ID" });
            DropIndex("dbo.TagCourses", new[] { "Course_ID" });
            DropIndex("dbo.Courses", new[] { "author_ID" });
            DropTable("dbo.TagCourses");
            DropTable("dbo._Categories");
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
