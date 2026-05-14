using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessWeeklyOpeningHours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "FridayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "FridayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FridayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MondayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "MondayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MondayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SaturdayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "SaturdayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SaturdayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SundayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "SundayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "SundayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ThursdayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "ThursdayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ThursdayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TuesdayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "TuesdayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TuesdayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WednesdayClosingTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "WednesdayIsOpen",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WednesdayOpeningTime",
                table: "Businesses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FridayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FridayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "FridayOpeningTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "MondayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "MondayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "MondayOpeningTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SaturdayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SaturdayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SaturdayOpeningTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SundayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SundayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "SundayOpeningTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ThursdayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ThursdayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "ThursdayOpeningTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TuesdayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TuesdayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "TuesdayOpeningTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "WednesdayClosingTime",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "WednesdayIsOpen",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "WednesdayOpeningTime",
                table: "Businesses");
        }
    }
}
