using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class ColumnAbsences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Calendar");

            migrationBuilder.DropColumn(
                name: "FirstMidName",
                table: "Absence Proposal");

            migrationBuilder.DropColumn(
                name: "TeamManager",
                table: "Absence Proposal");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Absence Proposal",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Calendar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Calendar",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(590)",
                oldMaxLength: 590);

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Absence Proposal",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Absence Proposal");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Absence Proposal",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Calendar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Calendar",
                type: "nvarchar(590)",
                maxLength: 590,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Calendar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstMidName",
                table: "Absence Proposal",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamManager",
                table: "Absence Proposal",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
