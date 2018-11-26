using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStart.Configuration
{
   public class StudentConfiguration:IEntityTypeConfiguration<Student>
    {
         public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.HasOne(o => o.StudentContact).WithOne(o => o.Student).HasForeignKey<StudentContact>(k => k.ContactNumber)
                .OnDelete(DeleteBehavior.Cascade);
        }
    
    }
}
