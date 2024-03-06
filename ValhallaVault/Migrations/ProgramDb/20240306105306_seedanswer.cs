using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations.ProgramDb
{
    /// <inheritdoc />
    public partial class seedanswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Answer", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Ett potentiellt telefonbedrägeri", true, 1 },
                    { 2, "Ett legitimt försök från banken att skydda ditt konto", false, 1 },
                    { 3, "En informationsinsamling för en marknadsundersökning", false, 1 },
                    { 4, "Ett romansbedrägeri", true, 2 },
                    { 5, "En legitim begäran om hjälp från en person i nöd", false, 2 },
                    { 6, "Investeringsbedrägeri", true, 3 },
                    { 7, "Genomföra omedelbar investering för att inte missa möjligheten", false, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
