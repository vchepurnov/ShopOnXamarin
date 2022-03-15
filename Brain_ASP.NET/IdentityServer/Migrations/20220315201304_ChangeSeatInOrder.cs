using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_Server.Migrations
{
    public partial class ChangeSeatInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderSeat");

            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Seat",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_OrderId",
                table: "Seat",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Order_OrderId",
                table: "Seat",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Order_OrderId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_OrderId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Seat");

            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "Seat",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderSeat",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "integer", nullable: false),
                    SeatsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSeat", x => new { x.OrdersId, x.SeatsId });
                    table.ForeignKey(
                        name: "FK_OrderSeat_Order_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSeat_Seat_SeatsId",
                        column: x => x.SeatsId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSeat_SeatsId",
                table: "OrderSeat",
                column: "SeatsId");
        }
    }
}
