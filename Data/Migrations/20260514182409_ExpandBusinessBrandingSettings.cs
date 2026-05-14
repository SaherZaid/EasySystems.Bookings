using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class ExpandBusinessBrandingSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Businesses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BodyTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#4B5563");

            migrationBuilder.AddColumn<string>(
                name: "BookingPanelBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "ButtonBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "ButtonTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "CardBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "DangerColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#B42318");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "FooterTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "HeadingTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "HeroOverlayColor",
                table: "Businesses",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "rgba(0,0,0,.55)");

            migrationBuilder.AddColumn<string>(
                name: "HeroTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MutedTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#7A6F63");

            migrationBuilder.AddColumn<string>(
                name: "NavbarBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "NavbarTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "PageBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#F8F4ED");

            migrationBuilder.AddColumn<string>(
                name: "PriceTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryButtonBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryButtonTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#151515");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#C9A46A");

            migrationBuilder.AddColumn<string>(
                name: "SectionBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "ServiceCardBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "StaffCardBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#FFFFFF");

            migrationBuilder.AddColumn<string>(
                name: "SuccessColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#087443");

            migrationBuilder.AddColumn<string>(
                name: "Tagline",
                table: "Businesses",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TikTokUrl",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WarningColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "#B45309");

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "BodyTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "BookingPanelBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "ButtonBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "ButtonTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "CardBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "DangerColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "FacebookUrl", table: "Businesses");
            migrationBuilder.DropColumn(name: "FooterBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "FooterTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "HeadingTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "HeroOverlayColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "HeroTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "InstagramUrl", table: "Businesses");
            migrationBuilder.DropColumn(name: "MutedTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "NavbarBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "NavbarTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "PageBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "PriceTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "PrimaryColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "SecondaryButtonBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "SecondaryButtonTextColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "SecondaryColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "SectionBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "ServiceCardBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "StaffCardBackgroundColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "SuccessColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "Tagline", table: "Businesses");
            migrationBuilder.DropColumn(name: "TikTokUrl", table: "Businesses");
            migrationBuilder.DropColumn(name: "WarningColor", table: "Businesses");
            migrationBuilder.DropColumn(name: "WebsiteUrl", table: "Businesses");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}