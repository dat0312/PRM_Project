using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceClubProposalsWithAppRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubProposals");

            migrationBuilder.CreateTable(
                name: "AppRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRequests_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4096));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(3797));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4092));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4101));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4097));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 42, 3, 577, DateTimeKind.Utc).AddTicks(4115));

            migrationBuilder.CreateIndex(
                name: "IX_AppRequests_SenderId",
                table: "AppRequests",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRequests");

            migrationBuilder.CreateTable(
                name: "ClubProposals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClubId = table.Column<int>(type: "int", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClubProposals_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClubProposals_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2658));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2660));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2678));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 10 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2681));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 14 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2687));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 22 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 26 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 1, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 6 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2661));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 9 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 15 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 18 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2690));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 21 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 2, 27 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2697));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 4 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2679));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 16 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 20 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 24 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "ClubMembers",
                keyColumns: new[] { "ClubId", "UserId" },
                keyValues: new object[] { 3, 28 },
                column: "JoinedDate",
                value: new DateTime(2026, 7, 15, 17, 17, 38, 267, DateTimeKind.Utc).AddTicks(2699));

            migrationBuilder.CreateIndex(
                name: "IX_ClubProposals_ClubId",
                table: "ClubProposals",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_ClubProposals_SenderId",
                table: "ClubProposals",
                column: "SenderId");
        }
    }
}
