using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationAndGradeTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelatedRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "ResetPasswordOtp", "ResetPasswordOtpExpiry", "StudentId" },
                values: new object[,]
                {
                    { 103, null, null, null, "gv_khoi10@fpt.edu.vn", "Giáo viên Khối 10", "password123", "0333333103", null, null, "GVK10" },
                    { 104, null, null, null, "gv_khoi11@fpt.edu.vn", "Giáo viên Khối 11", "password123", "0333333104", null, null, "GVK11" },
                    { 105, null, null, null, "gv_khoi12@fpt.edu.vn", "Giáo viên Khối 12", "password123", "0333333105", null, null, "GVK12" }
                });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 103 },
                    { 2, 103 },
                    { 3, 103 },
                    { 4, 103 },
                    { 5, 103 },
                    { 6, 103 },
                    { 7, 103 },
                    { 8, 103 },
                    { 9, 103 },
                    { 10, 104 },
                    { 11, 104 },
                    { 12, 104 },
                    { 13, 104 },
                    { 14, 104 },
                    { 15, 104 },
                    { 16, 104 },
                    { 17, 104 },
                    { 18, 104 },
                    { 19, 105 },
                    { 20, 105 },
                    { 21, 105 },
                    { 22, 105 },
                    { 23, 105 },
                    { 24, 105 },
                    { 25, 105 },
                    { 26, 105 },
                    { 27, 105 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 103 },
                    { 3, 104 },
                    { 3, 105 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 1, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 2, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 3, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 4, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 5, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 6, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 7, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 8, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 9, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 10, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 11, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 12, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 13, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 14, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 15, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 16, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 17, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 18, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 19, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 20, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 21, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 22, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 23, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 24, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 25, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 26, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 27, 105 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 103 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 104 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 105 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 105);
        }
    }
}
