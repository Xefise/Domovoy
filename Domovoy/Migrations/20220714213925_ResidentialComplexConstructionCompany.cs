using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class ResidentialComplexConstructionCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                table: "ApartmentHouses");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_ConstructionCompanyId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "ConstructionCompanyId",
                table: "ApartmentHouses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConstructionCompanyId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_ConstructionCompanyId",
                table: "ApartmentHouses",
                column: "ConstructionCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                table: "ApartmentHouses",
                column: "ConstructionCompanyId",
                principalTable: "ConstructionCompanies",
                principalColumn: "Id");
        }
    }
}
