using Microsoft.EntityFrameworkCore.Migrations;

namespace CarCenter.Data.Migrations
{
    public partial class ChangeOnDeleteBehaivour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Cars_CarId",
                table: "Issues");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Cars_CarId",
                table: "Issues",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Cars_CarId",
                table: "Issues");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Cars_CarId",
                table: "Issues",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
