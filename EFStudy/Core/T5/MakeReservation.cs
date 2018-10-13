using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EFStudy.Core.T5
{
    public class MakeReservation
    {
        FlightDBContext flight;
        HotelDBContext hotel;
        public MakeReservation()
        {
            flight = new FlightDBContext();
            hotel = new HotelDBContext();
        }

        public bool ReservTrip(TripReservation trip)
        {
            bool reserved = false;
            using (var scope=new TransactionScope(TransactionScopeOption.RequiredNew))
            {
                try
                {
                    flight.FlightBookings.Add(trip.Filght);
                    flight.SaveChanges();

                    hotel.Reservations.Add(trip.Hotel);
                    hotel.SaveChanges();
                    reserved = true;
                    scope.Complete();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return reserved;
        }
    }
}
