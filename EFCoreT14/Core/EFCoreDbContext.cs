using System;
using System.Linq;
using System.Reflection;
using EFCoreT14.Map;
using EFCoreT14.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreT14.Core
{
    public class EFCoreDbContext:DbContext
    {
        private Guid _tenantId;
        private readonly IEntityTypeProvider _entityTypeProvider;

        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options,ITenantProvider tenantProvider,IEntityTypeProvider entityTypeProvider):base(options)
        {
            _tenantId = tenantProvider.GetTenantId();
            _entityTypeProvider = entityTypeProvider;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());

            foreach (var type in _entityTypeProvider.GetEntityTypes())
            {
                var method = SetGlobalQueryMethod.MakeGenericMethod(type);
                method.Invoke(this, new object[] {modelBuilder});
            }
            base.OnModelCreating(modelBuilder);

        }

        private static readonly MethodInfo SetGlobalQueryMethod = typeof(EFCoreDbContext)
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

        public void SetGlobalQuery<T>(ModelBuilder builder) where T : BaseEntity
        {
            builder.Entity<T>().HasQueryFilter(e => e.TenantId == _tenantId && !e.IsDeleted);
        }
     
    } 
}
