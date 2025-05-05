using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace C_SHOP.Migrations
{
    /// <inheritdoc />
    public partial class FAQmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_FAQs",
                columns: table => new
                {
                    faq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faq_question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faq_answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FAQs", x => x.faq_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_FAQs");
        }
    }
}
