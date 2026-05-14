using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasySystems.Bookings.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeBusinessModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_BusinessId",
                table: "StaffMembers");

            migrationBuilder.DropIndex(
                name: "IX_Services_BusinessId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_BusinessUsers_BusinessId",
                table: "BusinessUsers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BusinessId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StaffMemberId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_BusinessId_FullName",
                table: "StaffMembers",
                columns: new[] { "BusinessId", "FullName" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessId_Name",
                table: "Services",
                columns: new[] { "BusinessId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUsers_BusinessId_UserId",
                table: "BusinessUsers",
                columns: new[] { "BusinessId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BusinessId_StartTime",
                table: "Bookings",
                columns: new[] { "BusinessId", "StartTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StaffMemberId_StartTime_EndTime",
                table: "Bookings",
                columns: new[] { "StaffMemberId", "StartTime", "EndTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StaffMembers_BusinessId_FullName",
                table: "StaffMembers");

            migrationBuilder.DropIndex(
                name: "IX_Services_BusinessId_Name",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_BusinessUsers_BusinessId_UserId",
                table: "BusinessUsers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BusinessId_StartTime",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StaffMemberId_StartTime_EndTime",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_BusinessId",
                table: "StaffMembers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessId",
                table: "Services",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUsers_BusinessId",
                table: "BusinessUsers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BusinessId",
                table: "Bookings",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StaffMemberId",
                table: "Bookings",
                column: "StaffMemberId");
        }
    }
}
