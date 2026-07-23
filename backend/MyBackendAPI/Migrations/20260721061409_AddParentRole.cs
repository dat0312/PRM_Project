using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddParentRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6861));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6509));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6862));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6863));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6871));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 14, 7, 844, DateTimeKind.Utc).AddTicks(6874));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubjectId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubjectId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 1, 6 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7,
                column: "SubjectId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 1, 8 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9,
                column: "SubjectId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 1, 10 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11,
                column: "SubjectId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 1, 12 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 21, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 21, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 4 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 21, 5 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 6 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 21, 7 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 8 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 21, 9 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21, 10 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 21, 11 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId" },
                values: new object[] { 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1, 21 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 16 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 17 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 18 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 19 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 20 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 22 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 23 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 24 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 25 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 26 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 27 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 31 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 32 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 33 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 34 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 35 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 36 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 37 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 38 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 39 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 40 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 41 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2025-2026", 8.5, 7, 8.5, 8.5, 8.5, 8.5, 8.5, 8.5, 1, 42 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 4, "Parent" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 24 },
                    { 4, 25 },
                    { 4, 26 },
                    { 4, 27 },
                    { 4, 28 },
                    { 4, 29 },
                    { 4, 30 },
                    { 4, 31 },
                    { 4, 32 },
                    { 4, 33 },
                    { 4, 34 },
                    { 4, 35 },
                    { 4, 36 },
                    { 4, 37 },
                    { 4, 38 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 18 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 20 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 24 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 25 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 26 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 27 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 28 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 29 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 30 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 31 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 32 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 33 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 34 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 35 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 36 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 37 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 38 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6647));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6649));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6308));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6643));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6648));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6651));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 45, 21, 119, DateTimeKind.Utc).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubjectId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7,
                column: "SubjectId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9,
                column: "SubjectId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11,
                column: "SubjectId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Semester", "SubjectId" },
                values: new object[] { 2, 6 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 7 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 7 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 8 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 8 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 9 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 9 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 10 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 10 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 11 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3, 11 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "StudentId", "SubjectId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 3, 12 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId" },
                values: new object[] { 9.5, 1, 9.5, 9.5, 9.5, 9.5, 9.5, 9.5, 2, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 3 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 4 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 4 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 5 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 5 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 6 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 7 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 7 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 8 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 8 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 9 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 9 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 10 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 10 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 11 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 11 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 12 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "SubjectId" },
                values: new object[] { "2023-2024", 5.5, 10, 5.5, 5.5, 5.5, 5.5, 5.5, 5.5, 2, 12 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AcademicYear", "AttendanceScore", "ClassId", "FifteenMinScore1", "FifteenMinScore2", "FinalScore", "MidtermScore", "OralScore1", "OralScore2", "Semester", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { 49, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 16 },
                    { 50, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 16 },
                    { 51, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 17 },
                    { 52, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 17 },
                    { 53, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 18 },
                    { 54, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 18 },
                    { 55, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 19 },
                    { 56, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 19 },
                    { 57, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 20 },
                    { 58, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 20 },
                    { 59, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 21 },
                    { 60, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 21 },
                    { 61, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 22 },
                    { 62, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 22 },
                    { 63, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 23 },
                    { 64, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 23 },
                    { 65, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 24 },
                    { 66, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 24 },
                    { 67, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 25 },
                    { 68, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 25 },
                    { 69, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 26 },
                    { 70, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 26 },
                    { 71, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 1, 21, 27 },
                    { 72, "2024-2025", 7.0, 11, 7.0, 7.0, 7.0, 7.0, 7.0, 7.0, 2, 21, 27 },
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
        }
    }
}
