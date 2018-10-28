using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Core;
using EF.Core.Data;

namespace EF.Data
{
    public class Repository<T> where T:BaseEntity
    {
        private readonly EFDbContext context;
        private IDbSet<T> entities;
        private string errorMessage = string.Empty;

        public Repository(EFDbContext context)
        {
            this.context = context;
        }

        public T GetById(object id)
        {
            return this.entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity==null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                this.entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage +=
                            $"Property:{validationError.PropertyName} Error:{validationError.ErrorMessage}" +
                            Environment.NewLine;
                    }
                    throw new Exception(errorMessage,dbEx);
                } 
            }
        }
        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage +=
                            $"Property:{validationError.PropertyName} Error:{validationError.ErrorMessage}" +
                            Environment.NewLine;
                    }
                    throw new Exception(errorMessage, dbEx);
                }
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                this.entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage +=
                            $"Property:{validationError.PropertyName} Error:{validationError.ErrorMessage}" +
                            Environment.NewLine;
                    }
                    throw new Exception(errorMessage, dbEx);
                }
            }
        }

        public virtual IQueryable<T> Table
        {
            get { return this.entities; }
        }

        public IDbSet<T> Entities
        {
            get
            {
                if (entities==null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
    }
}
