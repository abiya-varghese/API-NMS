using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nms_backend_api.Migrations
{
    /// <inheritdoc />
    public partial class std3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "tble_teacher");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "tble_teacher");

            migrationBuilder.DropColumn(
                name: "Contactno",
                table: "tbl_student");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "tbl_student");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "tble_teacher",
                newName: "SubjectTaught");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectTaught",
                table: "tble_teacher",
                newName: "Subject");

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

            migrationBuilder.AddColumn<string>(
                name: "Contactno",
                table: "tbl_student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tbl_student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
