using Microsoft.EntityFrameworkCore.Migrations;

namespace Voyage.Migrations
{
    public partial class addInfo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripImage_Trips_TripId",
                table: "TripImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripImage",
                table: "TripImage");

            migrationBuilder.RenameTable(
                name: "TripImage",
                newName: "TripImages");

            migrationBuilder.RenameIndex(
                name: "IX_TripImage_TripId",
                table: "TripImages",
                newName: "IX_TripImages_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripImages",
                table: "TripImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripImages_Trips_TripId",
                table: "TripImages",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripImages_Trips_TripId",
                table: "TripImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripImages",
                table: "TripImages");

            migrationBuilder.RenameTable(
                name: "TripImages",
                newName: "TripImage");

            migrationBuilder.RenameIndex(
                name: "IX_TripImages_TripId",
                table: "TripImage",
                newName: "IX_TripImage_TripId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripImage",
                table: "TripImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripImage_Trips_TripId",
                table: "TripImage",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
