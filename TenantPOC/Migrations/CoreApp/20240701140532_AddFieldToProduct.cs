using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantPOC.Migrations.CoreApp
{
    /// <inheritdoc />
    public partial class AddFieldToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Products");
        }
    }
}
