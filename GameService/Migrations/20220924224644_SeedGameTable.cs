using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizGame.Migrations
{
    /// <inheritdoc />
    public partial class SeedGameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Games_GameId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Name", "State" },
                values: new object[,]
                {
                    { 1, "AlexGame", 0 },
                    { 2, "BigGamersOnly", 0 },
                    { 3, "SmallGamersOnly", 0 }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "BoardSize", "FriendlyName", "GameId", "Spaces" },
                values: new object[,]
                {
                    { 1, 18, "GiraffeBoard", 1, "0200400001000300" },
                    { 2, 18, "CheetahBoard", 2, "0200400001000300" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "GameId", "Name", "Space" },
                values: new object[,]
                {
                    { 1, 1, "Alex", 0 },
                    { 2, 1, "Brian", 0 },
                    { 3, 1, "Jahlaud", 0 },
                    { 4, 1, "Adrian", 0 },
                    { 5, 1, "Felix", 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Games_GameId",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Games_GameId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Games_GameId",
                table: "Boards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Games_GameId",
                table: "Players",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
