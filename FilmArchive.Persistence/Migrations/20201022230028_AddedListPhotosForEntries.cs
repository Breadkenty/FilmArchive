using System;
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

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date" },
                values: new object[] { "Boston Day 1", Convert.ToDateTime("2019-10-26") });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date" },
                values: new object[] { "Boston Day 2", Convert.ToDateTime("2019-10-27") });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date" },
                values: new object[] { "Boston Day 3", Convert.ToDateTime("2019-10-28") });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date" },
                values: new object[] { "Boston Day 4", Convert.ToDateTime("2019-10-29") });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date" },
                values: new object[] { "Boston Day 5", Convert.ToDateTime("2019-10-30") });
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
