using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopersHub.Migrations
{
    /// <inheritdoc />
    public partial class AñadirColumnaColorHexa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ColorHexa",
                table: "Categorias",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "ColorHexa",
                value: "#019fce");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "ColorHexa",
                value: "#01aca6");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "ColorHexa",
                value: "#7fb539");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "ColorHexa",
                value: "#ffd401");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "ColorHexa",
                value: "#fa9d1c");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "ColorHexa",
                value: "#c61935");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7,
                column: "ColorHexa",
                value: "#f598aa");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 8,
                column: "ColorHexa",
                value: "#6950a1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorHexa",
                table: "Categorias");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
