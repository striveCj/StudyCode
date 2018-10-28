﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EF.Data.Conventions;

namespace EF.Core.Data
{
    public class EFDbContext:DbContext
    {
        public EFDbContext():base("name=DbConnectionString")
        {

        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateConvention());
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace)).Where(type =>
                    type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() ==
                    typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
