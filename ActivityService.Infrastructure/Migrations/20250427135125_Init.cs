using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Starttime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Endtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityFlds",
                columns: table => new
                {
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityFlds", x => x.FieldId);
                    table.ForeignKey(
                        name: "FK_ActivityFlds_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityRequests",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestFlds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_ActivityRequests_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "ActivityDescription", "ActivityType" },
                values: new object[,]
                {
                    { new Guid("31f31dc7-4656-4819-b375-bae80ad5e5a6"), "Làm việc từ xa", "Remote" },
                    { new Guid("89f25521-255d-4e1d-be1f-df31ec947f20"), "Book phòng họp", "Meeting" },
                    { new Guid("8b74e7d6-c7ac-4286-8510-dd8a20aa5656"), "Nghỉ phép cá nhân", "Leave" },
                    { new Guid("b4613af0-af0a-4884-83a5-a56de96a2fbf"), "Chấm công", "Attendance" }
                });

            migrationBuilder.InsertData(
                table: "Attendances",
                columns: new[] { "AttendanceId", "ActivityId", "AttendanceDate", "Description", "EmployeeId", "Endtime", "Position", "ProjectId", "Starttime", "Status" },
                values: new object[,]
                {
                    { new Guid("21ca0654-8f04-4684-856d-b2159aadd423"), new Guid("b4613af0-af0a-4884-83a5-a56de96a2fbf"), new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Worked on authentication module", new Guid("63e29a28-bc90-4cd1-8f9e-ab9834bdde6c"), new DateTime(2025, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), "Backend Developer", new Guid("550e8400-e29b-41d4-a716-446655440000"), new DateTime(2025, 4, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), "Present" },
                    { new Guid("68ed2ae8-56f0-49fd-98e6-b77934485bff"), new Guid("b4613af0-af0a-4884-83a5-a56de96a2fbf"), new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attended team meeting", new Guid("d05780d4-5742-40ca-8403-0febd44b1555"), new DateTime(2025, 4, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), "Scrum Master", new Guid("550e8400-e29b-41d4-a716-446655440000"), new DateTime(2025, 4, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Half-day" }
                });

            migrationBuilder.InsertData(
                table: "ActivityFlds",
                columns: new[] { "FieldId", "ActivityId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("4f4a1b2a-6573-4f10-b80d-63b288a865ef"), new Guid("8b74e7d6-c7ac-4286-8510-dd8a20aa5656"), "Lý do", "String" },
                    { new Guid("a397a21f-a317-4573-b7c5-aa80c54cf005"), new Guid("31f31dc7-4656-4819-b375-bae80ad5e5a6"), "Lý do", "String" },
                    { new Guid("bfcc713c-fa7f-4794-a11c-2548506504c2"), new Guid("8b74e7d6-c7ac-4286-8510-dd8a20aa5656"), "Ngày nghỉ", "Datetime" }
                });

            migrationBuilder.InsertData(
                table: "ActivityRequests",
                columns: new[] { "RequestId", "ActivityId", "CreatedAt", "EmployeeId", "RequestFlds", "Status" },
                values: new object[,]
                {
                    { new Guid("6d6609f9-00db-4024-bb44-dde901d6dd2a"), new Guid("89f25521-255d-4e1d-be1f-df31ec947f20"), new DateTime(2025, 4, 8, 14, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d05780d4-5742-40ca-8403-0febd44b1555"), "{\"MeetingRoom\":\"Room 402\"}", "Approved" },
                    { new Guid("b4359239-956b-403c-b118-b4d6dd7a0f68"), new Guid("31f31dc7-4656-4819-b375-bae80ad5e5a6"), new DateTime(2025, 4, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new Guid("63e29a28-bc90-4cd1-8f9e-ab9834bdde6c"), "{\"TaskName\":\"Implement JWT\",\"EstimatedHours\":8}", "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFlds_ActivityId",
                table: "ActivityFlds",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityRequests_ActivityId",
                table: "ActivityRequests",
                column: "ActivityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityFlds");

            migrationBuilder.DropTable(
                name: "ActivityRequests");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
