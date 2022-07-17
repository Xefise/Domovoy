using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class ServicesMtM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ApartmentServices_ApartmentServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_InformerServices_InformerServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentServices_Apartments_ApartmentId",
                table: "ApartmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_InformerServices_Apartments_ApartmentId",
                table: "InformerServices");

            migrationBuilder.DropIndex(
                name: "IX_InformerServices_ApartmentId",
                table: "InformerServices");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentServices_ApartmentId",
                table: "ApartmentServices");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_ApartmentServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_InformerServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "InformerServices");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "ApartmentServices");

            migrationBuilder.DropColumn(
                name: "ApartmentServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "InformerServiceId",
                table: "ApartmentHouses");

            migrationBuilder.CreateTable(
                name: "ApartmentHouseApartmentService",
                columns: table => new
                {
                    ApartmentServicesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScopeHousesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentHouseApartmentService", x => new { x.ApartmentServicesId, x.ScopeHousesId });
                    table.ForeignKey(
                        name: "FK_ApartmentHouseApartmentService_ApartmentHouses_ScopeHousesId",
                        column: x => x.ScopeHousesId,
                        principalTable: "ApartmentHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentHouseApartmentService_ApartmentServices_ApartmentServicesId",
                        column: x => x.ApartmentServicesId,
                        principalTable: "ApartmentServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentHouseInformerService",
                columns: table => new
                {
                    InformerServicesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScopeHousesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentHouseInformerService", x => new { x.InformerServicesId, x.ScopeHousesId });
                    table.ForeignKey(
                        name: "FK_ApartmentHouseInformerService_ApartmentHouses_ScopeHousesId",
                        column: x => x.ScopeHousesId,
                        principalTable: "ApartmentHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentHouseInformerService_InformerServices_InformerServicesId",
                        column: x => x.InformerServicesId,
                        principalTable: "InformerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouseApartmentService_ScopeHousesId",
                table: "ApartmentHouseApartmentService",
                column: "ScopeHousesId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouseInformerService_ScopeHousesId",
                table: "ApartmentHouseInformerService",
                column: "ScopeHousesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentHouseApartmentService");

            migrationBuilder.DropTable(
                name: "ApartmentHouseInformerService");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "InformerServices",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "ApartmentServices",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentServiceId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InformerServiceId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformerServices_ApartmentId",
                table: "InformerServices",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices_ApartmentId",
                table: "ApartmentServices",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_ApartmentServiceId",
                table: "ApartmentHouses",
                column: "ApartmentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_InformerServiceId",
                table: "ApartmentHouses",
                column: "InformerServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ApartmentServices_ApartmentServiceId",
                table: "ApartmentHouses",
                column: "ApartmentServiceId",
                principalTable: "ApartmentServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_InformerServices_InformerServiceId",
                table: "ApartmentHouses",
                column: "InformerServiceId",
                principalTable: "InformerServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentServices_Apartments_ApartmentId",
                table: "ApartmentServices",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InformerServices_Apartments_ApartmentId",
                table: "InformerServices",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }
    }
}
