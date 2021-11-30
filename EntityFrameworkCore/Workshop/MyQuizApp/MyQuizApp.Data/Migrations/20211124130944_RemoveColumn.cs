using Microsoft.EntityFrameworkCore.Migrations;

namespace MyQuizApp.Data.Migrations
{
    public partial class RemoveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
