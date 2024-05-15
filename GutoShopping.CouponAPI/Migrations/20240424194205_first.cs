using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GutoShopping.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coupon",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    couponcode = table.Column<string>(name: "coupon_code", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    discountamount = table.Column<decimal>(name: "discount_amount", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[,]
                {
                    { 1L, "GUTO_2024_10", 10m },
                    { 2L, "GUTO_2024_20", 20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coupon");
        }
    }
}
