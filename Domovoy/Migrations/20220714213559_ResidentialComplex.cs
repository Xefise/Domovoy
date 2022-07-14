using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class ResidentialComplex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                table: "ApartmentHouses");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Apartments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelling",
                table: "Apartments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "Apartments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ConstructionCompanyId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ResidentialComplexId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResidentialComplex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ConstructionCompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialComplex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidentialComplex_ConstructionCompanies_ConstructionCompanyId",
                        column: x => x.ConstructionCompanyId,
                        principalTable: "ConstructionCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_ResidentialComplexId",
                table: "ApartmentHouses",
                column: "ResidentialComplexId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialComplex_ConstructionCompanyId",
                table: "ResidentialComplex",
                column: "ConstructionCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                table: "ApartmentHouses",
                column: "ConstructionCompanyId",
                principalTable: "ConstructionCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ResidentialComplex_ResidentialComplexId",
                table: "ApartmentHouses",
                column: "ResidentialComplexId",
                principalTable: "ResidentialComplex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                table: "ApartmentHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ResidentialComplex_ResidentialComplexId",
                table: "ApartmentHouses");

            migrationBuilder.DropTable(
                name: "ResidentialComplex");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_ResidentialComplexId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "IsSelling",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ResidentialComplexId",
                table: "ApartmentHouses");

            migrationBuilder.AlterColumn<int>(
                name: "ConstructionCompanyId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_ConstructionCompanies_ConstructionCompanyId",
                table: "ApartmentHouses",
                column: "ConstructionCompanyId",
                principalTable: "ConstructionCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
