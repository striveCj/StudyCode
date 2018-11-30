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
    public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(k => k.PaymentId);

            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property<string>("Type").HasMaxLength(15);

            builder.HasDiscriminator<string>("Type").HasValue<CashPayment>("Cash")
                .HasValue<CreditcardPayment>("CreditCard");
        }
    }
}
