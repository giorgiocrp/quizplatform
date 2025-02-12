using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizPlatform.Db.Migrations.report
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QuizReportDb");

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "QuizReportDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "QuizReportDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    IsRegistered = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                schema: "QuizReportDb",
                columns: table => new
                {
                    GroupsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalSchema: "QuizReportDb",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "QuizReportDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                schema: "QuizReportDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "QuizReportDb",
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "QuizReportDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "QuizReportDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalSchema: "QuizReportDb",
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                schema: "QuizReportDb",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_AuthorId",
                schema: "QuizReportDb",
                table: "Quizzes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_GroupId",
                schema: "QuizReportDb",
                table: "Quizzes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_QuizId",
                schema: "QuizReportDb",
                table: "Reports",
                column: "QuizId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser",
                schema: "QuizReportDb");

            migrationBuilder.DropTable(
                name: "Reports",
                schema: "QuizReportDb");

            migrationBuilder.DropTable(
                name: "Quizzes",
                schema: "QuizReportDb");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "QuizReportDb");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "QuizReportDb");
        }
    }
}
