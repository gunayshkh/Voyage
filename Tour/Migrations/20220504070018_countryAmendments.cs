using Microsoft.EntityFrameworkCore.Migrations;

namespace Voyage.Migrations
{
    public partial class countryAmendments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Trips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Cities_CityId",
                table: "Trips",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
