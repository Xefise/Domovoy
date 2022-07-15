using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class AparmentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSelling",
                table: "Apartments",
                newName: "AparmentState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AparmentState",
                table: "Apartments",
                newName: "IsSelling");
        }
    }
}
