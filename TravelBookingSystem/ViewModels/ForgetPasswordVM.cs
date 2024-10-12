using System.ComponentModel.DataAnnotations;

namespace TravelBookingSystem.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
