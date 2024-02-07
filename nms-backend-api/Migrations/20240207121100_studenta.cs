using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nms_backend_api.Migrations
{
    /// <inheritdoc />
    public partial class studenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tbl_student",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<double>(
                name: "Contactno",
                table: "tbl_student",
                type: "float",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "tbl_student",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tbl_student",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Contactno",
                table: "tbl_student",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "tbl_student",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);
        }
    }
}
