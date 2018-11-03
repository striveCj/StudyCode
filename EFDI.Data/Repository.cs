using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDI.Core;

namespace EFDI.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private IDbSet<T> _entities;

        public Repository(DbContext context)
        {
            _context = context;
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (_entities==null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }
        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        public void Delete(T entity)
        {
            try
            {

                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }

                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var msg = string.Empty;

                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validtionError in validationErrors.ValidationErrors)
                    {
                        //TODO:在 Windows 环境中，C# 语言 Environment.NewLine == "\r\n" 结果为 true。
                        msg += string.Format(
                            $"Property:{validtionError.PropertyName} Error{validtionError.ErrorMessage}" +
                            Environment.NewLine);
                    }
                }
                var fail = new Exception(msg, e);
                throw fail;
            }
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {

                    if (entity==null)
                    {
                        throw new ArgumentNullException(nameof(entity));
                    }

                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var msg = string.Empty;

                    foreach (var validationErrors in e.EntityValidationErrors)
                    {
                        foreach (var validtionError in validationErrors.ValidationErrors)
                        {
                            //TODO:在 Windows 环境中，C# 语言 Environment.NewLine == "\r\n" 结果为 true。
                            msg += string.Format(
                                $"Property:{validtionError.PropertyName} Error{validtionError.ErrorMessage}" +
                                Environment.NewLine);
                        }
                    }
                var fail = new Exception(msg, e);
                throw fail;
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

                _context.Entry(entity).State=EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var msg = string.Empty;

                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validtionError in validationErrors.ValidationErrors)
                    {
                        //TODO:在 Windows 环境中，C# 语言 Environment.NewLine == "\r\n" 结果为 true。
                        msg += string.Format(
                            $"Property:{validtionError.PropertyName} Error{validtionError.ErrorMessage}" +
                            Environment.NewLine);
                    }
                }
                var fail = new Exception(msg, e);
                throw fail;
            }
        }
    }
}
