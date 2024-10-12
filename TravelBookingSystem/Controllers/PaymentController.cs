using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Security.Claims;
using TravelBookingSystem.Models;
using TravelBookingSystem.Repository;

namespace TravelBookingSystem.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IBookingRepository booking;
        public PaymentController(IBookingRepository _booking)
        {
            booking = _booking;
        }
        [HttpPost]
        public IActionResult Pay(int tripid , decimal amount)
        {
            ViewBag.Tripid = tripid;
            ViewBag.Userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Amount = amount;
            return View();
        }
        [HttpPost]
        public IActionResult ProcessPayment(int tripid ,string userid ,string cardName, string cardNumber, string expMonth, string expYear, string cvc, decimal amount)
        {
            // 1. تحقق من صحة بيانات الدفع (التحقق من رقم البطاقة، CVC...إلخ)
            if (string.IsNullOrEmpty(cardNumber) || string.IsNullOrEmpty(cvc))
            {
                // إذا كانت هناك مشكلة في البيانات المدخلة، نعيد المستخدم إلى صفحة الدفع مع رسالة خطأ
                ViewBag.ErrorMessage = "Please provide valid payment details.";
                return View("Pay");
            }

            // 2. تواصل مع بوابة الدفع (مثل Stripe) لتنفيذ عملية الدفع
            // في هذا المثال، سنفترض أنك تستخدم Stripe:
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100), // تحويل المبلغ إلى السنتات (Stripe يعمل بالسنتات)
                Currency = "usd", // يمكنك تعديل العملة حسب متطلباتك
                Description = "Flight booking payment",
                Source = "tok_visa", // هنا يجب وضع الـ Token الذي تحصل عليه من واجهة Stripe
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            // 3. تحقق من نجاح أو فشل عملية الدفع
            if (charge.Status == "succeeded")
            {
                booking.Delete(tripid, userid);
                // الدفع تم بنجاح، إعادة توجيه المستخدم إلى صفحة تأكيد الدفع أو رسالة نجاح
                return View("PaymentSuccess");
            }
            else
            {
                // إذا فشلت عملية الدفع، عرض رسالة خطأ للمستخدم
                ViewBag.ErrorMessage = "Payment failed. Please try again.";
                return View("Pay");
            }
        }
        public IActionResult PaymentSuccess()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
