using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudy.Core.T5
{
    public class TripReservation
    {
        public FlightBooking Filght { get; set; }

        public Reservation Hotel { get; set; }
    }
}
