namespace TravelBookingSystem.Service
{
    public interface IEmailService
    {
        Task SendEmailAsyn(string email, string subject, string message);
    }
}
