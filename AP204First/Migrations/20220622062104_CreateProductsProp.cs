using Microsoft.EntityFrameworkCore.Migrations;

namespace AP204First.Migrations
{
    public partial class CreateProductsProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DisplayStatus",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayStatus",
                table: "Products");
        }
    }
}
