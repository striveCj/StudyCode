using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreStart.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreStart.Configuration
{
    public class CashPaymentConfiguration:IEntityTypeConfiguration<CashPayment>
    {
        public void Configure(EntityTypeBuilder<CashPayment> builder)
        {
            builder.HasBaseType<Payment>();
        }
    }
}
