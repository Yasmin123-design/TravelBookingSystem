using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TravelBookingSystem.Models;
using TravelBookingSystem.Repository;

namespace TravelBookingSystem.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightRepository flight;
        public FlightController(IFlightRepository _flight)
        {
            flight = _flight;
        }
        public IActionResult Index()
        {
            List<Flight> flights = flight.GetAll();

            var fromLocations = flights.Select(f => f.From).Distinct().ToList();
            var toLocations = flights.Select(f => f.To).Distinct().ToList();

            // إرسال القيم إلى العرض
            ViewBag.FromLocations = fromLocations;
            ViewBag.ToLocations = toLocations;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId; // إضافة userId إلى ViewBag

            return View(flights);
        }
        public IActionResult Details(int id)
        {
            Flight oneflight = flight.Details(id);
            return View(oneflight);
        }
        [HttpPost]
        public IActionResult Search(string from , string to)
        {
            List<Flight> flights = flight.Search(from, to);
            if(flights.Count() == 0)
            {
                return View("not");
            }
            // إعادة استخدام البيانات السابقة للمواقع
            var fromLocations = flights.Select(f => f.From).Distinct().ToList();
            var toLocations = flights.Select(f => f.To).Distinct().ToList();

            // إرسال القيم إلى العرض
            ViewBag.FromLocations = fromLocations;
            ViewBag.ToLocations = toLocations;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;

            return View("Index",flights);
        }
        public IActionResult not()
        {
            return View();
        }
    }
}
