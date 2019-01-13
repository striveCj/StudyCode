using EFCoreT14.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreT14.Core
{
    public class EFCoreDbContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Post>().HasQueryFilter(b => !b.IsDeleted);
        }
     
    } 
}
