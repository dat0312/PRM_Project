using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValues: new object[] { 27, 102 });

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

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "TOAN 10", "Toán" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "NV 10");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Name" },
                values: new object[] { "NN1 10", "Ngoại ngữ 1 (Tiếng Anh)" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "LS 10", "Bắt buộc", "Lịch sử" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "GDTC 10", "Bắt buộc", "Giáo dục Thể chất" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "GDQPAN 10", "Bắt buộc", "Giáo dục Quốc phòng và An ninh" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "VL 10", "Lựa chọn (Tự nhiên)", "Vật lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "HH 10", "Lựa chọn (Tự nhiên)", "Hóa học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "SH 10", "Lựa chọn (Tự nhiên)", "Sinh học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "DL 10", 10, "Lựa chọn (Xã hội)", "Địa lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "GDKTPL 10", 10, "Lựa chọn (Xã hội)", "Giáo dục kinh tế và pháp luật" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "TH 10", 10, "Lựa chọn (Công nghệ & Nghệ thuật)", "Tin học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "CN 10", 10, "Lựa chọn (Công nghệ & Nghệ thuật)", "Công nghệ" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "AN 10", 10, "Lựa chọn (Công nghệ & Nghệ thuật)", "Âm nhạc" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "MT 10", 10, "Lựa chọn (Công nghệ & Nghệ thuật)", "Mỹ thuật" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "TOAN 11", "Bắt buộc", "Toán" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "NV 11", "Bắt buộc", "Ngữ văn" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "NN1 11", "Bắt buộc", "Ngoại ngữ 1 (Tiếng Anh)" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "Grade", "Name" },
                values: new object[] { "LS 11", 11, "Lịch sử" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Code", "Grade", "Name" },
                values: new object[] { "GDTC 11", 11, "Giáo dục Thể chất" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "Grade", "Name" },
                values: new object[] { "GDQPAN 11", 11, "Giáo dục Quốc phòng và An ninh" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "Grade", "Group" },
                values: new object[] { "VL 11", 11, "Lựa chọn (Tự nhiên)" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "Grade", "Group" },
                values: new object[] { "HH 11", 11, "Lựa chọn (Tự nhiên)" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "Grade", "Group" },
                values: new object[] { "SH 11", 11, "Lựa chọn (Tự nhiên)" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "DL 11", 11, "Lựa chọn (Xã hội)", "Địa lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "GDKTPL 11", 11, "Lựa chọn (Xã hội)", "Giáo dục kinh tế và pháp luật" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "TH 11", 11, "Lựa chọn (Công nghệ & Nghệ thuật)", "Tin học" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "Grade", "Group", "Name" },
                values: new object[,]
                {
                    { 28, "CN 11", 11, "Lựa chọn (Công nghệ & Nghệ thuật)", "Công nghệ" },
                    { 29, "AN 11", 11, "Lựa chọn (Công nghệ & Nghệ thuật)", "Âm nhạc" },
                    { 30, "MT 11", 11, "Lựa chọn (Công nghệ & Nghệ thuật)", "Mỹ thuật" },
                    { 31, "TOAN 12", 12, "Bắt buộc", "Toán" },
                    { 32, "NV 12", 12, "Bắt buộc", "Ngữ văn" },
                    { 33, "NN1 12", 12, "Bắt buộc", "Ngoại ngữ 1 (Tiếng Anh)" },
                    { 34, "LS 12", 12, "Bắt buộc", "Lịch sử" },
                    { 35, "GDTC 12", 12, "Bắt buộc", "Giáo dục Thể chất" },
                    { 36, "GDQPAN 12", 12, "Bắt buộc", "Giáo dục Quốc phòng và An ninh" },
                    { 37, "VL 12", 12, "Lựa chọn (Tự nhiên)", "Vật lý" },
                    { 38, "HH 12", 12, "Lựa chọn (Tự nhiên)", "Hóa học" },
                    { 39, "SH 12", 12, "Lựa chọn (Tự nhiên)", "Sinh học" },
                    { 40, "DL 12", 12, "Lựa chọn (Xã hội)", "Địa lý" },
                    { 41, "GDKTPL 12", 12, "Lựa chọn (Xã hội)", "Giáo dục kinh tế và pháp luật" },
                    { 42, "TH 12", 12, "Lựa chọn (Công nghệ & Nghệ thuật)", "Tin học" },
                    { 43, "CN 12", 12, "Lựa chọn (Công nghệ & Nghệ thuật)", "Công nghệ" },
                    { 44, "AN 12", 12, "Lựa chọn (Công nghệ & Nghệ thuật)", "Âm nhạc" },
                    { 45, "MT 12", 12, "Lựa chọn (Công nghệ & Nghệ thuật)", "Mỹ thuật" }
                });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 4, 100 },
                    { 5, 100 },
                    { 6, 100 },
                    { 13, 100 },
                    { 14, 100 },
                    { 15, 100 },
                    { 16, 100 },
                    { 17, 100 },
                    { 18, 100 },
                    { 27, 100 },
                    { 7, 101 },
                    { 8, 101 },
                    { 9, 101 },
                    { 10, 102 },
                    { 11, 102 },
                    { 10, 103 },
                    { 11, 103 },
                    { 12, 103 },
                    { 13, 103 },
                    { 14, 103 },
                    { 15, 103 },
                    { 19, 104 },
                    { 20, 104 },
                    { 21, 104 },
                    { 22, 104 },
                    { 23, 104 },
                    { 24, 104 },
                    { 25, 104 },
                    { 26, 104 },
                    { 27, 104 },
                    { 28, 100 },
                    { 29, 100 },
                    { 30, 100 },
                    { 31, 100 },
                    { 32, 100 },
                    { 33, 100 },
                    { 34, 100 },
                    { 35, 100 },
                    { 36, 100 },
                    { 42, 100 },
                    { 43, 100 },
                    { 44, 100 },
                    { 45, 100 },
                    { 37, 101 },
                    { 38, 101 },
                    { 39, 101 },
                    { 40, 102 },
                    { 41, 102 },
                    { 28, 104 },
                    { 29, 104 },
                    { 30, 104 },
                    { 31, 105 },
                    { 32, 105 },
                    { 33, 105 },
                    { 34, 105 },
                    { 35, 105 },
                    { 36, 105 },
                    { 37, 105 },
                    { 38, 105 },
                    { 39, 105 },
                    { 40, 105 },
                    { 41, 105 },
                    { 42, 105 },
                    { 43, 105 },
                    { 44, 105 },
                    { 45, 105 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 4, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 5, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 6, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 13, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 14, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 15, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 16, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 17, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 18, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 27, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 28, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 29, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 30, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 31, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 32, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 33, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 34, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 35, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 36, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 42, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 43, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 44, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 45, 100 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 7, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 8, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 9, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 37, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 38, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 39, 101 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 10, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 11, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 40, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 41, 102 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 10, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 11, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 12, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 13, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 14, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 15, 103 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 19, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 20, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 21, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 22, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 23, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 24, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 25, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 26, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 27, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 28, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 29, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 30, 104 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 31, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 32, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 33, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 34, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 35, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 36, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 37, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 38, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 39, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 40, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 41, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 42, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 43, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 44, 105 });

            migrationBuilder.DeleteData(
                table: "TeacherSubjects",
                keyColumns: new[] { "SubjectId", "TeacherId" },
                keyValues: new object[] { 45, 105 });

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Name" },
                values: new object[] { "TOÁN 10", "Toán học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "NGỮ 10");

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Code", "Name" },
                values: new object[] { "TIẾN 10", "Tiếng Anh" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "VẬT 10", "Tự nhiên", "Vật lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "HÓA 10", "Tự nhiên", "Hóa học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "SINH 10", "Tự nhiên", "Sinh học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "LỊCH 10", "Xã hội", "Lịch sử" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "ĐỊA 10", "Xã hội", "Địa lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "GDCD 10", "Xã hội", "GDCD" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "TOÁN 11", 11, "Bắt buộc", "Toán học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "NGỮ 11", 11, "Bắt buộc", "Ngữ văn" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "TIẾN 11", 11, "Bắt buộc", "Tiếng Anh" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "VẬT 11", 11, "Tự nhiên", "Vật lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "HÓA 11", 11, "Tự nhiên", "Hóa học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "SINH 11", 11, "Tự nhiên", "Sinh học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "LỊCH 11", "Xã hội", "Lịch sử" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "ĐỊA 11", "Xã hội", "Địa lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Code", "Group", "Name" },
                values: new object[] { "GDCD 11", "Xã hội", "GDCD" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Code", "Grade", "Name" },
                values: new object[] { "TOÁN 12", 12, "Toán học" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Code", "Grade", "Name" },
                values: new object[] { "NGỮ 12", 12, "Ngữ văn" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Code", "Grade", "Name" },
                values: new object[] { "TIẾN 12", 12, "Tiếng Anh" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Code", "Grade", "Group" },
                values: new object[] { "VẬT 12", 12, "Tự nhiên" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Code", "Grade", "Group" },
                values: new object[] { "HÓA 12", 12, "Tự nhiên" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Code", "Grade", "Group" },
                values: new object[] { "SINH 12", 12, "Tự nhiên" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "LỊCH 12", 12, "Xã hội", "Lịch sử" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "ĐỊA 12", 12, "Xã hội", "Địa lý" });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Code", "Grade", "Group", "Name" },
                values: new object[] { "GDCD 12", 12, "Xã hội", "GDCD" });

            migrationBuilder.InsertData(
                table: "TeacherSubjects",
                columns: new[] { "SubjectId", "TeacherId" },
                values: new object[,]
                {
                    { 10, 100 },
                    { 11, 100 },
                    { 4, 101 },
                    { 5, 101 },
                    { 6, 101 },
                    { 13, 101 },
                    { 14, 101 },
                    { 15, 101 },
                    { 7, 102 },
                    { 8, 102 },
                    { 9, 102 },
                    { 16, 102 },
                    { 17, 102 },
                    { 18, 102 },
                    { 27, 102 },
                    { 10, 104 },
                    { 11, 104 },
                    { 12, 104 },
                    { 13, 104 },
                    { 14, 104 },
                    { 15, 104 },
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
        }
    }
}
