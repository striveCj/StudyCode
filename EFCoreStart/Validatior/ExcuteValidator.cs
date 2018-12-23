using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreStart.Validatior
{
    public static class Validators
    {
        public static List<ValidationResult> ExecuteValidator(this DbContext db)
        {
            var result =new List<ValidationResult>();
            foreach (var entitys in db.ChangeTracker.Entries().Where(e=>e.State==EntityState.Added||e.State==EntityState.Modified))
            {
                var entity = entitys.Entity;
                var valProvider =new ValidationDbContextServiceProvider(db);
                var valContext =new ValidationContext(db, valProvider,null);
                var valErroes=new List<ValidationResult>();
                if (!Validator.TryValidateObject(entity,valContext,valErroes,true))
                {
                    result.AddRange(valErroes);
                }
            }

            return result.ToList();
        }
    }
}
