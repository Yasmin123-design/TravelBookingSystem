using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using TravelBookingSystem.Models;
using TravelBookingSystem.Service;
using TravelBookingSystem.ViewModels;

namespace TravelBookingSystem.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<ApplicationUser> manager;
        private readonly SignInManager<ApplicationUser> sign;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<ApplicationUser> _manager, SignInManager<ApplicationUser> _sign , IEmailService email)
        {
            manager = _manager;
            sign = _sign;
            _emailService = email;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterVM register)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = register.UserName,
                    Email = register.Email,
                    Address = register.Address,
                    PasswordHash = register.Password
                };
                // save in db
                IdentityResult result = await manager.CreateAsync(user,register.Password);
                if(result.Succeeded)
                {
                    // create cookie
                    await sign.SignInAsync(user, false);
                    return RedirectToAction("Home", "Flight");
                }
                else
                {
                    foreach (var item in result.Errors) // icollections
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }
            }
            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Login(LoginVM login)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser application = await manager.FindByNameAsync(login.UserName);
             
                if (application != null)
                {
                    bool found = await manager.CheckPasswordAsync(application, login.Password);
                    if (found)
                    {
                        // create cookie
                        await sign.SignInAsync(application, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "username or password not correct");
            }
            return View(login);
        
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult > ForgetPassword(ForgetPasswordVM forgetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = await manager.FindByEmailAsync(forgetPassword.Email);
                if (user.Email == null )
                {
                    // إذا كان المستخدم غير موجود أو لم يتم تأكيد البريد الإلكتروني
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                // إنشاء رمز إعادة تعيين كلمة المرور
                // امان من الهاكرز
                var token = await manager.GeneratePasswordResetTokenAsync(user);

              // إنشاء رابط إعادة التعيين
              // لما اتكى على الرابط هيودينى ل action دا
              // /Account/ResetPassword?token=<generated_token>&email=<user_email>
              // https://www.example.com/Account/ResetPassword?token=abc123&email=user@example.com

                var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);
                var message = $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>";


                await _emailService.SendEmailAsyn (user.Email, "Reset Password", callbackUrl);


                return RedirectToAction("ForgotPasswordConfirmation");
            }
            return View(forgetPassword);
        }
        [HttpGet]
        public IActionResult ResetPassword(string token = null , string email = null)
        {
            if(token == null || email == null)
            {
                return BadRequest("a token and email are required for password reset");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> ResetPassword(ResetPasswordVM resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPassword);
            }
            ApplicationUser application = await manager.FindByEmailAsync(resetPassword.Email);
            if (application != null)
            {
                // اعاده تكوين كلمه المرور
                var result = await manager.ResetPasswordAsync(application, resetPassword.Token, resetPassword.Password);
            }
            return RedirectToAction("ResetPasswordConfirmation");
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
        public IActionResult Logout()
        {
            sign.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
