﻿namespace TravelBookingSystem.ViewModels
{
    public class ResetPasswordVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; } // رمز التحقق لإعادة تعيين كلمة المرور
    }

}
