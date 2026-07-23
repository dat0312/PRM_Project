using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddParentUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4693));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4697));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4700));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4708));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4702));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4709));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4696));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 22, 58, 134, DateTimeKind.Utc).AddTicks(4710));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "DateOfBirth", "Email", "FullName", "LastReadNotificationTime", "Password", "PhoneNumber", "ResetPasswordOtp", "ResetPasswordOtpExpiry", "StudentId", "SubjectGroup" },
                values: new object[,]
                {
                    { 203, null, null, null, "parent3@fpt.edu.vn", "Phụ huynh của Student 3", null, "password123", "0800000003", null, null, null, null },
                    { 204, null, null, null, "parent4@fpt.edu.vn", "Phụ huynh của Student 4", null, "password123", "0800000004", null, null, null, null },
                    { 205, null, null, null, "parent5@fpt.edu.vn", "Phụ huynh của Student 5", null, "password123", "0800000005", null, null, null, null },
                    { 206, null, null, null, "parent6@fpt.edu.vn", "Phụ huynh của Student 6", null, "password123", "0800000006", null, null, null, null },
                    { 207, null, null, null, "parent7@fpt.edu.vn", "Phụ huynh của Student 7", null, "password123", "0800000007", null, null, null, null },
                    { 208, null, null, null, "parent8@fpt.edu.vn", "Phụ huynh của Student 8", null, "password123", "0800000008", null, null, null, null },
                    { 209, null, null, null, "parent9@fpt.edu.vn", "Phụ huynh của Student 9", null, "password123", "0800000009", null, null, null, null },
                    { 210, null, null, null, "parent10@fpt.edu.vn", "Phụ huynh của Student 10", null, "password123", "0800000010", null, null, null, null },
                    { 211, null, null, null, "parent11@fpt.edu.vn", "Phụ huynh của Student 11", null, "password123", "0800000011", null, null, null, null },
                    { 212, null, null, null, "parent12@fpt.edu.vn", "Phụ huynh của Student 12", null, "password123", "0800000012", null, null, null, null },
                    { 213, null, null, null, "parent13@fpt.edu.vn", "Phụ huynh của Student 13", null, "password123", "0800000013", null, null, null, null },
                    { 214, null, null, null, "parent14@fpt.edu.vn", "Phụ huynh của Student 14", null, "password123", "0800000014", null, null, null, null },
                    { 215, null, null, null, "parent15@fpt.edu.vn", "Phụ huynh của Student 15", null, "password123", "0800000015", null, null, null, null },
                    { 216, null, null, null, "parent16@fpt.edu.vn", "Phụ huynh của Student 16", null, "password123", "0800000016", null, null, null, null },
                    { 217, null, null, null, "parent17@fpt.edu.vn", "Phụ huynh của Student 17", null, "password123", "0800000017", null, null, null, null },
                    { 218, null, null, null, "parent18@fpt.edu.vn", "Phụ huynh của Student 18", null, "password123", "0800000018", null, null, null, null },
                    { 219, null, null, null, "parent19@fpt.edu.vn", "Phụ huynh của Student 19", null, "password123", "0800000019", null, null, null, null },
                    { 220, null, null, null, "parent20@fpt.edu.vn", "Phụ huynh của Student 20", null, "password123", "0800000020", null, null, null, null },
                    { 221, null, null, null, "parent21@fpt.edu.vn", "Phụ huynh của Student 21", null, "password123", "0800000021", null, null, null, null },
                    { 222, null, null, null, "parent22@fpt.edu.vn", "Phụ huynh của Student 22", null, "password123", "0800000022", null, null, null, null },
                    { 223, null, null, null, "parent23@fpt.edu.vn", "Phụ huynh của Student 23", null, "password123", "0800000023", null, null, null, null },
                    { 224, null, null, null, "parent24@fpt.edu.vn", "Phụ huynh của Student 24", null, "password123", "0800000024", null, null, null, null },
                    { 225, null, null, null, "parent25@fpt.edu.vn", "Phụ huynh của Student 25", null, "password123", "0800000025", null, null, null, null },
                    { 226, null, null, null, "parent26@fpt.edu.vn", "Phụ huynh của Student 26", null, "password123", "0800000026", null, null, null, null },
                    { 227, null, null, null, "parent27@fpt.edu.vn", "Phụ huynh của Student 27", null, "password123", "0800000027", null, null, null, null },
                    { 228, null, null, null, "parent28@fpt.edu.vn", "Phụ huynh của Student 28", null, "password123", "0800000028", null, null, null, null },
                    { 229, null, null, null, "parent29@fpt.edu.vn", "Phụ huynh của Student 29", null, "password123", "0800000029", null, null, null, null },
                    { 230, null, null, null, "parent30@fpt.edu.vn", "Phụ huynh của Student 30", null, "password123", "0800000030", null, null, null, null },
                    { 231, null, null, null, "parent31@fpt.edu.vn", "Phụ huynh của Student 31", null, "password123", "0800000031", null, null, null, null },
                    { 232, null, null, null, "parent32@fpt.edu.vn", "Phụ huynh của Student 32", null, "password123", "0800000032", null, null, null, null },
                    { 233, null, null, null, "parent33@fpt.edu.vn", "Phụ huynh của Student 33", null, "password123", "0800000033", null, null, null, null },
                    { 234, null, null, null, "parent34@fpt.edu.vn", "Phụ huynh của Student 34", null, "password123", "0800000034", null, null, null, null },
                    { 235, null, null, null, "parent35@fpt.edu.vn", "Phụ huynh của Student 35", null, "password123", "0800000035", null, null, null, null },
                    { 236, null, null, null, "parent36@fpt.edu.vn", "Phụ huynh của Student 36", null, "password123", "0800000036", null, null, null, null },
                    { 237, null, null, null, "parent37@fpt.edu.vn", "Phụ huynh của Student 37", null, "password123", "0800000037", null, null, null, null },
                    { 238, null, null, null, "parent38@fpt.edu.vn", "Phụ huynh của Student 38", null, "password123", "0800000038", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, 203 },
                    { 4, 204 },
                    { 4, 205 },
                    { 4, 206 },
                    { 4, 207 },
                    { 4, 208 },
                    { 4, 209 },
                    { 4, 210 },
                    { 4, 211 },
                    { 4, 212 },
                    { 4, 213 },
                    { 4, 214 },
                    { 4, 215 },
                    { 4, 216 },
                    { 4, 217 },
                    { 4, 218 },
                    { 4, 219 },
                    { 4, 220 },
                    { 4, 221 },
                    { 4, 222 },
                    { 4, 223 },
                    { 4, 224 },
                    { 4, 225 },
                    { 4, 226 },
                    { 4, 227 },
                    { 4, 228 },
                    { 4, 229 },
                    { 4, 230 },
                    { 4, 231 },
                    { 4, 232 },
                    { 4, 233 },
                    { 4, 234 },
                    { 4, 235 },
                    { 4, 236 },
                    { 4, 237 },
                    { 4, 238 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 203 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 204 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 205 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 206 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 207 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 208 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 209 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 210 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 211 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 212 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 213 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 214 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 215 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 216 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 217 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 218 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 219 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 220 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 221 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 222 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 223 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 224 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 225 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 226 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 227 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 228 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 229 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 230 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 231 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 232 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 233 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 234 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 235 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 236 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 237 });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 238 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 238);

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
    }
}
