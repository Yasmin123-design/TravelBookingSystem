using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Stripe;
using TravelBookingSystem.Models;
using TravelBookingSystem.Repository;
using TravelBookingSystem.Service;
using TravelBookingSystem.Service;

namespace TravelBookingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // إعداد خدمة البريد الإلكتروني
            builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSettings"));

            // جلب إعدادات البريد الإلكتروني من appsettings.json

            var emailSetting = new EmailSetting();
            builder.Configuration.GetSection("EmailSettings").Bind(emailSetting);

            // إضافة خدمة البريد الإلكتروني
            builder.Services.AddTransient<IEmailService>(provider =>
                new EmailService(emailSetting.SmtpServer, emailSetting.SmtpPort, emailSetting.SmtpUser, emailSetting.SmtpPass));


            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];


            builder.Services.AddDbContext<TravelSystemContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddScoped<IFlightRepository, FlightRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<TravelSystemContext>().AddDefaultTokenProviders(); // اعداد موفر الرموز token
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
