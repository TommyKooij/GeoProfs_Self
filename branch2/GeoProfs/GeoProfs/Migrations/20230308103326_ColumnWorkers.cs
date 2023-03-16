using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class ColumnWorkers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Workers_WorkerID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Worker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Worker_WorkerID",
                table: "Enrollments",
                column: "WorkerID",
                principalTable: "Worker",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Worker_WorkerID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "Workers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Workers_WorkerID",
                table: "Enrollments",
                column: "WorkerID",
                principalTable: "Workers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
