using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class roleIsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleID1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_RoleID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "RoleID1",
                table: "Employees",
                newName: "TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleID1",
                table: "Employees",
                newName: "IX_Employees_TeamID");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleID",
                table: "Employees",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_TeamID",
                table: "Employees",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_TeamID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TeamID",
                table: "Employees",
                newName: "RoleID1");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_TeamID",
                table: "Employees",
                newName: "IX_Employees_RoleID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleID1",
                table: "Employees",
                column: "RoleID1",
                principalTable: "Roles",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Teams_RoleID",
                table: "Employees",
                column: "RoleID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }
    }
}
