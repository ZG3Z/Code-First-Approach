using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 5, "Ken", "Lee", "Kee" });

            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdTrack", "IdMusician" },
                values: new object[] { 8, 5 });

            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdTrack", "IdMusician" },
                values: new object[] { 9, 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician_Track",
                keyColumns: new[] { "IdTrack", "IdMusician" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "Musician_Track",
                keyColumns: new[] { "IdTrack", "IdMusician" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 5);
        }
    }
}
