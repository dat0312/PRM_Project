using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddChildIdToParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1603));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1605));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1589));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1606));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 21, 6, 40, 44, 550, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 21,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 23,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 24,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 26,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 28,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 29,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 30,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 31,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 32,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 33,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 34,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 35,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 36,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 37,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 38,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 100,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 101,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 102,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 103,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 104,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 105,
                column: "ChildId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 203,
                column: "ChildId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 204,
                column: "ChildId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 205,
                column: "ChildId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 206,
                column: "ChildId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 207,
                column: "ChildId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 208,
                column: "ChildId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 209,
                column: "ChildId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 210,
                column: "ChildId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 211,
                column: "ChildId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 212,
                column: "ChildId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 213,
                column: "ChildId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 214,
                column: "ChildId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 215,
                column: "ChildId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 216,
                column: "ChildId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 217,
                column: "ChildId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 218,
                column: "ChildId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 219,
                column: "ChildId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 220,
                column: "ChildId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 221,
                column: "ChildId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 222,
                column: "ChildId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 223,
                column: "ChildId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 224,
                column: "ChildId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 225,
                column: "ChildId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 226,
                column: "ChildId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 227,
                column: "ChildId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 228,
                column: "ChildId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 229,
                column: "ChildId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 230,
                column: "ChildId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 231,
                column: "ChildId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 232,
                column: "ChildId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 233,
                column: "ChildId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 234,
                column: "ChildId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 235,
                column: "ChildId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 236,
                column: "ChildId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 237,
                column: "ChildId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 238,
                column: "ChildId",
                value: 38);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ChildId",
                table: "Users",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_ChildId",
                table: "Users",
                column: "ChildId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_ChildId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ChildId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Users");

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
        }
    }
}
