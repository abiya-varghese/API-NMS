using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nms_backend_api.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_class_tbl_teacher_TeacherId",
                table: "tbl_class");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "tbl_class",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_class_tbl_teacher_TeacherId",
                table: "tbl_class",
                column: "TeacherId",
                principalTable: "tbl_teacher",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_class_tbl_teacher_TeacherId",
                table: "tbl_class");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherId",
                table: "tbl_class",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_class_tbl_teacher_TeacherId",
                table: "tbl_class",
                column: "TeacherId",
                principalTable: "tbl_teacher",
                principalColumn: "TeacherId");
        }
    }
}
