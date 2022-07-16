using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class SmartHomeDevices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartHomeDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SmartHomeDeviceType = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartHomeDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartHomeDevices_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmartHomeDeviceActionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Perfomed = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActionId = table.Column<string>(type: "TEXT", nullable: false),
                    SmartHomeDeviceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartHomeDeviceActionLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartHomeDeviceActionLog_SmartHomeDevices_SmartHomeDeviceId",
                        column: x => x.SmartHomeDeviceId,
                        principalTable: "SmartHomeDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmartHomeDeviceActionLog_SmartHomeDeviceId",
                table: "SmartHomeDeviceActionLog",
                column: "SmartHomeDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartHomeDevices_ApartmentId",
                table: "SmartHomeDevices",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartHomeDeviceActionLog");

            migrationBuilder.DropTable(
                name: "SmartHomeDevices");
        }
    }
}
