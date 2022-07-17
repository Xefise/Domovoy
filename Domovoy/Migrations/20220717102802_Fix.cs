using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Compleated",
                table: "UserServiceEntries",
                newName: "Completed");

            migrationBuilder.RenameColumn(
                name: "Compleated",
                table: "InformerServiceEntries",
                newName: "Completed");

            migrationBuilder.RenameColumn(
                name: "Compleated",
                table: "ApartmentServiceEntries",
                newName: "Completed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "UserServiceEntries",
                newName: "Compleated");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "InformerServiceEntries",
                newName: "Compleated");

            migrationBuilder.RenameColumn(
                name: "Completed",
                table: "ApartmentServiceEntries",
                newName: "Compleated");
        }
    }
}
