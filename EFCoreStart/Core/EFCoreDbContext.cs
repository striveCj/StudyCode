using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Configuration;
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
                //TODO:备用键
                entity.HasAlternateKey(p => p.Name);

                //TODO:主键且自增长
                entity.Property(p => p.Guid).HasColumnType("VARCHAR(36)").HasDefaultValueSql("NEWID()");
                //TODO:主键非自增长
                //entity.Property(p => p.Id).ValueGeneratedNever();
                //TODO:新增或修改实体时就会自动生成值，修改实体时就会自动生成值
                entity.Property(p => p.CreateTime).HasColumnType("DATETIME").HasValueGenerator((d,g)=>new CreatedTimeValueGenerator()).ValueGeneratedOnAddOrUpdate();
                entity.Property(p => p.Status).HasDefaultValue(0);
                entity.Property(p => p.Decimal).HasColumnType("decimal(18,4)");
                entity.Property(p => p.Name).HasColumnType("VARCHAR(50)");
                entity.Property(p=>p.Char).HasColumnType("CHAR(1)");
                //TODO:建立非唯一聚集索引
                entity.HasIndex(p => new {Name = p.Name,Char=p.Char}).IsUnique();
                //TODO:修改实体时就会自动生成值
                //entity.Property(p => p.Id).ValueGeneratedOnUpdate();
                var navigation = modelBuilder.Entity<Student>().Metadata.FindNavigation(nameof(Student.Courses));
                navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
                entity.HasMany(m => m.Courses).WithOne(o => o.Student);
                entity.Property<DateTime>("CreateTime");
            });
            modelBuilder.HasSequence<int>("SQLSequence").StartsAt(1000).IncrementsBy(2);
            //modelBuilder.Entity<Customer>().OwnsOne(c => c.WorkAddress).ToTable("CustomerWorkAddress");
            //modelBuilder.Entity<Customer>().HasQueryFilter(d => !d.IsDeleted);
            //modelBuilder.Entity<Post>().HasQueryFilter(b => !b.IsDeleted);
            //modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.IsDeleted);
            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().GetTypeInfo().Assembly);
            modelBuilder.Model.GetEntityTypes().Where(entntiyType=>typeof(ISoftDeleteBaseEntity).IsAssignableFrom(entntiyType.ClrType)).ToList().ForEach(
                entityType =>
                {
                    modelBuilder.Entity(entityType.ClrType).Property<Boolean>("IsDeleted");
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var body = Expression.Equal(Expression.Call(typeof(EF), nameof(EF.Property), new[] {typeof(bool)},
                        parameter, Expression.Constant("IsDeleted")), Expression.Constant(false));
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body,parameter));
                });


            //Expression<Func<ISoftDeleteBaseEntity, bool>> expression = e => !e.IsDeleted;
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e=>typeof(ISoftDeleteBaseEntity).IsAssignableFrom(e.ClrType)))
            //{
            //    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(expression);
            //}
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            modelBuilder.ApplyConfiguration(new CreditcardPaymentConfiguration());
            modelBuilder.ApplyConfiguration(new CashPaymentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<CashPayment> CashPayments { get; set; }

        public DbSet<CreditcardPayment> creditcardPayments { get; set; }

        
    } 
}
