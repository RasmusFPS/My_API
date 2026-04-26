using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAPI.Migrations
{
    /// <inheritdoc />
    public partial class IntrestLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Links_LinkId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Person_PersonId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_LinkId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 3, 2 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { 5, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InterestId",
                table: "Links",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Interest_InterestId",
                table: "Links",
                column: "InterestId",
                principalTable: "Interest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Person_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Interest_InterestId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Person_PersonId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_InterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Links",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "Links",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LinkId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LinkId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LinkId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LinkId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LinkId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinkId",
                table: "Links",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Links_LinkId",
                table: "Links",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Person_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
