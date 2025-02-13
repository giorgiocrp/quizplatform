using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizPlatform.Db.Migrations.data
{
    /// <inheritdoc />
    public partial class rename2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "QuizDataDb",
                table: "Roles",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "QuizDataDb",
                table: "Roles",
                newName: "Description");
        }
    }
}
