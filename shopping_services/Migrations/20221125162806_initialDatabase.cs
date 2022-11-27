using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shoppingservices.Migrations
{
    /// <inheritdoc />
    public partial class initialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderid = table.Column<Guid>(name: "order_id", type: "uuid", nullable: false),
                    orderer = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    deliveryAddress = table.Column<string>(type: "text", nullable: false),
                    orderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    orderStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderid);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryid = table.Column<Guid>(name: "category_id", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    productid = table.Column<Guid>(name: "product_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productid = table.Column<Guid>(name: "product_id", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    discount = table.Column<byte>(type: "smallint", nullable: true),
                    categoryid = table.Column<Guid>(name: "category_id", type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productid);
                    table.ForeignKey(
                        name: "FK_Product_Category_category_id",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    orderid = table.Column<Guid>(name: "order_id", type: "uuid", nullable: false),
                    productid = table.Column<Guid>(name: "product_id", type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    totalMoney = table.Column<double>(type: "double precision", nullable: false),
                    discount = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.orderid, x.productid });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_order_id",
                        column: x => x.orderid,
                        principalTable: "Order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_product_id",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_product_id",
                table: "Category",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_product_id",
                table: "OrderDetail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_category_id",
                table: "Product",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Product_product_id",
                table: "Category",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Product_product_id",
                table: "Category");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
