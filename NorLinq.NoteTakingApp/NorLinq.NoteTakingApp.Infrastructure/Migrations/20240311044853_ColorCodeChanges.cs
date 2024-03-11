using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorLinq.NoteTakingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColorCodeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "Notes");
        }
    }
}
