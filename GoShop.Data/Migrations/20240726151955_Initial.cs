using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobilePhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePhones_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MobilePhoneHardware",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Display = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Battery = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Camera = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MobilePhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhoneHardware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePhoneHardware_MobilePhones_MobilePhoneId",
                        column: x => x.MobilePhoneId,
                        principalTable: "MobilePhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobilePhoneSoftware",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OSVersion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirmwareVersion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsRootedOrJailbroken = table.Column<bool>(type: "bit", nullable: false),
                    LastSoftwareUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobilePhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePhoneSoftware", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePhoneSoftware_MobilePhones_MobilePhoneId",
                        column: x => x.MobilePhoneId,
                        principalTable: "MobilePhones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhoneHardware_MobilePhoneId",
                table: "MobilePhoneHardware",
                column: "MobilePhoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhones_UserEntityId",
                table: "MobilePhones",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MobilePhoneSoftware_MobilePhoneId",
                table: "MobilePhoneSoftware",
                column: "MobilePhoneId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobilePhoneHardware");

            migrationBuilder.DropTable(
                name: "MobilePhoneSoftware");

            migrationBuilder.DropTable(
                name: "MobilePhones");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
