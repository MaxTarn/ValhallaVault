using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Att skydda sig mot Bedrägerier" },
                    { 2, "Cybersäkerhet för företag" },
                    { 3, "Cyberspionage" }
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Del 1" },
                    { 2, 1, "Del 2" },
                    { 3, 1, "Del 3" },
                    { 4, 2, "Del 1" },
                    { 5, 2, "Del 2" },
                    { 6, 3, "Del 1" },
                    { 7, 3, "Del 2" },
                    { 8, 3, "Del 3" }
                });

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
                    { 13, "Virus, maskar och trojaner", 8 },
                    { 14, "Abonnemangsfällor och falska fakturor", 5 },
                    { 15, "Ransomware", 5 },
                    { 16, "Statistik och förhållningssätt", 5 },
                    { 17, "Utpressningsvirus", 6 },
                    { 18, "Attacker mot servrar", 6 },
                    { 19, "Cyberangrepp i Norden", 6 },
                    { 20, "Varning för vishing", 7 },
                    { 21, "Identifiera VD-mejl", 7 },
                    { 22, "Öneangrepp och presentkortsbluffar", 7 },
                    { 23, "Värvningsförsök", 8 },
                    { 24, "Affärsspionage", 8 },
                    { 25, "Påverkanskampanjer", 8 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Explanation", "Question", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri.", "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank...", 1 },
                    { 2, "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri.", "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida...", 2 },
                    { 3, "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier.", "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag...", 3 },
                    { 4, "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö.", "Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?", 14 },
                    { 5, "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård.", "Vilken typ av angrepp har de sannolikt blivit utsatta för?", 15 },
                    { 6, "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system.", "Vilken typ av malware var primärt ansvarig för denna incident?", 16 },
                    { 7, "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper.", "Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?", 17 },
                    { 8, "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor.", "Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?", 18 },
                    { 9, "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot.", "Vilken lagstiftning ger ramverket för detta skydd?", 19 }
                });

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
                    { 7, "Genomföra omedelbar investering för att inte missa möjligheten", false, 3 },
                    { 8, "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst", true, 4 },
                    { 9, "Återgå till kontorsarbete", false, 4 },
                    { 10, "Förbjuda användning av personliga enheter för arbete", false, 4 },
                    { 11, "Organiserade cyberbrottsliga grupper", true, 7 },
                    { 12, "En enskild hackare med ett personligt vendetta", false, 7 },
                    { 13, "Implementera en ny brandvägg", false, 7 },
                    { 14, "Slå på tvåfaktorsautentisering för alla fjärranslutningar", true, 5 },
                    { 15, "Skriv ut alla dokument och undvik digital delning", false, 6 },
                    { 16, "Använd samma lösenord för alla konton för enkelhetens skull", false, 7 },
                    { 17, "Social engineering", true, 4 },
                    { 18, "Stark kryptering", false, 3 },
                    { 19, "Brandväggar", false, 8 }
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

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Segments",
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

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 25);

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

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 19);

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
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
