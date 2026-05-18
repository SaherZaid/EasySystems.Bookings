using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class AddFooterCustomization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterBorderColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterCopyrightText",
                table: "Businesses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterDescription",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterHeadingColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterLinkColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterLinkHoverColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterMutedTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterTitle",
                table: "Businesses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowFooterLegalLinks",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowFooterLogo",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowFooterSocialLinks",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterBorderColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterCopyrightText",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterDescription",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterHeadingColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterLinkColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterLinkHoverColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterMutedTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FooterTitle",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ShowFooterLegalLinks",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ShowFooterLogo",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ShowFooterSocialLinks",
                table: "Businesses");
        }
    }
}
