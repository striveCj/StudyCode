using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    [DbConfigurationType(typeof(HotelFlightConfiguration))]
    public class HotelDBContext:DbContext
    {
        public HotelDBContext() : base("name=ReservationConnection")
        {

        }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReservationMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
