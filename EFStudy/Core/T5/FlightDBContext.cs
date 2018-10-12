using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    [DbConfigurationType(typeof(HotelFlightConfiguration))]
    public class FlightDBContext:DbContext
    {
        public FlightDBContext() : base("name=flightConnection")
        {

        }
        public DbSet<FlightBooking> FlightBookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FlightBookingMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
