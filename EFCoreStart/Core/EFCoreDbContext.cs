using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Model;
using EFCoreStart.ValueGenerator;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStart.Core
{
    public class EFCoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EFCoreDbConnectionString"]
                .ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
               
                entity.HasKey(k => k.Guid);
                //TODO:主键且自增长
                entity.Property(p => p.Guid).HasColumnType("VARCHAR(36)").HasDefaultValueSql("NEWID()");
                //TODO:主键非自增长
                //entity.Property(p => p.Id).ValueGeneratedNever();
                //TODO:新增或修改实体时就会自动生成值，修改实体时就会自动生成值
                entity.Property(p => p.CreateTime).HasColumnType("DATETIME").HasValueGenerator((d,g)=>new CreatedTimeValueGenerator()).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.Status).HasDefaultValue(0);
                entity.Property(p => p.Decimal).HasColumnType("decimal(18,4)");
                entity.Property(p => p.Name).HasColumnType("VARCHAR(50)");
                //TODO:修改实体时就会自动生成值
                //entity.Property(p => p.Id).ValueGeneratedOnUpdate();
            });
            modelBuilder.HasSequence<int>("SQLSequence").StartsAt(1000).IncrementsBy(2);
            modelBuilder.Entity<Customer>().Property(x => x.CustomerId).HasDefaultValueSql("Next Value For SQLSequence");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
    }
}
