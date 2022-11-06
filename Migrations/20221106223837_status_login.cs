using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceTrabalho.Migrations
{
    public partial class status_login : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogged",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogged",
                table: "Usuarios");
        }
    }
}
