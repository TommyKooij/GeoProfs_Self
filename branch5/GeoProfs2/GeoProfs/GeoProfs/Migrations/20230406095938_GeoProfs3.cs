using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class GeoProfs3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxAbsenceDays",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalOffDays",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalSickDays",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_RoleID",
                table: "Workers",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Roles_RoleID",
                table: "Workers",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Roles_RoleID",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_RoleID",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "maxAbsenceDays",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "totalOffDays",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "totalSickDays",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Workers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
