using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyActivityRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ActivityRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ActivityRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ActivityRequests",
                keyColumn: "RequestId",
                keyValue: new Guid("6d6609f9-00db-4024-bb44-dde901d6dd2a"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ActivityRequests",
                keyColumn: "RequestId",
                keyValue: new Guid("b4359239-956b-403c-b118-b4d6dd7a0f68"),
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 4, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ActivityRequests");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ActivityRequests");
        }
    }
}
