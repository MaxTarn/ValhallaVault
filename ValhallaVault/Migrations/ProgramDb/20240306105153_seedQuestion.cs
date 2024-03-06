using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations.ProgramDb
{
    /// <inheritdoc />
    public partial class seedQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Explanation", "Question", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri.", "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank...", 1 },
                    { 2, "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri.", "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida...", 2 },
                    { 3, "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier.", "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag...", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
