using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class HotelFlightConfiguration:DbConfiguration
    {
        public HotelFlightConfiguration()
        {
            SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<HotelDBContext>());
            SetDatabaseInitializer(new DropCreateDatabaseIfModelChanges<FlightDBContext>());
        }
    }
}
