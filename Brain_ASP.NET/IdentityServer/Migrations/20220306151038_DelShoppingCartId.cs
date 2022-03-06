using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_Server.Migrations
{
    public partial class DelShoppingCartId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfile_ShoppingCartId",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "UserProfile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "UserProfile",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ShoppingCartId",
                table: "UserProfile",
                column: "ShoppingCartId");
        }
    }
}
