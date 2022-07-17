using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domovoy.Migrations
{
    public partial class Services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ApartmentServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerivceProviderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentServices_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartmentServices_AspNetUsers_SerivceProviderId",
                        column: x => x.SerivceProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformerServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerivceProviderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformerServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformerServices_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformerServices_AspNetUsers_SerivceProviderId",
                        column: x => x.SerivceProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserMustHaveAnApartment = table.Column<bool>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerivceProviderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserServices_AspNetUsers_SerivceProviderId",
                        column: x => x.SerivceProviderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentServiceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    Compleated = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentServiceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentServiceEntries_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartmentServiceEntries_ApartmentServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ApartmentServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentServiceEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InformerServiceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    Compleated = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformerServiceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformerServiceEntries_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformerServiceEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InformerServiceEntries_InformerServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "InformerServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserServiceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    Compleated = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserServiceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserServiceEntries_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserServiceEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserServiceEntries_UserServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "UserServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_ApartmentServiceId",
                table: "ApartmentHouses",
                column: "ApartmentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentHouses_InformerServiceId",
                table: "ApartmentHouses",
                column: "InformerServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServiceEntries_ApartmentId",
                table: "ApartmentServiceEntries",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServiceEntries_ServiceId",
                table: "ApartmentServiceEntries",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServiceEntries_UserId",
                table: "ApartmentServiceEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices_ApartmentId",
                table: "ApartmentServices",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentServices_SerivceProviderId",
                table: "ApartmentServices",
                column: "SerivceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_InformerServiceEntries_ApartmentId",
                table: "InformerServiceEntries",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InformerServiceEntries_ServiceId",
                table: "InformerServiceEntries",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InformerServiceEntries_UserId",
                table: "InformerServiceEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InformerServices_ApartmentId",
                table: "InformerServices",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_InformerServices_SerivceProviderId",
                table: "InformerServices",
                column: "SerivceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServiceEntries_ApartmentId",
                table: "UserServiceEntries",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServiceEntries_ServiceId",
                table: "UserServiceEntries",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServiceEntries_UserId",
                table: "UserServiceEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserServices_SerivceProviderId",
                table: "UserServices",
                column: "SerivceProviderId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_ApartmentServices_ApartmentServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentHouses_InformerServices_InformerServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropTable(
                name: "ApartmentServiceEntries");

            migrationBuilder.DropTable(
                name: "InformerServiceEntries");

            migrationBuilder.DropTable(
                name: "UserServiceEntries");

            migrationBuilder.DropTable(
                name: "ApartmentServices");

            migrationBuilder.DropTable(
                name: "InformerServices");

            migrationBuilder.DropTable(
                name: "UserServices");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_ApartmentServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentHouses_InformerServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "ApartmentServiceId",
                table: "ApartmentHouses");

            migrationBuilder.DropColumn(
                name: "InformerServiceId",
                table: "ApartmentHouses");
        }
    }
}
