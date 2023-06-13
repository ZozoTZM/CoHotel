using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    /// <inheritdoc />
    public partial class RenameCapitalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxOccupancy",
                table: "Rooms",
                newName: "MaxOccupancy");

            migrationBuilder.RenameColumn(
                name: "currOccupancy",
                table: "Rooms",
                newName: "CurrOccupancy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxOccupancy",
                table: "Rooms",
                newName: "maxOccupancy");

            migrationBuilder.RenameColumn(
                name: "CurrOccupancy",
                table: "Rooms",
                newName: "currOccupancy");
        }
    }
}
