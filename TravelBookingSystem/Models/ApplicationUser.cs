using Microsoft.AspNetCore.Identity;

namespace TravelBookingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
       
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
