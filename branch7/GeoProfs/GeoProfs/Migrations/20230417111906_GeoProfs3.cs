using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class GeoProfs3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Rejected",
                table: "AbsenceProposals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rejected",
                table: "AbsenceProposals");
        }
    }
}
