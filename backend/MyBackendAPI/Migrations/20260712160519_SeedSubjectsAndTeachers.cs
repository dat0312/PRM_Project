using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedSubjectsAndTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "Grade", "Group", "Name" },
                values: new object[,]
                {
                    { 1, "TOÁN 10", 10, "Bắt buộc", "Toán học" },
                    { 2, "NGỮ 10", 10, "Bắt buộc", "Ngữ văn" },
                    { 3, "TIẾN 10", 10, "Bắt buộc", "Tiếng Anh" },
                    { 4, "VẬT 10", 10, "Tự nhiên", "Vật lý" },
                    { 5, "HÓA 10", 10, "Tự nhiên", "Hóa học" },
                    { 6, "SINH 10", 10, "Tự nhiên", "Sinh học" },
                    { 7, "LỊCH 10", 10, "Xã hội", "Lịch sử" },
                    { 8, "ĐỊA 10", 10, "Xã hội", "Địa lý" },
                    { 9, "GDCD 10", 10, "Xã hội", "GDCD" },
                    { 10, "TOÁN 11", 11, "Bắt buộc", "Toán học" },
                    { 11, "NGỮ 11", 11, "Bắt buộc", "Ngữ văn" },
                    { 12, "TIẾN 11", 11, "Bắt buộc", "Tiếng Anh" },
                    { 13, "VẬT 11", 11, "Tự nhiên", "Vật lý" },
                    { 14, "HÓA 11", 11, "Tự nhiên", "Hóa học" },
                    { 15, "SINH 11", 11, "Tự nhiên", "Sinh học" },
                    { 16, "LỊCH 11", 11, "Xã hội", "Lịch sử" },
                    { 17, "ĐỊA 11", 11, "Xã hội", "Địa lý" },
                    { 18, "GDCD 11", 11, "Xã hội", "GDCD" },
                    { 19, "TOÁN 12", 12, "Bắt buộc", "Toán học" },
                    { 20, "NGỮ 12", 12, "Bắt buộc", "Ngữ văn" },
                    { 21, "TIẾN 12", 12, "Bắt buộc", "Tiếng Anh" },
                    { 22, "VẬT 12", 12, "Tự nhiên", "Vật lý" },
                    { 23, "HÓA 12", 12, "Tự nhiên", "Hóa học" },
                    { 24, "SINH 12", 12, "Tự nhiên", "Sinh học" },
                    { 25, "LỊCH 12", 12, "Xã hội", "Lịch sử" },
                    { 26, "ĐỊA 12", 12, "Xã hội", "Địa lý" },
                    { 27, "GDCD 12", 12, "Xã hội", "GDCD" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "ResetPasswordOtp", "ResetPasswordOtpExpiry", "StudentId" },
                values: new object[,]
                {
                    { 100, null, null, null, "gv_bb@fpt.edu.vn", "Giáo viên Bắt buộc", "password123", "0333333100", null, null, "GVBB01" },
                    { 101, null, null, null, "gv_tn@fpt.edu.vn", "Giáo viên Tự nhiên", "password123", "0333333101", null, null, "GVTN01" },
                    { 102, null, null, null, "gv_xh@fpt.edu.vn", "Giáo viên Xã hội", "password123", "0333333102", null, null, "GVXH01" }
                });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 100 },
                    { 2, 100 },
                    { 3, 100 },
                    { 10, 100 },
                    { 11, 100 },
                    { 12, 100 },
                    { 19, 100 },
                    { 20, 100 },
                    { 21, 100 },
                    { 4, 101 },
                    { 5, 101 },
                    { 6, 101 },
                    { 13, 101 },
                    { 14, 101 },
                    { 15, 101 },
                    { 22, 101 },
                    { 23, 101 },
                    { 24, 101 },
                    { 7, 102 },
                    { 8, 102 },
                    { 9, 102 },
                    { 16, 102 },
                    { 17, 102 },
                    { 18, 102 },
                    { 25, 102 },
                    { 26, 102 },
                    { 27, 102 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 100 },
                    { 3, 101 },
                    { 3, 102 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 1, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 2, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 3, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 10, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 11, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 12, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 19, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 20, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 21, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 4, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 5, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 6, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 13, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 14, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 15, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 22, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 23, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 24, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 7, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 8, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 9, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 16, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 17, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 18, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 25, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 26, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 27, 102 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 100 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 101 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 102 });

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 102);
        }
    }
}
