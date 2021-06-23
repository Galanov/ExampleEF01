using Microsoft.EntityFrameworkCore.Migrations;

namespace efex02.Migrations
{
    public partial class Current : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }
    }
}
