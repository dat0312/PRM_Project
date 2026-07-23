using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetPasswordOtp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordOtpExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    ClassSize = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSubjects",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => new { x.TeacherId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubjects_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleRequests_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleRequests_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Grade", "Name" },
                values: new object[,]
                {
                    { 1, 10, "10A" },
                    { 2, 10, "10A01" },
                    { 3, 10, "10D" },
                    { 4, 11, "11A" },
                    { 5, 11, "11A01" },
                    { 6, 11, "11D" },
                    { 7, 12, "12A" },
                    { 8, 12, "12A01" },
                    { 9, 12, "12D" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Student" },
                    { 3, "Teacher" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A101" },
                    { 2, "A102" },
                    { 3, "B204" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "ResetPasswordOtp", "ResetPasswordOtpExpiry", "StudentId" },
                values: new object[,]
                {
                    { 1, null, null, null, "datvideo04@gmail.com", "Phan Thanh Dat", "denhat123", "0352578129", null, null, "ADMIN001" },
                    { 2, null, null, null, "teacher@example.com", "Giảng viên A", "password123", "0333333333", null, null, "FPT123" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ClassId", "ClassSize", "Date", "RoomId", "Slot", "Status", "SubjectCode", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, 30, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "PRESENT", "PRN211", 2 },
                    { 2, 1, 30, new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "PRESENT", "SWT301", 2 },
                    { 3, 1, 30, new DateTime(2026, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "FUTURE", "PRN211", 2 },
                    { 4, 1, 30, new DateTime(2026, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, "FUTURE", "PEA208", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "ClassId", "DateOfBirth", "Email", "FullName", "Password", "PhoneNumber", "ResetPasswordOtp", "ResetPasswordOtpExpiry", "StudentId" },
                values: new object[,]
                {
                    { 3, null, 1, null, "student3@fpt.edu.vn", "Student 3 - 10A", "password123", "0900000003", null, null, "STU00003" },
                    { 4, null, 1, null, "student4@fpt.edu.vn", "Student 4 - 10A", "password123", "0900000004", null, null, "STU00004" },
                    { 5, null, 1, null, "student5@fpt.edu.vn", "Student 5 - 10A", "password123", "0900000005", null, null, "STU00005" },
                    { 6, null, 2, null, "student6@fpt.edu.vn", "Student 6 - 10A01", "password123", "0900000006", null, null, "STU00006" },
                    { 7, null, 2, null, "student7@fpt.edu.vn", "Student 7 - 10A01", "password123", "0900000007", null, null, "STU00007" },
                    { 8, null, 2, null, "student8@fpt.edu.vn", "Student 8 - 10A01", "password123", "0900000008", null, null, "STU00008" },
                    { 9, null, 3, null, "student9@fpt.edu.vn", "Student 9 - 10D", "password123", "0900000009", null, null, "STU00009" },
                    { 10, null, 3, null, "student10@fpt.edu.vn", "Student 10 - 10D", "password123", "0900000010", null, null, "STU00010" },
                    { 11, null, 3, null, "student11@fpt.edu.vn", "Student 11 - 10D", "password123", "0900000011", null, null, "STU00011" },
                    { 12, null, 4, null, "student12@fpt.edu.vn", "Student 12 - 11A", "password123", "0900000012", null, null, "STU00012" },
                    { 13, null, 4, null, "student13@fpt.edu.vn", "Student 13 - 11A", "password123", "0900000013", null, null, "STU00013" },
                    { 14, null, 4, null, "student14@fpt.edu.vn", "Student 14 - 11A", "password123", "0900000014", null, null, "STU00014" },
                    { 15, null, 5, null, "student15@fpt.edu.vn", "Student 15 - 11A01", "password123", "0900000015", null, null, "STU00015" },
                    { 16, null, 5, null, "student16@fpt.edu.vn", "Student 16 - 11A01", "password123", "0900000016", null, null, "STU00016" },
                    { 17, null, 5, null, "student17@fpt.edu.vn", "Student 17 - 11A01", "password123", "0900000017", null, null, "STU00017" },
                    { 18, null, 6, null, "student18@fpt.edu.vn", "Student 18 - 11D", "password123", "0900000018", null, null, "STU00018" },
                    { 19, null, 6, null, "student19@fpt.edu.vn", "Student 19 - 11D", "password123", "0900000019", null, null, "STU00019" },
                    { 20, null, 6, null, "student20@fpt.edu.vn", "Student 20 - 11D", "password123", "0900000020", null, null, "STU00020" },
                    { 21, null, 7, null, "student21@fpt.edu.vn", "Student 21 - 12A", "password123", "0900000021", null, null, "STU00021" },
                    { 22, null, 7, null, "student22@fpt.edu.vn", "Student 22 - 12A", "password123", "0900000022", null, null, "STU00022" },
                    { 23, null, 7, null, "student23@fpt.edu.vn", "Student 23 - 12A", "password123", "0900000023", null, null, "STU00023" },
                    { 24, null, 8, null, "student24@fpt.edu.vn", "Student 24 - 12A01", "password123", "0900000024", null, null, "STU00024" },
                    { 25, null, 8, null, "student25@fpt.edu.vn", "Student 25 - 12A01", "password123", "0900000025", null, null, "STU00025" },
                    { 26, null, 8, null, "student26@fpt.edu.vn", "Student 26 - 12A01", "password123", "0900000026", null, null, "STU00026" },
                    { 27, null, 9, null, "student27@fpt.edu.vn", "Student 27 - 12D", "password123", "0900000027", null, null, "STU00027" },
                    { 28, null, 9, null, "student28@fpt.edu.vn", "Student 28 - 12D", "password123", "0900000028", null, null, "STU00028" },
                    { 29, null, 9, null, "student29@fpt.edu.vn", "Student 29 - 12D", "password123", "0900000029", null, null, "STU00029" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 2, 26 },
                    { 2, 27 },
                    { 2, 28 },
                    { 2, 29 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRequests_ScheduleId",
                table: "ScheduleRequests",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleRequests_TeacherId",
                table: "ScheduleRequests",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassId",
                table: "Schedules",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RoomId",
                table: "Schedules",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeacherId",
                table: "Schedules",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClassId",
                table: "Users",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                table: "Users",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleRequests");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
