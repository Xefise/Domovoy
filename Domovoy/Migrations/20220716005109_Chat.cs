using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class Chat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceApartment_Apartments_ApartmentId",
                table: "ServiceApartment");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceApartment_Services_ServiceId",
                table: "ServiceApartment");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUser_AspNetUsers_ApplicationUserId",
                table: "ServiceUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUser_Services_ServiceId",
                table: "ServiceUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceUser",
                table: "ServiceUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceApartment",
                table: "ServiceApartment");

            migrationBuilder.RenameTable(
                name: "ServiceUser",
                newName: "ServiceUsers");

            migrationBuilder.RenameTable(
                name: "ServiceApartment",
                newName: "ServiceApartments");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceUser_ServiceId",
                table: "ServiceUsers",
                newName: "IX_ServiceUsers_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceUser_ApplicationUserId",
                table: "ServiceUsers",
                newName: "IX_ServiceUsers_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceApartment_ServiceId",
                table: "ServiceApartments",
                newName: "IX_ServiceApartments_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceApartment_ApartmentId",
                table: "ServiceApartments",
                newName: "IX_ServiceApartments_ApartmentId");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceUsers",
                table: "ServiceUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceApartments",
                table: "ServiceApartments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ApartmentHouseId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_ApartmentHouses_ApartmentHouseId",
                        column: x => x.ApartmentHouseId,
                        principalTable: "ApartmentHouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    SentAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChatId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChatId",
                table: "AspNetUsers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AdministratorId",
                table: "Chats",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ApartmentHouseId",
                table: "Chats",
                column: "ApartmentHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_AuthorId",
                table: "Messages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Chats_ChatId",
                table: "AspNetUsers",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceApartments_Apartments_ApartmentId",
                table: "ServiceApartments",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceApartments_Services_ServiceId",
                table: "ServiceApartments",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsers_AspNetUsers_ApplicationUserId",
                table: "ServiceUsers",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsers_Services_ServiceId",
                table: "ServiceUsers",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Chats_ChatId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceApartments_Apartments_ApartmentId",
                table: "ServiceApartments");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceApartments_Services_ServiceId",
                table: "ServiceApartments");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsers_AspNetUsers_ApplicationUserId",
                table: "ServiceUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsers_Services_ServiceId",
                table: "ServiceUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChatId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceUsers",
                table: "ServiceUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceApartments",
                table: "ServiceApartments");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ServiceUsers",
                newName: "ServiceUser");

            migrationBuilder.RenameTable(
                name: "ServiceApartments",
                newName: "ServiceApartment");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceUsers_ServiceId",
                table: "ServiceUser",
                newName: "IX_ServiceUser_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceUsers_ApplicationUserId",
                table: "ServiceUser",
                newName: "IX_ServiceUser_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceApartments_ServiceId",
                table: "ServiceApartment",
                newName: "IX_ServiceApartment_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceApartments_ApartmentId",
                table: "ServiceApartment",
                newName: "IX_ServiceApartment_ApartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceUser",
                table: "ServiceUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceApartment",
                table: "ServiceApartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceApartment_Apartments_ApartmentId",
                table: "ServiceApartment",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceApartment_Services_ServiceId",
                table: "ServiceApartment",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUser_AspNetUsers_ApplicationUserId",
                table: "ServiceUser",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUser_Services_ServiceId",
                table: "ServiceUser",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
