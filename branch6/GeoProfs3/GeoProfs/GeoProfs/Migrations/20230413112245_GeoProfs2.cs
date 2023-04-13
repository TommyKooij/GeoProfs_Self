using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class GeoProfs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Managers_ManagerID",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Managers",
                table: "Managers");

            migrationBuilder.RenameTable(
                name: "Managers",
                newName: "Manager");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manager",
                table: "Manager",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Manager_ManagerID",
                table: "Departments",
                column: "ManagerID",
                principalTable: "Manager",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Manager_ManagerID",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manager",
                table: "Manager");

            migrationBuilder.RenameTable(
                name: "Manager",
                newName: "Managers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Managers",
                table: "Managers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Managers_ManagerID",
                table: "Departments",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ID");
        }
    }
}
