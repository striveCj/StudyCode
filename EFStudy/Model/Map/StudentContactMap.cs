using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.ModelConfiguration;

namespace EFStudy.Model.Map
{
    public class StudentContactMap:EntityTypeConfiguration<StudentContact>
    {
        public StudentContactMap()
        {
            ToTable("StudentContacts");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("StudentId").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
    }
}
