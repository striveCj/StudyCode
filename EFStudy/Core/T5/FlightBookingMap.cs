using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
namespace EFStudy.Core.T5
{
    public class FlightBookingMap:EntityTypeConfiguration<FlightBooking>
    {
        public FlightBookingMap()
        {
            ToTable("FlightBookings");
            HasKey(k => k.FlightId);
            Property(p => p.FilghtName).HasMaxLength(50);
            Property(p => p.Number);
            Property(p => p.TravellingDate);
        }
    }
}
