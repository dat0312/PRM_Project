using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddClubs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresidentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_Users_PresidentId",
                        column: x => x.PresidentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ClubMembers",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMembers", x => new { x.ClubId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ClubMembers_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClubMembers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "Code", "Name", "PresidentId", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "MC", "CLB Âm nhạc", 3, "HOẠT ĐỘNG", "Nghệ thuật & Văn hóa" },
                    { 2, "BC", "CLB Bóng rổ", 4, "HOẠT ĐỘNG", "Thể thao" },
                    { 3, "IT", "CLB Lập trình & AI", 5, "TẠM NGỪNG", "Học thuật" }
                });

            migrationBuilder.InsertData(
                table: "ClubMembers",
                columns: new[] { "ClubId", "UserId", "JoinedDate" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(224) },
                    { 1, 6, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(227) },
                    { 1, 8, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(233) },
                    { 1, 10, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(236) },
                    { 1, 12, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(237) },
                    { 1, 14, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(240) },
                    { 1, 16, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(241) },
                    { 1, 18, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(243) },
                    { 1, 20, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(245) },
                    { 1, 22, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(247) },
                    { 1, 24, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(248) },
                    { 1, 26, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(250) },
                    { 1, 28, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(252) },
                    { 2, 3, new DateTime(2026, 7, 15, 15, 34, 11, 104, DateTimeKind.Utc).AddTicks(9923) },
                    { 2, 6, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(228) },
                    { 2, 9, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(235) },
                    { 2, 12, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(238) },
                    { 2, 15, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(241) },
                    { 2, 18, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(245) },
                    { 2, 21, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(247) },
                    { 2, 24, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(249) },
                    { 2, 27, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(251) },
                    { 3, 4, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(225) },
                    { 3, 8, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(234) },
                    { 3, 12, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(239) },
                    { 3, 16, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(242) },
                    { 3, 20, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(246) },
                    { 3, 24, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(250) },
                    { 3, 28, new DateTime(2026, 7, 15, 15, 34, 11, 105, DateTimeKind.Utc).AddTicks(253) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClubMembers_UserId",
                table: "ClubMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_PresidentId",
                table: "Clubs",
                column: "PresidentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClubMembers");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
