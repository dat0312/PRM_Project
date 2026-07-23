using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class HomeroomTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeroomTeacherId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "HomeroomTeacherId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                column: "HomeroomTeacherId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3,
                column: "HomeroomTeacherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4,
                column: "HomeroomTeacherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5,
                column: "HomeroomTeacherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6,
                column: "HomeroomTeacherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 7,
                column: "HomeroomTeacherId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 8,
                column: "HomeroomTeacherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 9,
                column: "HomeroomTeacherId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2" },
                values: new object[] { 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId" },
                values: new object[] { 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 9.5, 9.5, 9.5, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 3 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 7, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 4 },
                    { 8, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 4 },
                    { 9, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 5 },
                    { 10, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 5 },
                    { 11, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 6 },
                    { 12, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 6 },
                    { 13, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 7 },
                    { 14, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 7 },
                    { 15, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 8 },
                    { 16, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 8 },
                    { 17, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 9 },
                    { 18, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 9 },
                    { 19, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 10 },
                    { 20, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 10 },
                    { 21, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 11 },
                    { 22, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 11 },
                    { 23, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 1, 3, 12 },
                    { 24, "2023-2024", 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 12 },
                    { 25, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 1 },
                    { 26, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 1 },
                    { 27, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 2 },
                    { 28, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 2 },
                    { 29, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 3 },
                    { 30, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 3 },
                    { 31, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 4 },
                    { 32, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 4 },
                    { 33, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 5 },
                    { 34, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 5 },
                    { 35, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 6 },
                    { 36, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 6 },
                    { 37, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 7 },
                    { 38, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 7 },
                    { 39, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 8 },
                    { 40, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 8 },
                    { 41, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 9 },
                    { 42, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 9 },
                    { 43, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 10 },
                    { 44, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 10 },
                    { 45, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 11 },
                    { 46, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 11 },
                    { 47, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 12 },
                    { 48, "2023-2024", 5.5, 7, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 21, 12 },
                    { 49, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 16 },
                    { 50, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 16 },
                    { 51, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 17 },
                    { 52, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 17 },
                    { 53, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 18 },
                    { 54, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 18 },
                    { 55, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 19 },
                    { 56, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 19 },
                    { 57, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 20 },
                    { 58, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 20 },
                    { 59, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 21 },
                    { 60, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 21 },
                    { 61, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 22 },
                    { 62, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 22 },
                    { 63, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 23 },
                    { 64, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 23 },
                    { 65, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 24 },
                    { 66, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 24 },
                    { 67, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 25 },
                    { 68, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 25 },
                    { 69, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 26 },
                    { 70, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 26 },
                    { 71, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 27 },
                    { 72, "2024-2025", 7.0, 7, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 27 },
                    { 73, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 31 },
                    { 74, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 31 },
                    { 75, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 32 },
                    { 76, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 32 },
                    { 77, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 33 },
                    { 78, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 33 },
                    { 79, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 34 },
                    { 80, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 34 },
                    { 81, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 35 },
                    { 82, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 35 },
                    { 83, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 36 },
                    { 84, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 36 },
                    { 85, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 37 },
                    { 86, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 37 },
                    { 87, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 38 },
                    { 88, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 38 },
                    { 89, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 39 },
                    { 90, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 39 },
                    { 91, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 40 },
                    { 92, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 40 },
                    { 93, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 41 },
                    { 94, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 41 },
                    { 95, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 21, 42 },
                    { 96, "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 2, 21, 42 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_HomeroomTeacherId",
                table: "Classes",
                column: "HomeroomTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Users_HomeroomTeacherId",
                table: "Classes",
                column: "HomeroomTeacherId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Users_HomeroomTeacherId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_HomeroomTeacherId",
                table: "Classes");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DropColumn(
                name: "HomeroomTeacherId",
                table: "Classes");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2" },
                values: new object[] { 10.0, 7.5, 8.5, 9.0, 8.0, 8.0, 9.0 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId" },
                values: new object[] { 9.0, 8.0, 7.0, 8.0, 7.5, 7.0, 8.0, 1, 4 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 10.0, 9.0, 10.0, 10.0, 5, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { 9.0, 8.5, 8.5, 8.5, 9.0, 9.0, 9.0, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 10.0, 7.0, 8.0, 8.5, 8.0, 8.0, 8.0, 2, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AttendanceScore", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 10.0, 10.0, 10.0, 9.0, 9.0, 9.0, 10.0, 5, 1 });
        }
    }
}
