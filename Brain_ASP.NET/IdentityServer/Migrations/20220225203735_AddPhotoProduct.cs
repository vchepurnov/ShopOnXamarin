using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_Server.Migrations
{
    public partial class AddPhotoProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_TypeProduct_TypeProductId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProduct_Category_CategoryId",
                table: "TypeProduct");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingCartId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TypeProduct",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductId",
                table: "Product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<List<string>>(
                name: "Photo",
                table: "Product",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId1",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingCartId1",
                table: "AspNetUsers",
                column: "ShoppingCartId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartId1",
                table: "AspNetUsers",
                column: "ShoppingCartId1",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TypeProduct_TypeProductId",
                table: "Product",
                column: "TypeProductId",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProduct_Category_CategoryId",
                table: "TypeProduct",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartId1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_TypeProduct_TypeProductId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeProduct_Category_CategoryId",
                table: "TypeProduct");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShoppingCartId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TypeProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TypeProductId",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShoppingCartId",
                table: "AspNetUsers",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShoppingCart_ShoppingCartId",
                table: "AspNetUsers",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_TypeProduct_TypeProductId",
                table: "Product",
                column: "TypeProductId",
                principalTable: "TypeProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeProduct_Category_CategoryId",
                table: "TypeProduct",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
