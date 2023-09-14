using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class absencedaysleft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalOffDays",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "maxAbsenceDays",
                table: "Employees",
                newName: "MaxAbsenceDays");

            migrationBuilder.RenameColumn(
                name: "totalSickDays",
                table: "Employees",
                newName: "DaysOfAbsence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MaxAbsenceDays",
                table: "Employees",
                newName: "maxAbsenceDays");

            migrationBuilder.RenameColumn(
                name: "DaysOfAbsence",
                table: "Employees",
                newName: "totalSickDays");

            migrationBuilder.AddColumn<int>(
                name: "totalOffDays",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
