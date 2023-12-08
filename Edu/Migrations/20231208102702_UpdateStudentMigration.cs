using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseId",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 8, 10, 27, 1, 981, DateTimeKind.Utc).AddTicks(2560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 7, 12, 22, 34, 67, DateTimeKind.Utc).AddTicks(9264));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "Student",
                newName: "IX_Student_CourseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 7, 12, 22, 34, 67, DateTimeKind.Utc).AddTicks(9264),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 8, 10, 27, 1, 981, DateTimeKind.Utc).AddTicks(2560));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
