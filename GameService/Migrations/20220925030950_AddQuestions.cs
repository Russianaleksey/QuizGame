using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizGame.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProblemStatement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Answer", "ProblemStatement", "Type" },
                values: new object[,]
                {
                    { 1, "Enigma", "What's the name of the machine used by the allies in WW2 to crack Germany's codes?", 2 },
                    { 2, "Alan Turing", "Who is the father of computer science?", 2 },
                    { 3, "Apple 1", "What was the first computer system that used color display?", 2 },
                    { 4, "Ada Lovelace", "What was the name of the first computer programmer?", 2 },
                    { 5, "Intel", "Which popular company designed the first CPU?", 2 },
                    { 6, "Commodore 64", "Which is the single most popular computer system ever sold?", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
