using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicNavbarColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NavbarBorderColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NavbarButtonBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NavbarButtonTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NavbarLinkHoverColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NavbarMobileBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NavbarBorderColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarButtonBackgroundColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarButtonTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarLinkHoverColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarMobileBackgroundColor",
                table: "Businesses");
        }
    }
}
