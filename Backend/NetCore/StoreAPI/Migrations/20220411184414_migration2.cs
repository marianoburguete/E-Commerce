using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreAPI.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultShippingAddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DefaultShippingAddressId",
                table: "Users",
                column: "DefaultShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId1",
                table: "Addresses",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_DefaultShippingAddressId",
                table: "Users",
                column: "DefaultShippingAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_DefaultShippingAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DefaultShippingAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DefaultShippingAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Addresses");
        }
    }
}
