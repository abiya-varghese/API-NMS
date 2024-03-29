﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nms_backend_api.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    NotificationID = table.Column<string>(name: "Notification ID", type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationTime = table.Column<DateTime>(name: "Notification Time", type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.NotificationID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNo = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    AdmissionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.EmailId);
                });

            migrationBuilder.CreateTable(
                name: "tble_teacher",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    Gender = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    SubjectTaught = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tble_teacher", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_class",
                columns: table => new
                {
                    ClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Section = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_class", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_tbl_class_tble_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "tble_teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "TeachAttendences",
                columns: table => new
                {
                    TeacherAttendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachAttendences", x => x.TeacherAttendId);
                    table.ForeignKey(
                        name: "FK_TeachAttendences_tble_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "tble_teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Examination",
                columns: table => new
                {
                    ExamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Examination", x => x.ExamId);
                    table.ForeignKey(
                        name: "FK_tbl_Examination_tbl_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tbl_class",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sessiontime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_schedule", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_tbl_schedule_tbl_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tbl_class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_schedule_tble_teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "tble_teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_student",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Rollno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_tbl_student_tbl_class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tbl_class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_mark",
                columns: table => new
                {
                    MarkId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Marks = table.Column<float>(type: "real", nullable: false),
                    SubjectName = table.Column<string>(name: "Subject Name", type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mark", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_tbl_mark_tbl_Examination_ExamId",
                        column: x => x.ExamId,
                        principalTable: "tbl_Examination",
                        principalColumn: "ExamId");
                    table.ForeignKey(
                        name: "FK_tbl_mark_tbl_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbl_student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_StudentAttendence",
                columns: table => new
                {
                    StudAttendenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StudentAttendence", x => x.StudAttendenceId);
                    table.ForeignKey(
                        name: "FK_tbl_StudentAttendence_tbl_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "tbl_student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_class_TeacherId",
                table: "tbl_class",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Examination_ClassId",
                table: "tbl_Examination",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mark_ExamId",
                table: "tbl_mark",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mark_StudentId",
                table: "tbl_mark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_schedule_ClassId",
                table: "tbl_schedule",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_schedule_TeacherId",
                table: "tbl_schedule",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_student_ClassId",
                table: "tbl_student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StudentAttendence_StudentId",
                table: "tbl_StudentAttendence",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachAttendences_TeacherId",
                table: "TeachAttendences",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "tbl_mark");

            migrationBuilder.DropTable(
                name: "tbl_schedule");

            migrationBuilder.DropTable(
                name: "tbl_StudentAttendence");

            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.DropTable(
                name: "TeachAttendences");

            migrationBuilder.DropTable(
                name: "tbl_Examination");

            migrationBuilder.DropTable(
                name: "tbl_student");

            migrationBuilder.DropTable(
                name: "tbl_class");

            migrationBuilder.DropTable(
                name: "tble_teacher");
        }
    }
}
