using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTeacher2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "TOAN 10", 100 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "TOAN 10", 100 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "TOAN 10", 100 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "TOAN 10", 100 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "PRN211", 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "SWT301", 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "PRN211", 2 });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SubjectCode", "TeacherId" },
                values: new object[] { "PEA208", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "ResetPasswordOtp", "ResetPasswordOtpExpiry", "StudentId" },
                values: new object[] { 2, null, null, null, "teacher@example.com", "Giảng viên A", "password123", "0333333333", null, null, "FPT123" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 3, 2 });
        }
    }
}
