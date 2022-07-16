using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class Requests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdditionalContacts = table.Column<string>(type: "TEXT", nullable: false),
                    RequesterId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentRequests_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentRequests_AspNetUsers_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentRequests_ApartmentId",
                table: "ApartmentRequests",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentRequests_RequesterId",
                table: "ApartmentRequests",
                column: "RequesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentRequests");
        }
    }
}
