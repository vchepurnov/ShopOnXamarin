using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Identity_Server.Migrations
{
    public partial class AddTableInSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_TableId",
                table: "Seat",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Table_TableId",
                table: "Seat",
                column: "TableId",
                principalTable: "Table",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Table_TableId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropIndex(
                name: "IX_Seat_TableId",
                table: "Seat");
        }
    }
}
