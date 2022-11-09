using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLab.Migrations
{
    public partial class ChangeToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Authors",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Authors");
        }
    }
}
