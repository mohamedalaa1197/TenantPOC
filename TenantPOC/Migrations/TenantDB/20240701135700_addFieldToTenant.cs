using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TenantPOC.Migrations.TenantDB
{
    /// <inheritdoc />
    public partial class addFieldToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubscribtionLevel",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscribtionLevel",
                table: "Tenants");
        }
    }
}
