using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class HouseChatOtO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_ApartmentHouses_ApartmentHouseId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ApartmentHouseId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "ApartmentHouseId",
                table: "Chats");

            migrationBuilder.AddColumn<int>(
                name: "HouseChatId",
                table: "ApartmentHouses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_HouseChatId",
                table: "ApartmentHouses",
                column: "HouseChatId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentHouses_Chats_HouseChatId",
                table: "ApartmentHouses",
                column: "HouseChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_Chats_HouseChatId",
                table: "ApartmentHouses");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_HouseChatId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "HouseChatId",
                table: "ApartmentHouses");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentHouseId",
                table: "Chats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ApartmentHouseId",
                table: "Chats",
                column: "ApartmentHouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_ApartmentHouses_ApartmentHouseId",
                table: "Chats",
                column: "ApartmentHouseId",
                principalTable: "ApartmentHouses",
                principalColumn: "Id");
        }
    }
}
