using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Model;
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
                entity.HasKey(k => k.Id);
                //TODO:主键且自增长
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                //TODO:主键非自增长
                entity.Property(p => p.Id).ValueGeneratedNever();
                //TODO:新增或修改实体时就会自动生成值，修改实体时就会自动生成值
                entity.Property(p => p.CreateTime).HasColumnType("DATETIME").HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
                //TODO:修改实体时就会自动生成值
                entity.Property(p => p.Id).ValueGeneratedOnUpdate();
            });
        }
        public DbSet<Student> Students { get; set; }
    }
}
