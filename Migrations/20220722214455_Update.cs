using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 3,
                column: "TrackName",
                value: "Sunny");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 3,
                column: "TrackName",
                value: "Yellow");
        }
    }
}
