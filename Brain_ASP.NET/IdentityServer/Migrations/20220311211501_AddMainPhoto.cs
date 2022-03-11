using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_Server.Migrations
{
    public partial class AddMainPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainPhoto",
                table: "Product",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPhoto",
                table: "Product");
        }
    }
}
