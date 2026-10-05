using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorWebApp.Migrations
{
    /// <inheritdoc />
    public partial class AgregaPromociones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promociones",
                columns: table => new
                {
                    PromocionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorcentajeDescuento = table.Column<int>(type: "int", nullable: false),
                    PrecioPromocional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promociones", x => x.PromocionId);
                });

            migrationBuilder.InsertData(
                table: "Promociones",
                columns: new[] { "PromocionId", "Activo", "Descripcion", "Imagen", "Orden", "PorcentajeDescuento", "PrecioPromocional", "Titulo" },
                values: new object[,]
                {
                    { 1, true, "Potencia para trabajar y estudiar. Intel i5 - 16GB RAM - SSD 512GB.", "assets/img/portfolio/1.jpg", 1, 15, 850000m, "Notebook Lenovo" },
                    { 2, true, "Smartphone de última generación con 256GB y cámara de alta calidad.", "assets/img/portfolio/2.jpg", 2, 10, 620000m, "Samsung Galaxy" },
                    { 3, true, "Sonido envolvente, luces RGB y micrófono integrado.", "assets/img/portfolio/3.jpg", 3, 20, 95000m, "Auriculares Gamer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promociones");
        }
    }
}
