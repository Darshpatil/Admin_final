using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminDAL.Migrations
{
    /// <inheritdoc />
    public partial class werty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Features",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Features",
                newName: "UserID");
        }
    }
}
