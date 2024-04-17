using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GutoShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    categoryname = table.Column<string>(name: "category_name", type: "nvarchar(50)", maxLength: 50, nullable: true),
                    imagemurl = table.Column<string>(name: "imagem_url", type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "description", "imagem_url", "name", "price" },
                values: new object[] { 1L, "eletrônicos", "Echo Pop Smart speaker compacto com som envolvente e Alexa Cor Preta", "https://m.media-amazon.com/images/I/81WOd456CjL._AC_SY450_.jpg", "Alexa", 274m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
