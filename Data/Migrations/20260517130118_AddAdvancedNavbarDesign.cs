using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvancedNavbarDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NavbarActiveBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NavbarActiveTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NavbarBorderRadius",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NavbarHeight",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NavbarIsFloating",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NavbarIsSticky",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NavbarLogoBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NavbarLogoSize",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NavbarLogoTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NavbarShadowColor",
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
                name: "NavbarActiveBackgroundColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarActiveTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarBorderRadius",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarHeight",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarIsFloating",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarIsSticky",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarLogoBackgroundColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarLogoSize",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarLogoTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "NavbarShadowColor",
                table: "Businesses");
        }
    }
}
