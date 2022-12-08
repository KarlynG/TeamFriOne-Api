using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamFriOneModel.Migrations
{
    /// <inheritdoc />
    public partial class newpropertyidentificationtouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identification",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identification",
                table: "Users");
        }
    }
}
