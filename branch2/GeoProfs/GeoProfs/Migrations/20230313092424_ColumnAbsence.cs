using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class ColumnAbsence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_AbsenceProposals_AbsenceProposalID",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Departments_DepartmentID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absences",
                table: "Absences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbsenceProposals",
                table: "AbsenceProposals");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Calendar");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "Absences",
                newName: "Absence");

            migrationBuilder.RenameTable(
                name: "AbsenceProposals",
                newName: "Absence Proposal");

            migrationBuilder.RenameIndex(
                name: "IX_Absences_AbsenceProposalID",
                table: "Absence",
                newName: "IX_Absence_AbsenceProposalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absence",
                table: "Absence",
                column: "AbsenceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absence Proposal",
                table: "Absence Proposal",
                column: "AbsenceProposalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absence_Absence Proposal_AbsenceProposalID",
                table: "Absence",
                column: "AbsenceProposalID",
                principalTable: "Absence Proposal",
                principalColumn: "AbsenceProposalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Department_DepartmentID",
                table: "Enrollments",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absence_Absence Proposal_AbsenceProposalID",
                table: "Absence");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Department_DepartmentID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendar",
                table: "Calendar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absence Proposal",
                table: "Absence Proposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Absence",
                table: "Absence");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "Calendar",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Absence Proposal",
                newName: "AbsenceProposals");

            migrationBuilder.RenameTable(
                name: "Absence",
                newName: "Absences");

            migrationBuilder.RenameIndex(
                name: "IX_Absence_AbsenceProposalID",
                table: "Absences",
                newName: "IX_Absences_AbsenceProposalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsenceProposals",
                table: "AbsenceProposals",
                column: "AbsenceProposalID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Absences",
                table: "Absences",
                column: "AbsenceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_AbsenceProposals_AbsenceProposalID",
                table: "Absences",
                column: "AbsenceProposalID",
                principalTable: "AbsenceProposals",
                principalColumn: "AbsenceProposalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Departments_DepartmentID",
                table: "Enrollments",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
