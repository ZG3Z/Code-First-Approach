using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track");

            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Track",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 4, "Kim", "White", "WhiteK" });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 9, 3.1800000000000002, null, "Love" });

            migrationBuilder.InsertData(
                table: "Musician_Track",
                columns: new[] { "IdTrack", "IdMusician" },
                values: new object[] { 9, 4 });

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track");

            migrationBuilder.DeleteData(
                table: "Musician_Track",
                keyColumns: new[] { "IdTrack", "IdMusician" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "IdTrack",
                keyValue: 9);

            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Track",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_Album_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum",
                principalTable: "Album",
                principalColumn: "IdAlbum",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
