namespace CodeFirst_ExistingDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("Insert Into Categories values(1, 'Web Dev')");
            Sql("Insert Into Categories values(2, 'Desktop Dev')");


        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
