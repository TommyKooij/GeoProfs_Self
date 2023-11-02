using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class managerToAbsence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceProposals_Employees_EmployeeID",
                table: "AbsenceProposals");

            migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "AbsenceProposals",
                newName: "ManagerID");

            migrationBuilder.RenameIndex(
                name: "IX_AbsenceProposals_EmployeeID",
                table: "AbsenceProposals",
                newName: "IX_AbsenceProposals_ManagerID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "AbsenceProposals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceProposals_ID",
                table: "AbsenceProposals",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceProposals_Employees_ID",
                table: "AbsenceProposals",
                column: "ID",
                principalTable: "Employees",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceProposals_Employees_ManagerID",
                table: "AbsenceProposals",
                column: "ManagerID",
                principalTable: "Employees",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceProposals_Employees_ID",
                table: "AbsenceProposals");

            migrationBuilder.DropForeignKey(
                name: "FK_AbsenceProposals_Employees_ManagerID",
                table: "AbsenceProposals");

            migrationBuilder.DropIndex(
                name: "IX_AbsenceProposals_ID",
                table: "AbsenceProposals");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "AbsenceProposals");

            migrationBuilder.RenameColumn(
                name: "ManagerID",
                table: "AbsenceProposals",
                newName: "EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_AbsenceProposals_ManagerID",
                table: "AbsenceProposals",
                newName: "IX_AbsenceProposals_EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AbsenceProposals_Employees_EmployeeID",
                table: "AbsenceProposals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID");
        }
    }
}
