using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizPlatform.Db.Migrations.data
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "QuizDataDb");

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "QuizDataDb",
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
                name: "Roles",
                schema: "QuizDataDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "QuizDataDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    IsRegistered = table.Column<bool>(type: "boolean", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "QuizDataDb",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                schema: "QuizDataDb",
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
                        principalSchema: "QuizDataDb",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "QuizDataDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                schema: "QuizDataDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "QuizDataDb",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Quizzes_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "QuizDataDb",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "QuizDataDb",
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
                        principalSchema: "QuizDataDb",
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                schema: "QuizDataDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalSchema: "QuizDataDb",
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                schema: "QuizDataDb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Votes = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responses_Requests_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "QuizDataDb",
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                schema: "QuizDataDb",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_AuthorId",
                schema: "QuizDataDb",
                table: "Quizzes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_GroupId",
                schema: "QuizDataDb",
                table: "Quizzes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_QuizId",
                schema: "QuizDataDb",
                table: "Reports",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_QuizId",
                schema: "QuizDataDb",
                table: "Requests",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_RequestId",
                schema: "QuizDataDb",
                table: "Responses",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "QuizDataDb",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUser",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Reports",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Responses",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Requests",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Quizzes",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "QuizDataDb");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "QuizDataDb");
        }
    }
}
