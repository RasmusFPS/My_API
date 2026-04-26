using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MYAPI.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Links_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Interest",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "The act of writing code and developing a product/application", "Programing" },
                    { 2, "Listening or creating music", "Music" },
                    { 3, "Playing or Creating Games", "Gaming" },
                    { 4, "Completing a task/game as fast as you can", "Speedrunning" },
                    { 5, "Creating delicious food", "Cooking" }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "LinkId", "PersonId", "URL" },
                values: new object[,]
                {
                    { 1, null, null, "https://www.w3schools.com/" },
                    { 2, null, null, "https://open.spotify.com/" },
                    { 3, null, null, "https://steamcommunity.com/id/RasmusFPS/" },
                    { 4, null, null, "https://www.speedrun.com/users/RasmusFPS/" },
                    { 5, null, null, "https://www.arla.se/recept/" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Name", "Phone_Number" },
                values: new object[,]
                {
                    { 1, "Malte Andersson", "070-000-0000" },
                    { 2, "Max Granqvist", "070-000-0000" },
                    { 3, "Ben Thomasson", "070-000-0000" },
                    { 4, "Rasmus Andersen", "070-000-0000" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinkId",
                table: "Links",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interest");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
