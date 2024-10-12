using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelBookingSystem.Models;
using TravelBookingSystem.Repository;

namespace TravelBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository booking;
        private readonly IFlightRepository flightRepository;
        public BookingController(IBookingRepository _booking , IFlightRepository _flightRepository)
        {
            booking = _booking;
            flightRepository = _flightRepository;
        }
        [HttpPost]
        public IActionResult Book(int tripid , string userid)
        {
            Flight flight = flightRepository.Details(tripid);
            Booking getone = booking.GetBooking(tripid, userid);

            if (flight == null || flight.AvailableSeats <= 0)
            {
                return RedirectToAction("NotSeats");
            }
            
            if (getone != null)
            {
                return RedirectToAction("AlreadyBooking");
            }

            flight.AvailableSeats -= 1;
            booking.Book(tripid, userid);
            return RedirectToAction("MyBooking");

        }
        public IActionResult NotSeats()
        {
            return View();
        }
        public IActionResult AlreadyBooking()
        {
            return View();
        }
        public IActionResult MyBooking()
        {
            // الحصول على userId من معلومات المستخدم
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Booking> userbooking = booking.MyBooking(userId);
            return View(userbooking);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Flight flight = flightRepository.Details(id);
            flight.AvailableSeats += 1;
            booking.Delete(id, userId);
            return RedirectToAction("MyBooking");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
