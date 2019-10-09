using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_manager",
                table: "manager");

            migrationBuilder.RenameTable(
                name: "manager",
                newName: "managers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_managers",
                table: "managers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_managers",
                table: "managers");

            migrationBuilder.RenameTable(
                name: "managers",
                newName: "manager");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manager",
                table: "manager",
                column: "Id");
        }
    }
}
