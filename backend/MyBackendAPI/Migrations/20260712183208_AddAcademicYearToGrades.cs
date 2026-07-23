using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAcademicYearToGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcademicYear",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AcademicYear", "Semester" },
                values: new object[] { "2023-2024", 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AcademicYear", "Semester" },
                values: new object[] { "2023-2024", 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AcademicYear", "Semester" },
                values: new object[] { "2023-2024", 1 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 4, "2023-2024", 9.0, 1, 8.5, 8.5, 8.5, 9.0, 9.0, 9.0, 2, 3, 1 },
                    { 5, "2023-2024", 10.0, 1, 7.0, 8.0, 8.5, 8.0, 8.0, 8.0, 2, 4, 1 },
                    { 6, "2023-2024", 10.0, 1, 10.0, 10.0, 9.0, 9.0, 9.0, 10.0, 2, 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Grades");
        }
    }
}
