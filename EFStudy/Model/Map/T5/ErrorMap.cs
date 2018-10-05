using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using EFStudy.Model.T5;

namespace EFStudy.Model.Map.T5
{
    public class ErrorMap:EntityTypeConfiguration<Error>
    {
        public ErrorMap()
        {
            ToTable("Errors");
            HasKey(k => k.ErrorId);
            Property(p => p.Active);
            Property(p => p.CommandType).HasColumnType("VARCHAR");
            Property(p => p.CreateDate);
            Property(p => p.Exception).HasColumnType("VARCHAR");
            Property(p => p.FileName);
            Property(p => p.InnerException).HasColumnType("VARCHAR");
            Property(p => p.Parameters);
            Property(p => p.Query).IsRequired().HasColumnType("VARCHAR"); ;
            Property(p => p.RequestId);
            Property(p => p.TotalSeconds);
        }
    }
}
