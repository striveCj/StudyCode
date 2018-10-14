using EFStudy.Core.T5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFStudy.Web.Controllers
{
    public class TripController : Controller
    {
        MakeReservation reserv;
        public TripController()
        {
            reserv = new MakeReservation();
        }
        // GET: Trip
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new TripReservation());
        }
        [HttpPost]
        public ActionResult Create(TripReservation tripinfo)
        {
            try
            {
                tripinfo.Filght.TravellingDate = DateTime.Now;
                tripinfo.Hotel.BookingDate = DateTime.Now;
                var res = reserv.ReservTrip(tripinfo);
                if (!res)
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Success");
        }
       
    }
}