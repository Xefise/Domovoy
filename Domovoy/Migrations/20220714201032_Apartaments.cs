using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class Apartaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConstructionCompanyId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainApartmentId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ConstructionCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    ConstructionCompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentHouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                        column: x => x.ConstructionCompanyId,
                        principalTable: "ConstructionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseEntrances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EnranceNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentHouseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseEntrances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseEntrances_ApartmentHouses_ApartmentHouseId",
                        column: x => x.ApartmentHouseId,
                        principalTable: "ApartmentHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApartmentNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    Area = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: true),
                    Cost = table.Column<int>(type: "INTEGER", nullable: true),
                    HouseEntranceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartments_HouseEntrances_HouseEntranceId",
                        column: x => x.HouseEntranceId,
                        principalTable: "HouseEntrances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentApplicationUser",
                columns: table => new
                {
                    ApartmentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TenantsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentApplicationUser", x => new { x.ApartmentsId, x.TenantsId });
                    table.ForeignKey(
                        name: "FK_ApartmentApplicationUser_Apartments_ApartmentsId",
                        column: x => x.ApartmentsId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentApplicationUser_AspNetUsers_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ConstructionCompanyId",
                table: "AspNetUsers",
                column: "ConstructionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MainApartmentId",
                table: "AspNetUsers",
                column: "MainApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentApplicationUser_TenantsId",
                table: "ApartmentApplicationUser",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_ConstructionCompanyId",
                table: "ApartmentHouses",
                column: "ConstructionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HouseEntranceId",
                table: "Apartments",
                column: "HouseEntranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_OwnerId",
                table: "Apartments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseEntrances_ApartmentHouseId",
                table: "HouseEntrances",
                column: "ApartmentHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Apartments_MainApartmentId",
                table: "AspNetUsers",
                column: "MainApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ConstructionCompanies_ConstructionCompanyId",
                table: "AspNetUsers",
                column: "ConstructionCompanyId",
                principalTable: "ConstructionCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Apartments_MainApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ConstructionCompanies_ConstructionCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApartmentApplicationUser");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "HouseEntrances");

            migrationBuilder.DropTable(
                name: "ApartmentHouses");

            migrationBuilder.DropTable(
                name: "ConstructionCompanies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ConstructionCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MainApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConstructionCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MainApartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");
        }
    }
}
