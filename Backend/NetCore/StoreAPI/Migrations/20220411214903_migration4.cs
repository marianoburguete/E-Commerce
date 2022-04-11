using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAPI.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Products_ProductId1",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ProductId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Questions");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_OrderId",
                table: "Reviews",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId1",
                table: "Reviews",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ProductId1",
                table: "Questions",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Products_ProductId1",
                table: "Questions",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId1",
                table: "Reviews",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
