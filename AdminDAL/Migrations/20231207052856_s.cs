using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminDAL.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Features");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
