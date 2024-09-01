using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountAntAPI.Migrations
{
    /// <inheritdoc />
    public partial class collections_archive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Collections");
        }
    }
}
