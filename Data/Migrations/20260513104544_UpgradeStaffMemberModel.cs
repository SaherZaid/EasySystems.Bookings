using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeStaffMemberModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowOnlineBookings",
                table: "StaffMembers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "StaffMembers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "StaffMembers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "StaffMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StaffMembers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowOnlineBookings",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StaffMembers");
        }
    }
}
