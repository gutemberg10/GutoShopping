using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GutoShopping.OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_header",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<string>(name: "user_id", type: "nvarchar(max)", nullable: true),
                    couponcode = table.Column<string>(name: "coupon_code", type: "nvarchar(max)", nullable: true),
                    purchaseamount = table.Column<decimal>(name: "purchase_amount", type: "decimal(18,2)", nullable: false),
                    discountamount = table.Column<decimal>(name: "discount_amount", type: "decimal(18,2)", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: true),
                    purchasedate = table.Column<DateTime>(name: "purchase_date", type: "datetime2", nullable: false),
                    ordertime = table.Column<DateTime>(name: "order_time", type: "datetime2", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardnumber = table.Column<string>(name: "card_number", type: "nvarchar(max)", nullable: true),
                    cvv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expirymonthyear = table.Column<string>(name: "expiry_month_year", type: "nvarchar(max)", nullable: true),
                    totalitens = table.Column<int>(name: "total_itens", type: "int", nullable: false),
                    paymentstatus = table.Column<bool>(name: "payment_status", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_header", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_detail_order_header_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "order_header",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_detail_OrderHeaderId",
                table: "order_detail",
                column: "OrderHeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "order_header");
        }
    }
}
