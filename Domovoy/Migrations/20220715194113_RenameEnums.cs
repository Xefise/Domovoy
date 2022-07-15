using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class RenameEnums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AparmentType",
                table: "Apartments",
                newName: "ApartmentType");

            migrationBuilder.RenameColumn(
                name: "AparmentState",
                table: "Apartments",
                newName: "ApartmentState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApartmentType",
                table: "Apartments",
                newName: "AparmentType");

            migrationBuilder.RenameColumn(
                name: "ApartmentState",
                table: "Apartments",
                newName: "AparmentState");
        }
    }
}
