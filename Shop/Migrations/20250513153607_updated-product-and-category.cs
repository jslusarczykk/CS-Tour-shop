using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_SHOP.Migrations
{
    /// <inheritdoc />
    public partial class updatedproductandcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateIndex(
                name: "IX_tbl_product_cat_id",
                table: "tbl_product",
                column: "cat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_product_tbl_category_cat_id",
                table: "tbl_product",
                column: "cat_id",
                principalTable: "tbl_category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_product_tbl_category_cat_id",
                table: "tbl_product");

            migrationBuilder.DropIndex(
                name: "IX_tbl_product_cat_id",
                table: "tbl_product");

            migrationBuilder.CreateTable(
                name: "tbl_delete",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_delete", x => x.admin_id);
                });
        }
    }
}
