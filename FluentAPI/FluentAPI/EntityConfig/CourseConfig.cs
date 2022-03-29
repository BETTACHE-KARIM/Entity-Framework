using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityConfig
{
    public class CourseConfig : EntityTypeConfiguration<Cours>
    {
        public CourseConfig()
        {
            ToTable("tbl_Course");

            HasKey(c => c.CourseID);

            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(255);

            ///////////////Relation Ship
            // 1 to many

            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorID)
            .WillCascadeOnDelete(false);


            //1 to 1

            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.cours)

            ;

            //many to many

            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseID");
                m.MapRightKey("TagID");
            });

          

        }
    }
}
