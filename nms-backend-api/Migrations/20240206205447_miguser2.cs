using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nms_backend_api.Migrations
{
    /// <inheritdoc />
    public partial class miguser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "tbl_Examination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "tbl_Examination");
        }
    }
}
