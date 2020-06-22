using Microsoft.EntityFrameworkCore.Migrations;

namespace CoalescePlayground.Data.Migrations
{
    public partial class SecurityLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecurityLevel",
                table: "Person",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "Person");
        }
    }
}
