using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class emailsToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_AbsenceProposals_ManagerID",
                table: "AbsenceProposals");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "AbsenceProposals");

            migrationBuilder.DropColumn(
                name: "ManagerID",
                table: "AbsenceProposals");

            migrationBuilder.AddColumn<string>(
                name: "MailEmployee",
                table: "AbsenceProposals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailManager",
                table: "AbsenceProposals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailEmployee",
                table: "AbsenceProposals");

            migrationBuilder.DropColumn(
                name: "MailManager",
                table: "AbsenceProposals");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "AbsenceProposals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerID",
                table: "AbsenceProposals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceProposals_ID",
                table: "AbsenceProposals",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_AbsenceProposals_ManagerID",
                table: "AbsenceProposals",
                column: "ManagerID");

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
    }
}
