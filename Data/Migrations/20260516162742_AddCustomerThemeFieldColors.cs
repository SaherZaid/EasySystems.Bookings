using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerThemeFieldColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPortalCardColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InputBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InputBorderColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InputFocusColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InputTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LabelTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlotActiveBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlotActiveTextColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlotBackgroundColor",
                table: "Businesses",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeSlotTextColor",
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
                name: "CustomerPortalCardColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "InputBackgroundColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "InputBorderColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "InputFocusColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "InputTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "LabelTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TimeSlotActiveBackgroundColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TimeSlotActiveTextColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TimeSlotBackgroundColor",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TimeSlotTextColor",
                table: "Businesses");
        }
    }
}
