using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class ResidentialComplexTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ResidentialComplex_ResidentialComplexId",
                table: "ApartmentHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialComplex_ConstructionCompanies_ConstructionCompanyId",
                table: "ResidentialComplex");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentialComplex",
                table: "ResidentialComplex");

            migrationBuilder.RenameTable(
                name: "ResidentialComplex",
                newName: "ResidentialComplexes");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentialComplex_ConstructionCompanyId",
                table: "ResidentialComplexes",
                newName: "IX_ResidentialComplexes_ConstructionCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentialComplexes",
                table: "ResidentialComplexes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ResidentialComplexes_ResidentialComplexId",
                table: "ApartmentHouses",
                column: "ResidentialComplexId",
                principalTable: "ResidentialComplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialComplexes_ConstructionCompanies_ConstructionCompanyId",
                table: "ResidentialComplexes",
                column: "ConstructionCompanyId",
                principalTable: "ConstructionCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ResidentialComplexes_ResidentialComplexId",
                table: "ApartmentHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ResidentialComplexes_ConstructionCompanies_ConstructionCompanyId",
                table: "ResidentialComplexes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentialComplexes",
                table: "ResidentialComplexes");

            migrationBuilder.RenameTable(
                name: "ResidentialComplexes",
                newName: "ResidentialComplex");

            migrationBuilder.RenameIndex(
                name: "IX_ResidentialComplexes_ConstructionCompanyId",
                table: "ResidentialComplex",
                newName: "IX_ResidentialComplex_ConstructionCompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentialComplex",
                table: "ResidentialComplex",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ResidentialComplex_ResidentialComplexId",
                table: "ApartmentHouses",
                column: "ResidentialComplexId",
                principalTable: "ResidentialComplex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResidentialComplex_ConstructionCompanies_ConstructionCompanyId",
                table: "ResidentialComplex",
                column: "ConstructionCompanyId",
                principalTable: "ConstructionCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
