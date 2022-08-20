using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreScratchPad.Migrations
{
    public partial class Initial_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_RedressId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "RedressId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RedressId",
                table: "Products",
                column: "RedressId",
                unique: true,
                filter: "[RedressId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_RedressId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "RedressId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_RedressId",
                table: "Products",
                column: "RedressId",
                unique: true);
        }
    }
}
