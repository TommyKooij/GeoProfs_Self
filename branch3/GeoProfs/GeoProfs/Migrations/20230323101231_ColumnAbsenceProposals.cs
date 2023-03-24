using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class ColumnAbsenceProposals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reasoning",
                table: "Absence Proposal",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "Absence Proposal",
                newName: "ReasonAbsence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReasonAbsence",
                table: "Absence Proposal",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Absence Proposal",
                newName: "Reasoning");
        }
    }
}
