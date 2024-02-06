using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nms_backend_api.Migrations
{
    /// <inheritdoc />
    public partial class miguser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_class_tbl_teacher_TeacherId",
                table: "tbl_class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_teacher",
                table: "tbl_teacher");

            migrationBuilder.RenameTable(
                name: "tbl_teacher",
                newName: "tble_teacher");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "tbl_student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "tble_teacher",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "tble_teacher",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "tble_teacher",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tble_teacher",
                table: "tble_teacher",
                column: "TeacherId");

            migrationBuilder.CreateTable(
                name: "tbl_Examination",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Examination", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_tbl_Examination_tbl_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tbl_class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StudentAttendence",
                columns: table => new
                {
                    StudAttendenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StudentAttendence", x => x.StudAttendenceId);
                    table.ForeignKey(
                        name: "FK_tbl_StudentAttendence_tbl_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbl_student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TeachAttendences",
                columns: table => new
                {
                    TeacherAttendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachAttendences", x => x.TeacherAttendId);
                    table.ForeignKey(
                        name: "FK_TeachAttendences_tble_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "tble_teacher",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_ClassId",
                table: "tbl_student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Examination_ClassId",
                table: "tbl_Examination",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StudentAttendence_StudentId",
                table: "tbl_StudentAttendence",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachAttendences_TeacherId",
                table: "TeachAttendences",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_class_tble_teacher_TeacherId",
                table: "tbl_class",
                column: "TeacherId",
                principalTable: "tble_teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_student_tbl_class_ClassId",
                table: "tbl_student",
                column: "ClassId",
                principalTable: "tbl_class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_class_tble_teacher_TeacherId",
                table: "tbl_class");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_student_tbl_class_ClassId",
                table: "tbl_student");

            migrationBuilder.DropTable(
                name: "tbl_Examination");

            migrationBuilder.DropTable(
                name: "tbl_StudentAttendence");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "TeachAttendences");

            migrationBuilder.DropIndex(
                name: "IX_tbl_student_ClassId",
                table: "tbl_student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tble_teacher",
                table: "tble_teacher");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "tbl_student");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "tble_teacher");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "tble_teacher");

            migrationBuilder.RenameTable(
                name: "tble_teacher",
                newName: "tbl_teacher");

            migrationBuilder.AlterColumn<string>(
                name: "Class",
                table: "tbl_teacher",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_teacher",
                table: "tbl_teacher",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_class_tbl_teacher_TeacherId",
                table: "tbl_class",
                column: "TeacherId",
                principalTable: "tbl_teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
