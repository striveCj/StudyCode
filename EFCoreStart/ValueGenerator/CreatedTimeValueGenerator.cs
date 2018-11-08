using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace EFCoreStart.ValueGenerator
{
    public class CreatedTimeValueGenerator:Microsoft.EntityFrameworkCore.ValueGeneration.ValueGenerator
    {
        public override bool GeneratesTemporaryValues => false;
        public override object Next(EntityEntry entry)
        {
            return DateTime.Now;
        }

        protected override object NextValue(EntityEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
