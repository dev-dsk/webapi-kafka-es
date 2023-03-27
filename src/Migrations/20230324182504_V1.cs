using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Permissions.API.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeForename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    PermissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionType",
                        column: x => x.PermissionType,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "FullControl" },
                    { 2, "Read" },
                    { 3, "Write" },
                    { 4, "Delete" },
                    { 5, "List" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EmployeeForename", "EmployeeSurname", "PermissionDate", "PermissionType" },
                values: new object[,]
                {
                    { 1, "John", "Doe", new DateTime(2023, 3, 24, 13, 25, 4, 196, DateTimeKind.Local).AddTicks(3265), 1 },
                    { 2, "Mark", "Smith", new DateTime(2023, 3, 24, 13, 24, 4, 196, DateTimeKind.Local).AddTicks(3281), 2 },
                    { 3, "Jane", "Doe", new DateTime(2023, 3, 24, 13, 21, 4, 196, DateTimeKind.Local).AddTicks(3289), 3 },
                    { 4, "Mary", "Coptom", new DateTime(2023, 3, 24, 13, 20, 4, 196, DateTimeKind.Local).AddTicks(3290), 4 },
                    { 5, "John", "Carpenter", new DateTime(2023, 3, 24, 13, 15, 4, 196, DateTimeKind.Local).AddTicks(3292), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionType",
                table: "Permissions",
                column: "PermissionType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTypes");
        }
    }
}
