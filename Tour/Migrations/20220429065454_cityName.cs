using Microsoft.EntityFrameworkCore.Migrations;

namespace Voyage.Migrations
{
    public partial class cityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuestCount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "GuestCount",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Bookings");
        }
    }
}
