using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmArchive.Persistence.Migrations
{
    public partial class AddedListPhotosForEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_EntryId",
                table: "Photos",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Entries_EntryId",
                table: "Photos",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Entries_EntryId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_EntryId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Photos");
        }
    }
}
