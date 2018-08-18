using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFStudy.Model.Map
{
    public class CourseMap:EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            ToTable("Courses");
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(t => t.MaximumStrength);
            Property(t => t.CreatedTime);
            Property(t => t.ModifiedTime);
        }
    }
}
