using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoProfs.Migrations
{
    public partial class ColumnRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Enrollment",
                newName: "WorkerID");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Enrollment",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Enrollment",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_StudentID",
                table: "Enrollment",
                newName: "IX_Enrollment_WorkerID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CourseID",
                table: "Enrollment",
                newName: "IX_Enrollment_DepartmentID");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Departments_DepartmentID",
                table: "Enrollment",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_WorkerID",
                table: "Enrollment",
                column: "WorkerID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Departments_DepartmentID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_WorkerID",
                table: "Enrollment");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "WorkerID",
                table: "Enrollment",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Enrollment",
                newName: "Grade");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Enrollment",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_WorkerID",
                table: "Enrollment",
                newName: "IX_Enrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_DepartmentID",
                table: "Enrollment",
                newName: "IX_Enrollment_CourseID");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_CourseID",
                table: "Enrollment",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_StudentID",
                table: "Enrollment",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
