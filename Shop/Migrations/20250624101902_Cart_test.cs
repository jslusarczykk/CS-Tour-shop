using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_SHOP.Migrations
{
    /// <inheritdoc />
    public partial class Cart_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_cart_tbl_customer_cust_id",
                table: "tbl_cart");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_cart_tbl_product_prod_id",
                table: "tbl_cart");

            migrationBuilder.DropIndex(
                name: "IX_tbl_cart_cust_id",
                table: "tbl_cart");

            migrationBuilder.DropIndex(
                name: "IX_tbl_cart_prod_id",
                table: "tbl_cart");

            migrationBuilder.AddColumn<int>(
                name: "customerscustomer_id",
                table: "tbl_cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productsproduct_id",
                table: "tbl_cart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cart_customerscustomer_id",
                table: "tbl_cart",
                column: "customerscustomer_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cart_productsproduct_id",
                table: "tbl_cart",
                column: "productsproduct_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_cart_tbl_customer_customerscustomer_id",
                table: "tbl_cart",
                column: "customerscustomer_id",
                principalTable: "tbl_customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_cart_tbl_product_productsproduct_id",
                table: "tbl_cart",
                column: "productsproduct_id",
                principalTable: "tbl_product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_cart_tbl_customer_customerscustomer_id",
                table: "tbl_cart");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_cart_tbl_product_productsproduct_id",
                table: "tbl_cart");

            migrationBuilder.DropIndex(
                name: "IX_tbl_cart_customerscustomer_id",
                table: "tbl_cart");

            migrationBuilder.DropIndex(
                name: "IX_tbl_cart_productsproduct_id",
                table: "tbl_cart");

            migrationBuilder.DropColumn(
                name: "customerscustomer_id",
                table: "tbl_cart");

            migrationBuilder.DropColumn(
                name: "productsproduct_id",
                table: "tbl_cart");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cart_cust_id",
                table: "tbl_cart",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cart_prod_id",
                table: "tbl_cart",
                column: "prod_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_cart_tbl_customer_cust_id",
                table: "tbl_cart",
                column: "cust_id",
                principalTable: "tbl_customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_cart_tbl_product_prod_id",
                table: "tbl_cart",
                column: "prod_id",
                principalTable: "tbl_product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
