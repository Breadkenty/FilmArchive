using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FilmArchive.Persistence.Migrations
{
    public partial class InitialCreate : Migration
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
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
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
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Boston Day 1", Convert.ToDateTime("2019-10-26"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903308604-4FYTJERN4KB7DRGFTOUE/ke17ZwdGBToddI8pDm48kNbizM5OkB-RBUgmw9y79VN7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UQfOX0O5wFyjEgG-JmDbVi5AxM6g0nwIUZoExYZifdsNTi8HWjhfOMceW7FFMLdz1Q/OM1_Portra800_400_003e.jpg?format=1000w",
                "First day in Boston, flying in to Boston Logan Airport." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Boston Day 2", Convert.ToDateTime("2019-10-27"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903454051-I2F329IAKYCWE580W93S/ke17ZwdGBToddI8pDm48kAgiLOzCI5j47JYUc5dgpTh7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UXTUJl3IouK8Xxay_FDruj3OH2FLvYL86yEvQsAsIZqZSs5CAANMhu2QxtIYfHKheg/OM1_Portra800_400_013e.jpg?format=1000w",
                "Second day in Boston, spent the day in the Boston Museum of Science. It was raining pretty much the entire day. We had dinner at the Gourmet Dumpling House in Chinatown." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Boston Day 3", Convert.ToDateTime("2019-10-28"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574903606245-1QD6CALY7XKXYUDAHMIU/ke17ZwdGBToddI8pDm48kAKOKkSLaMVG-jmHOCi20md7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Udhjzm8e6VFdG7xeze4O3oyXCUNWmMtnFIgTSV2xXxKN7MB8RRNkkHdL3mDhBVBkcA/14_OM1_Portra800_400_020e.jpg?format=1000w",
                "Started the day at working remotely in Boston Univerity. Walked over to the Harvard Campus to meet up with Jose to take a class on SQL by David Milan. We then had dinner at Pinocchio's Pizza & Subs followed by exploring more of Cambridge." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Boston Day 4", Convert.ToDateTime("2019-10-29"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1575589686327-U8TG8T8VJ0AI3YUF97J8/ke17ZwdGBToddI8pDm48kIWvDNhd5re3IU8vCqWJmWB7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1USm-YWmAMP8HNlW5uZgL1i6kqh0rBaYX8GEuFORMJVbQoaB7cXlC74RGNr1M0KekWQ/82_Camerainfo.jpg?format=1000w",
                "Started the day with Boston Duck Tour. Exploring the North End grabbing some pastry from Bova's Bakery. From there we started to follow the Freedom Trail going through the Quincy Market area to the Boston Public Garden. From there we continued to walk toward the Prudential Tower getting lunch at Eataly. After visiting the top floor in the tower, we started to make our way to the Fenway Garden. From there Jose and I visited some music stores near the Berklee College of Music. Walked around the Boston Public Library, got some hot chocolate, walked around Charles St., made our way towards the reflecting pool trying to find the Guitar Center. That door in the end is the Starbucks bathroom door where some guy was taking his sweet time, while having to pee really bad." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Boston Day 5", Convert.ToDateTime("2019-10-30"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574904783145-F8XHWRJNPO0L5TPXR870/ke17ZwdGBToddI8pDm48kNx5nWostyGLDXgtP6oTqa97gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UTBOE8dUvI6A1AfXrXM_XnE1wI7c1Cdo4RAe48FANOcwjIjg7l_3EkjvTQ6EpWDFFA/57_Scans-205.jpg?format=1000w",
                "Started the day with remote working at Harvard. This is where I met a photographer named Joe Frank, who commented on my Rolleiflex. After exploring around Harvard Square once again, I made my way over to the Kennedy School to reflect on my failed relationship with Juliahna. Afterwards, Jose and I met up at the Taza Chocolate Factory to attend a tour. The chocolates they had were really bitter and gritty, but it was good. We had lunch at India Palace, then had ice cream at Toscanini's. We split up so Jose can check out the MIT campus. I went to find the Esplanade trying to find a very specific spot. I was not able to find it, after talking to a few people, so I went back to our AirBnB to get ready for the Jonsi and Alex's Rice Boy Sleeps concert. We waited in the back to see if Jonsi and Alex would come out to meet us. This is where I met Caroline, her boyfriend, and Alessandra. " });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Pacific Road Trip Day 9", Convert.ToDateTime("2020-08-27"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1599177315799-3XVM3WWH1HP47SD140MO/ke17ZwdGBToddI8pDm48kEEXJqT6UZzo6_T_IEtk8lR7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ua7GyuyleZfZLbh1TL99aL4EVZ3HdY4X3R4vaGMghUvwBPQhVEbTV4SmYd07HZaZ-g/Rolleiflex_Fuji400H_400_8.jpg?format=1000w",
                "Started the day at the Avenue of Giants, most of the drive in the Redwoods was foggy and the Sun appeared to be red because of the nearby forest fire happening. We kept driving down the pacific coast until we reached to San Francisco. Me and Jordan walked across the Golden Gate bridge, while Benji waited in the car. It was really windy. We then decided to get Indian food in downtown near Union Square and made out way to Pier 39 to find some sour dough bread at Boudin's. From there we drove up the San Francisco's downtown hill and caught a glimpse of the sunset on the Oakland Bay Bridge. We drove to Santa Cruz, and had to take a detour that set us back an hour because of a closure in the road due to the forest fire. People were evacuating to Santa Cruz and we almost lost our hotel reservation because of it. Benji lied to them saying it was a work trip." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Pacific Road Trip Day 8", Convert.ToDateTime("2020-08-26"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1599177206651-DWYZG99KMTEPR30MBOI0/ke17ZwdGBToddI8pDm48kEEXJqT6UZzo6_T_IEtk8lR7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ua7GyuyleZfZLbh1TL99aL4EVZ3HdY4X3R4vaGMghUvwBPQhVEbTV4SmYd07HZaZ-g/Rolleiflex_Fuji400H_400_9.jpg?format=1000w",
                "Starting from Florence in Oregon, we've stopped at Sister's Rock to check out the cave. From there we visited the Redwoods National Park and did a short hike. We got our pins and drove through the Avenue of Giants, catching some cool light and fog. " });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Pacific Road Trip Day 7", Convert.ToDateTime("2020-08-25"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1599177121599-9BNF2NL5PEAW1ETC5HQH/ke17ZwdGBToddI8pDm48kEEXJqT6UZzo6_T_IEtk8lR7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ua7GyuyleZfZLbh1TL99aL4EVZ3HdY4X3R4vaGMghUvwBPQhVEbTV4SmYd07HZaZ-g/Rolleiflex_Fuji400H_400_19.jpg?format=1000w",
                "Started the drive from Steve's house, we made out way to Astoria to begin driving down the pacific coast. We visited Cape Disappointment because we thought the name was funny. After passing through Astoria and the bridge, we made our way into Oregon and checked out many things on our way to our next destination. Cannon beach, Cape Kiwanda, and Thor's Well in Cape Perpetua. Thor's Well was definitely scary with how windy it was down there, the energy of the water flowing was something else." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Pacific Road Trip Day 6", Convert.ToDateTime("2020-08-24"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1599176845527-ZBZN43J8YABZNGIXZENC/ke17ZwdGBToddI8pDm48kEEXJqT6UZzo6_T_IEtk8lR7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Ua7GyuyleZfZLbh1TL99aL4EVZ3HdY4X3R4vaGMghUvwBPQhVEbTV4SmYd07HZaZ-g/Rolleiflex_Fuji400H_400_1.jpg?format=1000w",
                "Explored Seattle going to places like Pike's Market Place and the Space Needle. We then met up with Jorge and Michaela at Green Lake. We made our way to Discovery Park to hike a short trail down to the beach. We ordered some takeout Indian food and ate at Jorge's apartment. He showed us his art he was working on and gave Benji and Jordan some geodes. " });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Sequoia National Forest", Convert.ToDateTime("2018-11-27"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1551540558425-F2GKDV2XEZT6RA8OMHAL/ke17ZwdGBToddI8pDm48kNiEM88mrzHRsd1mQ3bxVct7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0s0XaMNjCqAzRibjnE_wBlkZ2axuMlPfqFLWy-3Tjp4nKScCHg1XF4aLsQJlo6oYbA/112718_Rollei_Ektar_100_010.jpg?format=1000w",
                "We drove around 4 hours to get to the Sequoia National Forest. We had to wait about thirty minutes because the road was closed near the top of the mountain. After getting through, we came across giant sequoia trees. When hiking, we felt some of the trees and surprisingly they are soft, hollow, and fuzzy. We started to drive back around sun down, saw some stars near the Mojave Desert." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Mojave Desert", Convert.ToDateTime("2020-11-27"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1551540411593-38J7OBC1HVS1O0265SY5/ke17ZwdGBToddI8pDm48kNiEM88mrzHRsd1mQ3bxVct7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0s0XaMNjCqAzRibjnE_wBlkZ2axuMlPfqFLWy-3Tjp4nKScCHg1XF4aLsQJlo6oYbA/112718_Rollei_Ektar_100_006.jpg?format=1000w",
                "On our way to the Sequoia National Forest, we passed by the Mojave Desert. Saw this on our way." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Joshua Tree National Park", Convert.ToDateTime("2018-07-09"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1551310652946-8YLLE5ZOWS01K9KZ3BQR/ke17ZwdGBToddI8pDm48kNiEM88mrzHRsd1mQ3bxVct7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0s0XaMNjCqAzRibjnE_wBlkZ2axuMlPfqFLWy-3Tjp4nKScCHg1XF4aLsQJlo6oYbA/9.jpg?format=1000w",
                "We hiked and drove all around Joshua Tree National Park. There were a lot of cacti. Made a lot of \"No time to explain, grab a cactus\" joke." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Dash's Birthday Party", Convert.ToDateTime("2018-05-11"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1551311424645-ABA1BUF3UADIULN0SGO7/ke17ZwdGBToddI8pDm48kNcKbxpnv5VyW17YqWwYalF7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0oycmklwMHPwSb2Cr-KYzbreo3AdJijb0m4rmHl7_a7QDQ8-aut-wbauSBr9s231pA/051118_AE1_TriX_009.jpg?format=1000w",
                "Rin put together a surprise party for Dash and we all hid in his room when he came in. We played with RC cars and I met people like Patrick, Jan, and Chika."});

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Pacific Coast Adventure", Convert.ToDateTime("2018-11-18"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1551539206727-PPGS4H47NHNFAB1JKBBF/ke17ZwdGBToddI8pDm48kNiEM88mrzHRsd1mQ3bxVct7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0s0XaMNjCqAzRibjnE_wBlkZ2axuMlPfqFLWy-3Tjp4nKScCHg1XF4aLsQJlo6oYbA/112518_Rollei_Ektar_100_007.jpg?format=1000w",
                "Got together with Carla and Benji to drive a little bit of the pacific coast highway. We made our way towards Ventura and saw tidal pools and anemones at Rincon Beach." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Kelly Park Rock Springs", Convert.ToDateTime("2018-10-07"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1551310333964-7XNFKXUCPC91EU2D1Z82/ke17ZwdGBToddI8pDm48kPObLdK6l9JR4EeKem0lUkN7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UY12saxwsIF1BQsnRUdmoZ-Ye_-yYhGAxP5FHxsqh93NxjuXoyzrtt4o1hWxZTq8Jw/026267-R1-011.jpg?format=1000w",
                "To catch a little bit of summer left, Juliahna, Malachi, Dakota, Elijah, Zack, Manami, Will, Patrick, Jan, Dash, and I all met up at Kelly Park. Juliahna came over and rode with me to Apopka catching up on our lives. We established that if we start walking, people will eventually follow us. We had a moment where we talked about how we all could possibly perceive colors differently while skipping rocks. Dash invited us to join him for dinner at Rin's work who fed us all for free. We then visited Dash's house and played some VR. Spent most of the day getting a long with Juliahna." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Second Day in Asheville", Convert.ToDateTime("2018-01-04"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1552690595753-VUXMCZ1YVGB1AJXHZ8W4/ke17ZwdGBToddI8pDm48kN0Et4GHtB6MzGt3ozOCjIt7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UWydQAO6JF7ccBAVwUr_wFfLbBKS1agnjvbqpSukNHRVFlq8oZZwhhoTbTOjCpwBwg/010418_M7_EKTAR_100_001.jpg?format=1000w",
                "This day started with seeing snow for the first time since living in Japan. We made our way to the Smokey Mountains. Once we got back, we walked around Asheville with Wanessa and had some hot chocolate. She told me about how she is having a rough time since her marriage. She's in Asheville trying to figure something out. She also mentioned she wants to move to Italy some day." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Cumberland Island", Convert.ToDateTime("2017-12-30"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574993734147-4ECDZEPUN4KQMSHMRXHJ/ke17ZwdGBToddI8pDm48kJm83r3_OWfoaznv_JFuXR17gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UQ3wTtJOt1L0c9Um6kGmfmqFrCpL9H5VSekBTvccASQ5rLjIQLbmY-JxC_jL2SKZiA/22_M7_HP5_400_046.jpg?format=1000w",
                "To close out" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Villa Viscaya", Convert.ToDateTime("2017-06-17"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574990350616-ZMW341VH19LJO1ODL5JG/ke17ZwdGBToddI8pDm48kKBZURXHI__Vizj_ZdqR7kp7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Uaq6a5bx18ISQjcJYQ6n5Ipw9zzksrJwX1ZoTJZIUyyBDi005ms6_8u9A4oz400EjQ/061017_M7_400H_200_006.jpg?format=1000w",
                "Second day in Cumberland Island. We walked towards a beach without footsteps. We some junk along the beach and a sculpture. We decided to hike at night where the moon light guided our way. It was a full moon. We found a cemetary and the Carnegie's property." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Blairsville and Helton Creek Falls with Sam", Convert.ToDateTime("2016-09-17"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1558737833471-IJ7Q886TCXQHVCC67FLJ/ke17ZwdGBToddI8pDm48kOcKQOVP5FDSs_EL08_6W_J7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0ooWhOa5cxQSJsU3rXf8luVcmz7NX71clcckZLuVjefRAr7QZb5hkcd4iYmGYODbDA/5363_06.jpg?format=1000w",
                "Started with doing Yoga with the other wedding guests. Afterwards Sam and I had some coffee at the town square, and grabbed some gas at the Exxon. We went to hike at Helton Creek Falls afterwards. We came across Jacqueline from Voila Cinematics who mentioned there was a gas shortage. Later that night, we attended Justin's wedding. Alex from Voila Cinematics had an issue where their tank was low. We tried to syphon gas out of my car but nothing worked. He borrowed my car to see if he could find any gas. It was a long night." });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new string[] { "Title", "Date", "ThumbnailUrl", "Notes" },
                values: new object[] { "Grand Canyon, Day 3", Convert.ToDateTime("2015-07-11"), "https://images.squarespace-cdn.com/content/v1/5c75bf3af4755a07a9edee16/1574986751339-R9LWBM7SE4TY4LYZRIB4/ke17ZwdGBToddI8pDm48kHgA9hsnY_PIiBArNGuACy57gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1Uetz9Fj_UbkDG16VxPHxDW-byCz4s4yl1_0GHmq7qVsxDk-aW0WIdZ70CxZYZblwSA/3.jpg?format=1000w",
                "The third day at the Grand Canyon. I woke up really early to catch sunrise at Powell point. We then decided to hike the hermit trail. My dad could not follow through so we decided to turn around together. The trail was not that pretty anyways." });

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
