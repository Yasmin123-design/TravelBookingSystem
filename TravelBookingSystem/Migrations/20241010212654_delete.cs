using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
    table: "Flights",
    keyColumns: new[] { "From", "To", "Image", "Price", "TravelDate", "DepartureTime", "ArrivalTime" },
    keyValues: new object[,]
    {
        { "Cairo", "London", "/images/1.jpeg", 250.00m, new DateTime(2024, 11, 1), new TimeSpan(14, 30, 0), new TimeSpan(18, 45, 0) },
        { "New York", "Paris", "/images/2.jpeg", 400.00m, new DateTime(2024, 12, 10), new TimeSpan(7, 0, 0), new TimeSpan(11, 15, 0) },
        { "Tokyo", "Los Angeles", "/images/3.jpeg", 550.00m, new DateTime(2024, 10, 20), new TimeSpan(22, 15, 0), new TimeSpan(6, 30, 0) },
        { "Sydney", "Dubai", "/images/4.jpeg", 300.00m, new DateTime(2024, 11, 5), new TimeSpan(9, 0, 0), new TimeSpan(14, 15, 0) },
        { "Berlin", "Rome", "/images/5.jpeg", 180.00m, new DateTime(2024, 11, 25), new TimeSpan(13, 45, 0), new TimeSpan(15, 50, 0) },
        { "Madrid", "Lisbon", "/images/6.jpeg", 120.00m, new DateTime(2024, 12, 2), new TimeSpan(10, 0, 0), new TimeSpan(11, 30, 0) },
        { "Istanbul", "Athens", "/images/7.jpeg", 140.00m, new DateTime(2024, 12, 15), new TimeSpan(16, 0, 0), new TimeSpan(17, 40, 0) },
        { "Dubai", "Mumbai", "/images/8.jpeg", 200.00m, new DateTime(2024, 10, 30), new TimeSpan(12, 0, 0), new TimeSpan(16, 30, 0) },
        { "Toronto", "Vancouver", "/images/9.jpeg", 250.00m, new DateTime(2024, 11, 20), new TimeSpan(8, 30, 0), new TimeSpan(11, 45, 0) },
        { "Mexico City", "Miami", "/images/10.jpeg", 180.00m, new DateTime(2024, 11, 18), new TimeSpan(5, 45, 0), new TimeSpan(10, 0, 0) },
        { "Paris", "Cairo", "/images/11.jpeg", 220.00m, new DateTime(2024, 12, 1), new TimeSpan(12, 30, 0), new TimeSpan(16, 50, 0) },
        { "London", "Dubai", "/images/12.jpeg", 350.00m, new DateTime(2024, 12, 8), new TimeSpan(9, 0, 0), new TimeSpan(18, 0, 0) },
        { "Rome", "New York", "/images/13.jpeg", 500.00m, new DateTime(2024, 11, 7), new TimeSpan(6, 45, 0), new TimeSpan(14, 30, 0) },
        { "Lisbon", "Berlin", "/images/14.jpeg", 210.00m, new DateTime(2024, 12, 5), new TimeSpan(15, 0, 0), new TimeSpan(18, 20, 0) },
        { "Athens", "Madrid", "/images/15.jpeg", 170.00m, new DateTime(2024, 10, 29), new TimeSpan(11, 30, 0), new TimeSpan(14, 45, 0) },
        { "Mumbai", "Sydney", "/images/16.jpeg", 600.00m, new DateTime(2024, 12, 20), new TimeSpan(22, 0, 0), new TimeSpan(6, 15, 0) },
        { "Vancouver", "Tokyo", "/images/17.jpeg", 450.00m, new DateTime(2024, 11, 15), new TimeSpan(18, 30, 0), new TimeSpan(5, 45, 0) },
        { "Miami", "Mexico City", "/images/18.jpeg", 200.00m, new DateTime(2024, 10, 25), new TimeSpan(7, 0, 0), new TimeSpan(10, 30, 0) },
        { "Cairo", "Paris", "/images/19.jpeg", 300.00m, new DateTime(2024, 11, 22), new TimeSpan(14, 0, 0), new TimeSpan(18, 20, 0) },
        { "Dubai", "Sydney", "/images/20.jpeg", 650.00m, new DateTime(2024, 12, 18), new TimeSpan(23, 0, 0), new TimeSpan(10, 15, 0) }
    });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
