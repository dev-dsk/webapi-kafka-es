using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Permissions.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPermissionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 6, "Deny" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 15, 29, 34, 234, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 15, 28, 34, 234, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 15, 25, 34, 234, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 15, 24, 34, 234, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 15, 19, 34, 234, DateTimeKind.Local).AddTicks(1504));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 13, 25, 4, 196, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 13, 24, 4, 196, DateTimeKind.Local).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 13, 21, 4, 196, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 13, 20, 4, 196, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "PermissionDate",
                value: new DateTime(2023, 3, 24, 13, 15, 4, 196, DateTimeKind.Local).AddTicks(3292));
        }
    }
}
