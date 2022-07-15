using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class ServicesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Apartments_ApartmentId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ApartmentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Check",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HasPaid",
                table: "Services");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Services",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ServiceApartmentId",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceUserId",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceApartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceApartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceApartment_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceApartment_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePaymentInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Check = table.Column<string>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    RepaymentTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePaymentInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePaymentInvoice_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceUser_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceUser_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceApartment_ApartmentId",
                table: "ServiceApartment",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceApartment_ServiceId",
                table: "ServiceApartment",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicePaymentInvoice_ServiceId",
                table: "ServicePaymentInvoice",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUser_ApplicationUserId",
                table: "ServiceUser",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUser_ServiceId",
                table: "ServiceUser",
                column: "ServiceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceApartment");

            migrationBuilder.DropTable(
                name: "ServicePaymentInvoice");

            migrationBuilder.DropTable(
                name: "ServiceUser");

            migrationBuilder.DropColumn(
                name: "ServiceApartmentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceUserId",
                table: "Services");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CloseDate",
                table: "Services",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Check",
                table: "Services",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasPaid",
                table: "Services",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApartmentId",
                table: "Services",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Apartments_ApartmentId",
                table: "Services",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
