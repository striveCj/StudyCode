using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFStudy.Core.T5
{
    public class ReservationMap:EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            ToTable("Reservations");
            HasKey(k => k.BookingId);
            Property(p => p.BookingId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Name).HasMaxLength(20);
            Property(p => p.BookingDate);
        }
    }
}
