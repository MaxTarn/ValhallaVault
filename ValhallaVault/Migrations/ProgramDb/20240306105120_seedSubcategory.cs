using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations.ProgramDb
{
    /// <inheritdoc />
    public partial class seedSubcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "Name", "SegmentId" },
                values: new object[,]
                {
                    { 1, "Kreditkortsbedrägeri", 1 },
                    { 2, "Romansbedrägeri", 1 },
                    { 3, "Investeringsbedrägeri", 1 },
                    { 4, "Telefonbedrägeri", 1 },
                    { 5, "Digital säkerhet på företag", 4 },
                    { 6, "Risker och beredskap", 4 },
                    { 7, "Cyberangrepp mot känsliga sektorer", 4 },
                    { 8, "Allmänt om cyberspionage", 6 },
                    { 9, "Metoder för cyberspionage", 6 },
                    { 10, "Säkerhetsskyddslagen", 6 },
                    { 11, "Cyberspionagets aktörer", 6 },
                    { 12, "Social engineering", 7 },
                    { 13, "Virus, maskar och trojaner", 8 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
