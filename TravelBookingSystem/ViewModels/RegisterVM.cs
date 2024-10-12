using System.ComponentModel.DataAnnotations;

namespace TravelBookingSystem.ViewModels
{
    public class RegisterVM
    {

        [Required]
        [MinLength(10)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MinLength(4)]
        public string Address { get; set; }
    }
}
