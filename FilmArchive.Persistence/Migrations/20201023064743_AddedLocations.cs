using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FilmArchive.Persistence.Migrations
{
    public partial class AddedLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ThumbnailUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(nullable: true),
                    Stock = table.Column<string>(nullable: true),
                    Iso = table.Column<int>(nullable: false),
                    Size = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(nullable: true),
                    CameraId = table.Column<int>(nullable: true),
                    FilmId = table.Column<int>(nullable: true),
                    ExposureIndex = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    EntryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CameraId",
                table: "Photos",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_EntryId",
                table: "Photos",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_FilmId",
                table: "Photos",
                column: "FilmId");

            //Entry 

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl" },
                values: new object[] { "Boston Day 1", Convert.ToDateTime("2019-10-26"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903308604-4FYTJERN4KB7DRGFTOUE/ke17ZwdGBToddI8pDm48kNbizM5OkB-RBUgmw9y79VN7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UQfOX0O5wFyjEgG-JmDbVi5AxM6g0nwIUZoExYZifdsNTi8HWjhfOMceW7FFMLdz1Q/OM1_Portra800_400_003e.jpg?format=1000w" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl" },
                values: new object[] { "Boston Day 2", Convert.ToDateTime("2019-10-27"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903454051-I2F329IAKYCWE580W93S/ke17ZwdGBToddI8pDm48kAgiLOzCI5j47JYUc5dgpTh7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UXTUJl3IouK8Xxay_FDruj3OH2FLvYL86yEvQsAsIZqZSs5CAANMhu2QxtIYfHKheg/OM1_Portra800_400_013e.jpg?format=1000w" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl" },
                values: new object[] { "Boston Day 3", Convert.ToDateTime("2019-10-28"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903606245-1QD6CALY7XKXYUDAHMIU/ke17ZwdGBToddI8pDm48kAKOKkSLaMVG-jmHOCi20md7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Udhjzm8e6VFdG7xeze4O3oyXCUNWmMtnFIgTSV2xXxKN7MB8RRNkkHdL3mDhBVBkcA/14_OM1_Portra800_400_020e.jpg?format=1000w" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl" },
                values: new object[] { "Boston Day 4", Convert.ToDateTime("2019-10-29"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589686327-U8TG8T8VJ0AI3YUF97J8/ke17ZwdGBToddI8pDm48kIWvDNhd5re3IU8vCqWJmWB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USm-YWmAMP8HNlW5uZgL1i6kqh0rBaYX8GEuFORMJVbQoaB7cXlC74RGNr1M0KekWQ/82_Camerainfo.jpg?format=1000w" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl" },
                values: new object[] { "Boston Day 5", Convert.ToDateTime("2019-10-30"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904783145-F8XHWRJNPO0L5TPXR870/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/57_Scans-205.jpg?format=1000w" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl" },
                values: new object[] { "Pacific Road Trip Day 9", Convert.ToDateTime("2020-08-27"), "" });

            // Camera

            migrationBuilder.InsertData(
                table: "Cameras",
                columns: new string[] { "Brand", "Model", "Year" },
                values: new object[] { "Rolleiflex", "2.8E", 1956 });

            migrationBuilder.InsertData(
                table: "Cameras",
                columns: new string[] { "Brand", "Model", "Year" },
                values: new object[] { "Olympus", "OM-1", 1972 });

            // Film

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Portra", 800, "35mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Portra", 800, "120mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Portra", 400, "35mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Portra", 400, "120mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Ektar", 100, "35mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Ektar", 100, "120mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Tri-X", 400, "35mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Kodak", "Tri-X", 400, "120mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Fujifilm", "Fujicolor Pro", 400, "35mm" });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new string[] { "Brand", "Stock", "Iso", "Size" },
                values: new object[] { "Fujifilm", "Fujicolor Pro", 400, "120mm" });

            // Day 1

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903278804-0P9J7IUA4IXGCE5ETNYK/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/OM1_Portra800_400_002e.jpg?format=1000w",
                 2, 1, 400, 1, "Boston Logan Airport", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903291452-INR1ONWDM5S0OBVMPSWS/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/OM1_Portra800_400_001e.jpg?format=1000w",
                 2, 1, 400, 1, "Boston Logan Airport", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903308604-4FYTJERN4KB7DRGFTOUE/ke17ZwdGBToddI8pDm48kNbizM5OkB-RBUgmw9y79VN7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UQfOX0O5wFyjEgG-JmDbVi5AxM6g0nwIUZoExYZifdsNTi8HWjhfOMceW7FFMLdz1Q/OM1_Portra800_400_003e.jpg?format=1000w",
                 2, 1, 400, 1, "Boston Logan Airport", "Boston", "Massachusetts", "United States" });

            // Day 2

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903392486-NNBSBDGZS97OHQZZRGCK/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/OM1_Portra800_400_006e.jpg?format=1000w",
                 2, 1, 400, 2, "", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903430471-QELZ1N237C5261QK1PX5/ke17ZwdGBToddI8pDm48kPyxK6AB3zgGizbLyl3cQLF7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0hHMyhIh2kKzuOL3ydJCryA1F0gmNLmEt4Nikyd91URavr8Aoi-yShiL3L-0iJr14g/OM1_Portra800_400_010e.jpg?format=1000w",
                 2, 1, 400, 2, "Craigie Drawbridge", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903448449-YOMT9TFCJI1VU1ICXT7M/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/OM1_Portra800_400_012e.jpg?format=1000w",
                 2, 1, 400, 2, "Gourmet Dumpling House", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903454051-I2F329IAKYCWE580W93S/ke17ZwdGBToddI8pDm48kAgiLOzCI5j47JYUc5dgpTh7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UXTUJl3IouK8Xxay_FDruj3OH2FLvYL86yEvQsAsIZqZSs5CAANMhu2QxtIYfHKheg/OM1_Portra800_400_013e.jpg?format=1000w",
                 2, 1, 400, 2, "China Town", "Boston", "Massachusetts", "United States" });

            // Day 3

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903606245-1QD6CALY7XKXYUDAHMIU/ke17ZwdGBToddI8pDm48kAKOKkSLaMVG-jmHOCi20md7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Udhjzm8e6VFdG7xeze4O3oyXCUNWmMtnFIgTSV2xXxKN7MB8RRNkkHdL3mDhBVBkcA/14_OM1_Portra800_400_020e.jpg?format=1000w",
                 2, 1, 400, 3, "Harvard Yard", "Cambridge", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903633271-T76OZO1K7AUQ1IG4N7AA/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/16_OM1_Portra800_400_022e.jpg?format=1000w",
                 2, 1, 400, 3, "Harvard Yard", "Cambridge", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903676408-Q83AJOIDCNTOGAZP813V/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/21_OM1_Portra800_400_026e.jpg?format=1000w",
                 2, 1, 400, 3, "Pinocchio's Pizza & Subs", "Cambridge", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903714144-BPZD6QRRQBUYNBVG1DJE/ke17ZwdGBToddI8pDm48kCwWnkahvujsqG80lzpLa1V7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UVC5ZpYmsTjRgXnATrG0uuMiXOsL6n7HNkmV6yUfNoitDA5MuYbduysEDAM1kV879Q/24_OM1_Portra800_400_029e.jpg?format=1000w",
                 2, 1, 400, 3, "Allston", "Boston", "Massachusetts", "United States" });

            // Day 4

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589309324-HMQEIPSAM0DDY0B4GGKS/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/21_Camerainfo.jpg?format=1000w",
                 2, 3, 320, 4, "North End", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589393191-34JNDHB6E2F61R00X4ZU/ke17ZwdGBToddI8pDm48kEEXJqT6UZzo6_T_IEtk8lR7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ua7GyuyleZfZLbh1TL99aL4EVZ3HdY4X3R4vaGMghUvwBPQhVEbTV4SmYd07HZaZ-g/33_Camerainfo.jpg?format=1000w",
                 1, 8, 1600, 4, "Bova's Bakery", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589403540-R744SK4YWSMDFM9XSVBZ/ke17ZwdGBToddI8pDm48kIWvDNhd5re3IU8vCqWJmWB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USm-YWmAMP8HNlW5uZgL1i6kqh0rBaYX8GEuFORMJVbQoaB7cXlC74RGNr1M0KekWQ/35_Camerainfo.jpg?format=1000w",
                 1, 6, 80, 4, "North End", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589656965-8M7JD5CQMV3BFMW4106H/ke17ZwdGBToddI8pDm48kIWvDNhd5re3IU8vCqWJmWB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USm-YWmAMP8HNlW5uZgL1i6kqh0rBaYX8GEuFORMJVbQoaB7cXlC74RGNr1M0KekWQ/76_Camerainfo.jpg?format=1000w",
                 1, 10, 200, 4, "Copley Square", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589659599-H91B366T56PQMWEH7UTL/ke17ZwdGBToddI8pDm48kF-imn3yIemqnV5BjuPqbAZ7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UbZjts64qOVeh8VmvWRMaDn-L6Iu3_ClSRk-p2KLzpzsitOsjnk4bl7vPmBic-oxrQ/77_Camerainfo.jpg?format=1000w",
                 1, 10, 200, 4, "Copley Square", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589686327-U8TG8T8VJ0AI3YUF97J8/ke17ZwdGBToddI8pDm48kIWvDNhd5re3IU8vCqWJmWB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USm-YWmAMP8HNlW5uZgL1i6kqh0rBaYX8GEuFORMJVbQoaB7cXlC74RGNr1M0KekWQ/82_Camerainfo.jpg?format=1000w",
                 1, 10, 200, 4, "Prudential Tower", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589747321-VEBNHBE6QS5TXUVWQ5JT/ke17ZwdGBToddI8pDm48kAi8gAE8kOpYSq45WyyTPcB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ueeyb-gJS8pg1Ayk2DcXrIwWY9WdIGj3NiGUu5Zv-sOXBsc6d8xABtQMYHwnG515BA/92_Camerainfo.jpg?format=1000w",
                 2, 7, 1600, 4, "Boston Public Library", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589766561-DDZ0XPX37P7MATTSCZVZ/ke17ZwdGBToddI8pDm48kGizRh-Q8s_bc3pa1UIqpHV7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USH90PdmNXZowNk-1nplEceP15gbuqX22Lpgs32wta6vr1HYy7g08hHol-DJo4Pjhw/97_Camerainfo.jpg?format=1000w",
                 2, 7, 1600, 4, "L.A Burdick Handmade Chocolates on Clarendon St.", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589820370-IF22PNI1UXMAR31J7PXY/ke17ZwdGBToddI8pDm48kAi8gAE8kOpYSq45WyyTPcB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ueeyb-gJS8pg1Ayk2DcXrIwWY9WdIGj3NiGUu5Zv-sOXBsc6d8xABtQMYHwnG515BA/107_Camerainfo.jpg?format=1000w",
                 2, 7, 1600, 4, "Huntington Ave.", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589841014-09V7DCMQGRI39NFKTMFW/ke17ZwdGBToddI8pDm48kOkBANitGbn8LmDuhO5BYnF7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UcWzXWuxEurD6iCq-z89vFp5IHcKvuAD_kEv429iAxQjQKnkgu1CjACuGd09OcDW5A/111_Camerainfo.jpg?format=1000w",
                 2, 7, 1600, 4, "Boston Symphony Orchestra", "Boston", "Massachusetts", "United States" });

            // Day 5

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904418205-4N93G9VTVQDSXPT82KHT/ke17ZwdGBToddI8pDm48kIWvDNhd5re3IU8vCqWJmWB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USm-YWmAMP8HNlW5uZgL1i6kqh0rBaYX8GEuFORMJVbQoaB7cXlC74RGNr1M0KekWQ/1_Scans-135.jpg?format=1000w",
                 1, 10, 200, 4, "Harvard Yard", "Cambridge", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904488409-1Q0U8XKEIUAUV2DJ5BM6/ke17ZwdGBToddI8pDm48kDBJr0AumMkUhdBnj9TSR-x7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTYp609Nc4ZdcUA4VZ0HidYsCgS6faf_g6VPz7aVJdY6iesm8fpB3zYw4SZR-AlygA/11_Rollei_TriX_1600_004.jpg?format=1000w",
                 1, 8, 1600, 4, "Harvard Square", "Cambridge", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904512671-YJEZI0ASKTR75CF3264Q/ke17ZwdGBToddI8pDm48kEEXJqT6UZzo6_T_IEtk8lR7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ua7GyuyleZfZLbh1TL99aL4EVZ3HdY4X3R4vaGMghUvwBPQhVEbTV4SmYd07HZaZ-g/15_Rollei_TriX_1600_008.jpg?format=1000w",
                 1, 8, 1600, 4, "Harvard Square", "Cambridge", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904659180-6N75BGD72DFWLIRCEO9D/ke17ZwdGBToddI8pDm48kMyX43o3HznWzvVjR9Preul7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0mhydAgiKdIfeAoxVgE7c7okPoKA5uALweq0Eh5ZSPFNMZ1UtBwwVjWySAS2xzp0KQ/36_Scans-183.jpg?format=1000w",
                 2, 3, 320, 4, "Taza Chocolate Factory", "Somerville", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904774283-L0PIP5D2PG586671GWKZ/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/55_Scans-203.jpg?format=1000w",
                 2, 3, 320, 4, "Frances Appleton Bridge", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904783145-F8XHWRJNPO0L5TPXR870/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/57_Scans-205.jpg?format=1000w",
                 2, 3, 320, 4, "Charles River Esplanade", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904841761-NZSNU38FC3FTMZBCUMFH/ke17ZwdGBToddI8pDm48kMyX43o3HznWzvVjR9Preul7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0mhydAgiKdIfeAoxVgE7c7okPoKA5uALweq0Eh5ZSPFNMZ1UtBwwVjWySAS2xzp0KQ/64_OM1_Portra400_200_002e.jpg?format=1000w",
                 2, 3, 320, 4, "The Wilbur", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904854187-KAAW1Y8T3Y3IUN7N9XJ4/ke17ZwdGBToddI8pDm48kGLiFChMyJUKMWGHLjQ_MyF7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UWn3ENzcpBZyRmeQMEY3QIc0Pqm-af_NBqo9zTR3pPaMqZXtM2t1CwhezoykTJ7VgQ/65_OM1_Portra400_200_003e.jpg?format=1000w",
                 2, 3, 320, 4, "The Wilbur", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904947979-OM2GALZQKXG57UWXHE2T/ke17ZwdGBToddI8pDm48kMyX43o3HznWzvVjR9Preul7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0mhydAgiKdIfeAoxVgE7c7okPoKA5uALweq0Eh5ZSPFNMZ1UtBwwVjWySAS2xzp0KQ/73_OM1_Portra400_200_011e.jpg?format=1000w",
                 2, 3, 320, 4, "The Wilbur", "Boston", "Massachusetts", "United States" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new string[] { "Url", "CameraId", "FilmId", "ExposureIndex", "EntryId", "Location", "City", "State", "Country" },
                values: new object[] { "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904977153-P9GZKCQIH5B20C3610WR/ke17ZwdGBToddI8pDm48kDMnNajdBOJiXJxAvQrjDUl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UcCb4xpXvJLLatBUE4d78vxP8vhg6bNuq5rIz27mPI9yrYUjRjvLI-neyS-6l0KA5A/77_OM1_Portra400_200_015e.jpg?format=1000w",
                 2, 3, 320, 4, "Downtown Crossing", "Boston", "Massachusetts", "United States" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
