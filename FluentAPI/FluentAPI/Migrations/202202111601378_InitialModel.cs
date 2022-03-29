namespace FluentAPI.Migrations
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
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 2000),
                        Price = c.Short(nullable: false),
                        LevelString = c.String(nullable: false, maxLength: 50),
                        Level = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Authors", t => t.AuthorID)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.CourseSections",
                c => new
                    {
                        SectionID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.SectionID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false),
                        DatePublished = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        Title = c.String(nullable: false, maxLength: 255),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserProfileID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileID);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.TagID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTags", "TagID", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Covers", "Id", "dbo.Courses");
            DropForeignKey("dbo.CourseSections", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "AuthorID", "dbo.Authors");
            DropIndex("dbo.CourseTags", new[] { "TagID" });
            DropIndex("dbo.CourseTags", new[] { "CourseID" });
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.CourseSections", new[] { "CourseID" });
            DropIndex("dbo.Courses", new[] { "AuthorID" });
            DropTable("dbo.CourseTags");
            DropTable("dbo.UserProfile");
            DropTable("dbo.tblUser");
            DropTable("dbo.Posts");
            DropTable("dbo.Tags");
            DropTable("dbo.Covers");
            DropTable("dbo.CourseSections");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
