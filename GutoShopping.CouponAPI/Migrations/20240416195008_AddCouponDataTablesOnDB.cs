using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GutoShopping.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCouponDataTablesOnDB : Migration
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
                    couponCode = table.Column<string>(name: "coupon_Code", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    discountAmount = table.Column<decimal>(name: "discount_Amount", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon", x => x.id);
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
