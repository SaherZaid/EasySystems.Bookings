using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBusinessUserPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOwner",
                table: "BusinessUsers",
                newName: "CanManageStaff");

            migrationBuilder.AddColumn<bool>(
                name: "CanManageBookings",
                table: "BusinessUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageCalendar",
                table: "BusinessUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageServices",
                table: "BusinessUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanManageSettings",
                table: "BusinessUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "BusinessUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanManageBookings",
                table: "BusinessUsers");

            migrationBuilder.DropColumn(
                name: "CanManageCalendar",
                table: "BusinessUsers");

            migrationBuilder.DropColumn(
                name: "CanManageServices",
                table: "BusinessUsers");

            migrationBuilder.DropColumn(
                name: "CanManageSettings",
                table: "BusinessUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "BusinessUsers");

            migrationBuilder.RenameColumn(
                name: "CanManageStaff",
                table: "BusinessUsers",
                newName: "IsOwner");
        }
    }
}
