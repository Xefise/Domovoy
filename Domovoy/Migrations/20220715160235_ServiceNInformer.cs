using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class ServiceNInformer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventInformer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InformertId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsNowActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInformer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformMeter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InformertId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    LastInformedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformMeter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Check = table.Column<string>(type: "TEXT", nullable: false),
                    HasPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermanentServiceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventInformerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActiveSession_EventInformer_EventInformerId",
                        column: x => x.EventInformerId,
                        principalTable: "EventInformer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastInform = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    InformMeterId = table.Column<int>(type: "INTEGER", nullable: true),
                    EventInformerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informers_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informers_EventInformer_EventInformerId",
                        column: x => x.EventInformerId,
                        principalTable: "EventInformer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Informers_InformMeter_InformMeterId",
                        column: x => x.InformMeterId,
                        principalTable: "InformMeter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermanentServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoPay = table.Column<bool>(type: "INTEGER", nullable: false),
                    Period = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermanentServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermanentServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveSession_EventInformerId",
                table: "ActiveSession",
                column: "EventInformerId");

            migrationBuilder.CreateIndex(
                name: "IX_Informers_ApartmentId",
                table: "Informers",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Informers_EventInformerId",
                table: "Informers",
                column: "EventInformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Informers_InformMeterId",
                table: "Informers",
                column: "InformMeterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermanentServices_ServiceId",
                table: "PermanentServices",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApartmentId",
                table: "Services",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveSession");

            migrationBuilder.DropTable(
                name: "Informers");

            migrationBuilder.DropTable(
                name: "PermanentServices");

            migrationBuilder.DropTable(
                name: "EventInformer");

            migrationBuilder.DropTable(
                name: "InformMeter");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
