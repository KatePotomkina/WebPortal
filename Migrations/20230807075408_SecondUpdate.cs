using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackPart.Migrations
{
    /// <inheritdoc />
    public partial class SecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "orderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_orderId",
                table: "OrderItem",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_productId",
                table: "OrderItem",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders",
                table: "OrderItem",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product",
                table: "OrderItem",
                column: "productId",
                principalTable: "Product",
                principalColumn: "product_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_orderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_productId",
                table: "OrderItem");
        }
    }
}
