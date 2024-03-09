using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations
{
    /// <inheritdoc />
    public partial class addedsomemorequestionsandanswerstosubcategorywithid1createdbyGPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Segments_SegmentId",
                        column: x => x.SegmentId,
                        principalTable: "Segments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 9, "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot.", "Vilken lagstiftning ger ramverket för detta skydd?", 19 },
                    { 11, "Omedelbart kontakta ditt kreditkortsföretag för att rapportera de obehöriga transaktionerna och blockera ditt kort för att förhindra ytterligare skador.", "Vad ska du göra om du upptäcker obehöriga transaktioner på ditt kreditkort?", 1 },
                    { 12, "Phishing-webbplatser och skadlig programvara är vanliga metoder för att stjäla kreditkortsuppgifter online.", "Vilket är ett vanligt sätt för bedragare att stjäla kreditkortsuppgifter online?", 1 },
                    { 13, "Använd säkra och pålitliga webbplatser, kontrollera att webbadressen börjar med 'https://' och undvik att lagra kreditkortsuppgifter på webbplatser.", "Hur kan du öka säkerheten när du handlar online med ditt kreditkort?", 1 },
                    { 14, "Regelbunden övervakning av kreditkortsutdrag hjälper till att upptäcka obehöriga transaktioner i tid och minskar risken för bedrägeri.", "Varför är det viktigt att regelbundet övervaka dina kreditkortsutdrag?", 1 },
                    { 15, "Omedelbart kontakta ditt kreditkortsföretag, spärra ditt kort och rapportera det till polisen för att förebygga obehöriga transaktioner.", "Vilken åtgärd bör vidtas om du misstänker att ditt kreditkort har blivit stulet?", 1 },
                    { 16, "Undvik att använda betalningsautomater som ser misstänkta ut, täck ditt knappsatsinmatning när du skriver in din PIN-kod och övervaka ditt kreditkortsutdrag.", "Hur kan du undvika att bli offer för skimming på betalningsautomater?", 1 },
                    { 17, "Oregistrerade eller oseriösa webbplatser, särskilt med onormalt låga priser, kan vara tecken på kreditkortsbedrägeri.", "Vilket är ett vanligt tecken på kreditkortsbedrägeri vid onlineköp?", 1 },
                    { 18, "CVV-koden används för att bekräfta att du har ditt fysiska kreditkort och bör hållas konfidentiell för att förhindra obehörig användning.", "Varför är det viktigt att inte dela ditt kreditkorts CVV-kod (säkerhetskod) med andra?", 1 },
                    { 19, "Förvara ditt kreditkort på en säker plats, undvik att lämna det obevakat och använd plånböcker eller skyddsfodral för extra säkerhet.", "Hur kan du säkert förvara ditt fysiska kreditkort för att undvika stöld?", 1 },
                    { 20, "Omedelbart kontakta ditt kreditkortsföretag, begär att kortet spärras och överväg att ändra ditt lösenord för extra säkerhet.", "Vilken åtgärd bör du vidta om ditt kreditkortsinformation har blivit komprometterad?", 1 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Answer", "IsChecked", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Ett potentiellt telefonbedrägeri", null, true, 1 },
                    { 2, "Ett legitimt försök från banken att skydda ditt konto", null, false, 1 },
                    { 3, "En informationsinsamling för en marknadsundersökning", null, false, 1 },
                    { 4, "Ett romansbedrägeri", null, true, 2 },
                    { 5, "En legitim begäran om hjälp från en person i nöd", null, false, 2 },
                    { 6, "Investeringsbedrägeri", null, true, 3 },
                    { 7, "Genomföra omedelbar investering för att inte missa möjligheten", null, false, 3 },
                    { 8, "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst", null, true, 4 },
                    { 9, "Återgå till kontorsarbete", null, false, 4 },
                    { 10, "Förbjuda användning av personliga enheter för arbete", null, false, 4 },
                    { 11, "Organiserade cyberbrottsliga grupper", null, true, 7 },
                    { 12, "En enskild hackare med ett personligt vendetta", null, false, 7 },
                    { 13, "Implementera en ny brandvägg", null, false, 7 },
                    { 14, "Slå på tvåfaktorsautentisering för alla fjärranslutningar", null, true, 5 },
                    { 15, "Skriv ut alla dokument och undvik digital delning", null, false, 6 },
                    { 16, "Använd samma lösenord för alla konton för enkelhetens skull", null, false, 7 },
                    { 17, "Social engineering", null, true, 4 },
                    { 18, "Stark kryptering", null, false, 3 },
                    { 19, "Brandväggar", null, false, 8 },
                    { 20, "Kontakta omedelbart kreditkortsföretaget och rapportera transaktionerna.", null, true, 11 },
                    { 21, "Avvakta och se om det händer igen innan du agerar.", null, false, 11 },
                    { 22, "Ignorera det och hoppas att det löser sig självt.", null, false, 11 },
                    { 23, "Publicera informationen på sociala medier för att varna andra.", null, false, 11 },
                    { 24, "Skimming på betalningsautomater.", null, true, 12 },
                    { 25, "Användning av säkra webbplatser.", null, false, 12 },
                    { 26, "Delning av kreditkortsuppgifter via e-post.", null, false, 12 },
                    { 27, "Användning av offentliga Wi-Fi-nätverk.", null, false, 12 },
                    { 28, "Använd säkra och pålitliga webbplatser.", null, true, 13 },
                    { 29, "Lagra kreditkortsuppgifter offentligt.", null, false, 13 },
                    { 30, "Dela kreditkortsuppgifter via e-post.", null, false, 13 },
                    { 31, "Använda samma lösenord överallt för bekvämlighet.", null, false, 13 },
                    { 32, "Förhindra ytterligare skador.", null, true, 14 },
                    { 33, "Ignorera det och hoppas att det försvinner.", null, false, 14 },
                    { 34, "Rapportera det till ditt internetleverantörsupport.", null, false, 14 },
                    { 35, "Kontakta ditt lokala postkontor.", null, false, 14 },
                    { 36, "Spärra kortet och rapportera till polisen.", null, true, 15 },
                    { 37, "Avvakta och se om något händer.", null, false, 15 },
                    { 38, "Publicera informationen på sociala medier.", null, false, 15 },
                    { 39, "Inget behov av att göra något.", null, false, 15 },
                    { 40, "Undvik att använda misstänkta betalningsautomater.", null, true, 16 },
                    { 41, "Använd alltid samma automater.", null, false, 16 },
                    { 42, "Använd offentliga Wi-Fi-nätverk för att göra inköp.", null, false, 16 },
                    { 43, "Dela din PIN-kod med andra för säkerhet.", null, false, 16 },
                    { 44, "Oregistrerade eller oseriösa webbplatser.", null, true, 17 },
                    { 45, "Enbart välkända och etablerade webbplatser.", null, false, 17 },
                    { 46, "Webbplatser med höga priser.", null, false, 17 },
                    { 47, "Webbplatser med stort utbud av produkter.", null, false, 17 },
                    { 48, "Förhindra obehörig användning.", null, true, 18 },
                    { 49, "Dela CVV-koden med nära vänner.", null, false, 18 },
                    { 50, "Publicera CVV-koden online.", null, false, 18 },
                    { 51, "Använda samma CVV-kod överallt.", null, false, 18 },
                    { 52, "Förvara det på en säker plats.", null, true, 19 },
                    { 53, "Lämna det obevakat på offentliga platser.", null, false, 19 },
                    { 54, "Dela det med okända personer.", null, false, 19 },
                    { 55, "Använd det som bokmärke.", null, false, 19 },
                    { 56, "Kontakta kreditkortsföretaget och spärra kortet.", null, true, 20 },
                    { 57, "Ignorera det och fortsätt använda det som vanligt.", null, false, 20 },
                    { 58, "Publicera informationen på sociala medier.", null, false, 20 },
                    { 59, "Använda samma lösenord på andra konton.", null, false, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SubcategoryId",
                table: "Questions",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_CategoryId",
                table: "Segments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_SegmentId",
                table: "Subcategories",
                column: "SegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestions_QuestionId",
                table: "UserQuestions",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "UserQuestions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
