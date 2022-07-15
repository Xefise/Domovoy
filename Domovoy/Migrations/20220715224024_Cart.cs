using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentApplicationUser1",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    TenantsWhoAddThisToCartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentApplicationUser1", x => new { x.CartId, x.TenantsWhoAddThisToCartId });
                    table.ForeignKey(
                        name: "FK_ApartmentApplicationUser1_Apartments_CartId",
                        column: x => x.CartId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentApplicationUser1_AspNetUsers_TenantsWhoAddThisToCartId",
                        column: x => x.TenantsWhoAddThisToCartId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentApplicationUser1_TenantsWhoAddThisToCartId",
                table: "ApartmentApplicationUser1",
                column: "TenantsWhoAddThisToCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentApplicationUser1");
        }
    }
}
