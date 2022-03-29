namespace CodeFirst_ExistingDataBase.Migrations
{
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst_ExistingDataBase.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst_ExistingDataBase.PlutoContext context)
        {
            context.Authors.AddOrUpdate(
                a => a.Name,
                new Author
                {
                    Name = "Author 1",
                    Courses = new Collection<Course>()
                            {
                             new Course()
                             {
                                 Title = "Course1 for Author 1",
                                 Description ="desc2 for Author 1"
                             },
                               new Course()
                             {
                                 Title = "Course2 for Author 1",
                                 Description ="desc2 for Author 1"
                             }
                            }
                }
                );
        }
    }
}
