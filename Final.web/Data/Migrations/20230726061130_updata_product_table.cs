using Microsoft.EntityFrameworkCore.Migrations;

namespace Final.web.Data.Migrations
{
    public partial class updata_product_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
