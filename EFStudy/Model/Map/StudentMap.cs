﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Model.Map
{
    public class StudentMap:EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Students");
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnType("VARCHAR").HasMaxLength(50);
            Property(t => t.Age);
            Property(t => t.CreatedTime);
            Property(t => t.ModifiedTime);
            HasMany(t => t.Courses).WithMany(c => c.Students).Map(t => t.ToTable("StudentCourses").MapLeftKey("StudentId").MapRightKey("CourseId"));

        }
    }
}
