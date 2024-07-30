using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAC_Task.Migrations
{
    /// <inheritdoc />
    public partial class DbInitialized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingMinutesMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorporateCustomerId = table.Column<int>(type: "int", nullable: true),
                    IndividualCustomerId = table.Column<int>(type: "int", nullable: true),
                    MeetingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discussion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingMinutesMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingMinutesMasters_CorporateCustomers_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "CorporateCustomers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeetingMinutesMasters_IndividualCustomers_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "IndividualCustomers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeetingMinutesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingMinutesMasterId = table.Column<int>(type: "int", nullable: false),
                    ProductServiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingMinutesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingMinutesDetails_MeetingMinutesMasters_MeetingMinutesMasterId",
                        column: x => x.MeetingMinutesMasterId,
                        principalTable: "MeetingMinutesMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingMinutesDetails_ProductServices_ProductServiceId",
                        column: x => x.ProductServiceId,
                        principalTable: "ProductServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutesDetails_MeetingMinutesMasterId",
                table: "MeetingMinutesDetails",
                column: "MeetingMinutesMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutesDetails_ProductServiceId",
                table: "MeetingMinutesDetails",
                column: "ProductServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutesMasters_CorporateCustomerId",
                table: "MeetingMinutesMasters",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingMinutesMasters_IndividualCustomerId",
                table: "MeetingMinutesMasters",
                column: "IndividualCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingMinutesDetails");

            migrationBuilder.DropTable(
                name: "MeetingMinutesMasters");

            migrationBuilder.DropTable(
                name: "ProductServices");

            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");
        }
    }
}
