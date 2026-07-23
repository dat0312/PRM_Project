using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedByIdsToAppRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedByIds",
                table: "AppRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedByIds",
                table: "AppRequests");

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1655));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1654));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 18, 22, 49, 225, DateTimeKind.Utc).AddTicks(1660));
        }
    }
}
