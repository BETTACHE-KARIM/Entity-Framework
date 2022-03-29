namespace DataAnnotation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Cours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cours()
        {
            Tags = new HashSet<Tag>();
        }

        public int ID { get; set; }

        [Required]
        [MaxLength(2000)]

        public string Description { get; set; }

        public int Level { get; set; }

        public float FullPrice { get; set; }


        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        


        public int? authorID { get; set; }
        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
