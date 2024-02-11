﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nms_backend_api.Entity;

#nullable disable

namespace nms_backend_api.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20240211051122_mig2")]
    partial class mig2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("nms_backend_api.Entity.Class1", b =>
                {
                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("ClassName");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Section");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TeacherId");

                    b.HasKey("ClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("tbl_class");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Examination", b =>
                {
                    b.Property<string>("ExamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ClassId");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("ExamName");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamId");

                    b.HasIndex("ClassId");

                    b.ToTable("tbl_Examination");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Mark", b =>
                {
                    b.Property<string>("MarkId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExamId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ExamId");

                    b.Property<float>("Marks")
                        .HasColumnType("real")
                        .HasColumnName("Marks");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("StudentId");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Subject Name");

                    b.HasKey("MarkId");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("tbl_mark");
                });

            modelBuilder.Entity("nms_backend_api.Entity.ScheduleClass", b =>
                {
                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ClassId");

                    b.Property<string>("Sessiontime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TeacherId");

                    b.HasKey("ScheduleId");

                    b.HasIndex("ClassId");

                    b.HasIndex("TeacherId");

                    b.ToTable("tbl_schedule");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Student", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Address");

                    b.Property<string>("ClassId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<DateTime>("RegDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rollno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.ToTable("tbl_student");
                });

            modelBuilder.Entity("nms_backend_api.Entity.StudentAttendence", b =>
                {
                    b.Property<string>("StudAttendenceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("StudAttendenceId");

                    b.HasIndex("StudentId");

                    b.ToTable("tbl_StudentAttendence");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Teacher", b =>
                {
                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("char");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<string>("SubjectTaught")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar");

                    b.HasKey("TeacherId");

                    b.ToTable("tble_teacher");
                });

            modelBuilder.Entity("nms_backend_api.Entity.TeacherAttendence", b =>
                {
                    b.Property<string>("TeacherAttendId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TeacherId");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("TeacherAttendId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeachAttendences");
                });

            modelBuilder.Entity("nms_backend_api.Entity.User", b =>
                {
                    b.Property<string>("Emailid")
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("EmailId");

                    b.Property<string>("AdmissionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNum")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar")
                        .HasColumnName("PhoneNo");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("UserName");

                    b.HasKey("Emailid");

                    b.ToTable("tbl_user");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Class1", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Examination", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Class1", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Mark", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Examination", "examination")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nms_backend_api.Entity.Student", "student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("examination");

                    b.Navigation("student");
                });

            modelBuilder.Entity("nms_backend_api.Entity.ScheduleClass", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Class1", "Class1")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("nms_backend_api.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class1");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("nms_backend_api.Entity.Student", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Class1", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("nms_backend_api.Entity.StudentAttendence", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("nms_backend_api.Entity.TeacherAttendence", b =>
                {
                    b.HasOne("nms_backend_api.Entity.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
