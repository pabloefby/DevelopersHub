using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevelopersHub.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCategoriasYDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Publicaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Dudas y tips sobre cómo llevar tu carrera", "Career Path" },
                    { 2, "Desarrollo del lado del servidor, APIs y lógica de negocio", "Back-end" },
                    { 3, "Diseño de interfaces, componentes y experiencia de usuario", "Front-end" },
                    { 4, "Consultas, modelado SQL, NoSQL y optimización", "Bases de datos" },
                    { 5, "Despliegues, CI/CD, Docker, Linux y proveedores en la nube", "DevOps & Cloud" },
                    { 6, "Buenas prácticas de seguridad, autenticación, JWT y protección de APIs", "Ciberseguridad" },
                    { 7, "Muestra tus proyectos personales y recibe feedback de la comunidad", "Showcase / Proyectos" },
                    { 8, "Charlas casuales, tecnología en general, setups y comunidad", "Off-Topic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_CategoriaId",
                table: "Publicaciones",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicaciones_Categorias_CategoriaId",
                table: "Publicaciones",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicaciones_Categorias_CategoriaId",
                table: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Publicaciones_CategoriaId",
                table: "Publicaciones");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Publicaciones");
        }
    }
}
