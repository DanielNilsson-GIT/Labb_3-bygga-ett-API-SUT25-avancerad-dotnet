using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class seeddata_updatedrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interests_persons_PersonId",
                table: "interests");

            migrationBuilder.DropIndex(
                name: "IX_interests_PersonId",
                table: "interests");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "interests");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "interests");

            migrationBuilder.CreateTable(
                name: "personInterests",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personInterests", x => new { x.PersonId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_personInterests_interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personInterests_persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Sport med lag och boll", "Fotboll" },
                    { 2, "Skapa program och system", "Programmering" },
                    { 3, "Laga mat och testa recept", "Matlagning" },
                    { 4, "Spela datorspel", "Gaming" },
                    { 5, "Upptäcka nya platser", "Resor" },
                    { 6, "Lyssna och skapa musik", "Musik" }
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "Id", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna", "Svensson", 111111 },
                    { 2, "Björn", "Karlsson", 222222 },
                    { 3, "Cecilia", "Lind", 333333 },
                    { 4, "David", "Persson", 444444 },
                    { 5, "Elin", "Johansson", 555555 },
                    { 6, "Filip", "Berg", 666666 },
                    { 7, "Greta", "Holm", 777777 },
                    { 8, "Hugo", "Sand", 888888 },
                    { 9, "Ida", "Ek", 999999 },
                    { 10, "Johan", "Ström", 101010 }
                });

            migrationBuilder.InsertData(
                table: "personInterests",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 6, 3 },
                    { 4, 4 },
                    { 3, 5 },
                    { 5, 5 },
                    { 6, 5 },
                    { 2, 6 },
                    { 4, 6 },
                    { 5, 6 },
                    { 1, 7 },
                    { 6, 7 },
                    { 2, 8 },
                    { 3, 9 },
                    { 5, 9 },
                    { 1, 10 },
                    { 2, 10 },
                    { 3, 10 },
                    { 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "websites",
                columns: new[] { "Id", "InterestId", "PersonId", "WebSiteURL" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://fotboll.se" },
                    { 2, 3, 1, "https://recept.nu" },
                    { 3, 2, 2, "https://stackoverflow.com" },
                    { 4, 4, 2, "https://steamcommunity.com" },
                    { 5, 1, 3, "https://uefa.com" },
                    { 6, 2, 3, "https://github.com" },
                    { 7, 4, 4, "https://ign.com" },
                    { 8, 3, 5, "https://tasteline.se" },
                    { 9, 5, 5, "https://lonelyplanet.com" },
                    { 10, 2, 6, "https://unity.com" },
                    { 11, 5, 6, "https://travelguide.com" },
                    { 12, 1, 7, "https://svenskfotboll.se" },
                    { 13, 2, 8, "https://w3schools.com" },
                    { 14, 3, 9, "https://koket.se" },
                    { 15, 1, 10, "https://fifa.com" },
                    { 16, 2, 10, "https://dotnet.microsoft.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_websites_PersonId",
                table: "websites",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_personInterests_InterestId",
                table: "personInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_websites_persons_PersonId",
                table: "websites",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_websites_persons_PersonId",
                table: "websites");

            migrationBuilder.DropTable(
                name: "personInterests");

            migrationBuilder.DropIndex(
                name: "IX_websites_PersonId",
                table: "websites");

            migrationBuilder.DeleteData(
                table: "interests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "websites",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "interests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "interests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "interests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "interests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "interests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WebsiteId",
                table: "interests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_interests_PersonId",
                table: "interests",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_interests_persons_PersonId",
                table: "interests",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id");
        }
    }
}
