using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class teamteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleID1",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "AbsenceProposals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                table: "Employees",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID1",
                table: "Employees",
                column: "RoleID1");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceProposals_EmployeeID",
                table: "AbsenceProposals",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceProposals_Employees_EmployeeID",
                table: "AbsenceProposals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceProposals_Employees_EmployeeID",
                table: "AbsenceProposals");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleID1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Teams_RoleID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleID1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceProposals_EmployeeID",
                table: "AbsenceProposals");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RoleID1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "AbsenceProposals");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
