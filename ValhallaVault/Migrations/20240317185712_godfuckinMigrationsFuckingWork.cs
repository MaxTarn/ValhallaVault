using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVault.Migrations
{
    /// <inheritdoc />
    public partial class godfuckinMigrationsFuckingWork : Migration
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
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true)
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
                columns: new[] { "Id", "Info", "Name" },
                values: new object[,]
                {
                    { 1, "Metoder för att skydda sig mot bedrägerier, inklusive att känna igen vanliga bedrägeriförsök, skydda personlig information och förstå hur man rapporterar bedrägliga aktiviteter. Denna kategori täcker olika aspekter av bedrägeriförebyggande, såsom skydd mot identitetsstöld, säkerhetspraxis på nätet och medvetenhet om finansiella bedrägerier. Genom att utbilda individer om potentiella hot och tillhandahålla strategier för att minska risker syftar denna kategori till att ge människor verktyg för att skydda sig från att bli offer för bedrägliga scheman och scams.", "Att Skydda Sig Mot Bedrägerier" },
                    { 2, "Information och riktlinjer för att säkra företagsdata och nätverk mot cyberhot. Denna kategori omfattar olika aspekter av cybersäkerhet för företag, inklusive riskhantering, skydd mot skadlig programvara, medvetenhetsträning för anställda och efterlevnad av dataskyddsföreskrifter. Genom att tillhandahålla strategier och bästa praxis syftar denna kategori till att hjälpa företag att stärka sin cyberförsvar och minimera risken för dataintrång och ekonomisk skada.", "Cybersäkerhet för företag" },
                    { 3, "Metoder för att förhindra och upptäcka spionage och attacker på internet, inklusive skydd av personlig information, igenkänning av vanliga cyberhot och rapportering av misstänkta aktiviteter. Denna kategori täcker olika aspekter av cyber- och spionageskydd, såsom säkerhetspraxis för nätverk, krypteringstekniker och förståelse för socialt ingenjörskap. Genom att öka medvetenheten och tillhandahålla strategier för att minska risker syftar denna kategori till att stärka användare för att skydda sig mot cyberattacker och spionagesyften.", "CyberSpionage" }
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "CategoryId", "Info", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Strategier och metoder för att förhindra identitetsstöld, inklusive att säkra personlig information och känna igen varningssignaler för potentiella bedrägeriförsök.", "Skydd mot Identitetsstöld" },
                    { 2, 1, "Bästa praxis för att upprätthålla säkerhet på nätet, såsom att använda starka lösenord, aktivera tvåfaktorsautentisering och undvika phishingförsök.", "Säkerhetspraxis på Nätet" },
                    { 3, 2, "Metoder och processer för att identifiera, bedöma och hantera risker relaterade till cybersäkerhet inom företagsmiljöer.", "Riskhantering" },
                    { 4, 2, "Strategier och verktyg för att skydda företagsnätverk och system mot skadlig programvara, inklusive virus, spionprogram och ransomware.", "Skydd mot Skadlig Programvara" },
                    { 5, 3, "Praktiska åtgärder för att säkra nätverk mot cyberattacker, inklusive brandväggskonfiguration, intrångsdetektionssystem och nätverkssegmentering.", "Nätverkssäkerhet" },
                    { 6, 3, "Metoder för att använda kryptering för att skydda data mot obehörig åtkomst och avlyssning, inklusive symmetrisk och asymmetrisk kryptering samt säkra kommunikationsprotokoll.", "Krypteringstekniker" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "Info", "Name", "SegmentId" },
                values: new object[,]
                {
                    { 1, "Riktlinjer för att skydda personuppgifter och förhindra obehörig åtkomst till känslig information.", "Tips för Dataskydd", 1 },
                    { 2, "Information om kreditövervakningstjänster och hur de kan hjälpa individer att upptäcka bedrägliga aktiviteter relaterade till deras kreditrapporter.", "Kreditövervakningstjänster", 1 },
                    { 3, "Tips för att säkert surfa på internet, såsom att använda HTTPS-webbplatser, undvika offentliga Wi-Fi-nätverk och regelbundet uppdatera webbläsare.", "Säkra Surfningspraxis", 2 },
                    { 4, "Metoder för att förbättra e-postsäkerheten, inklusive att känna igen phishing-e-postmeddelanden, verifiera avsändarens identitet och använda e-postkryptering.", "E-postsäkerhetsåtgärder", 2 },
                    { 5, "Processen att identifiera och bedöma potentiella risker för företagsdata och informationssystem för att fatta informerade beslut om riskhantering.", "Riskbedömning", 3 },
                    { 6, "Metoder och verktyg för att förebygga, upptäcka och ta bort skadlig programvara från företagsnätverk och enheter.", "Malware Skydd", 4 },
                    { 7, "Utbildning och träningsprogram för att öka medvetenheten hos företagsanställda om cybersäkerhetsrisker och bästa praxis för att minska riskerna.", "Anställd Medvetenhet", 3 },
                    { 8, "Policyer och förfaranden som företag implementerar för att efterleva dataskyddsföreskrifter och säkra känslig företagsinformation.", "Företags Dataskyddsregler", 4 },
                    { 9, "Inställningar och regler för att konfigurera brandväggar och filtrera nätverkstrafik för att förhindra obehörig åtkomst och skydda mot skadlig programvara.", "Brandväggskonfiguration", 5 },
                    { 10, "Tekniker för att övervaka nätverkstrafik och identifiera avvikande beteenden som kan indikera en cyberattack, samt implementering av åtgärder för att förhindra intrång.", "Intrångsdetektionssystem", 5 },
                    { 11, "En krypteringsmetod där samma nyckel används för både kryptering och dekryptering av data, och implementeringen av algoritmer som AES för att säkra kommunikation.", "Symmetrisk Kryptering", 6 },
                    { 12, "En krypteringsmetod där olika nycklar används för kryptering och dekryptering av data, samt användningen av RSA-algoritmen för att säkra överföring av kryptonycklar.", "Asymmetrisk Kryptering", 6 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Explanation", "Question", "SubcategoryId" },
                values: new object[,]
                {
                    { 1, "Genom att implementera starka lösenord kan man förhindra obehörig åtkomst till personuppgifter.", "Vilka är några strategier för att säkra personuppgifter?", 1 },
                    { 2, "Att aktivera tvåfaktorsautentisering är ett effektivt sätt att förhindra obehörig åtkomst till känslig information.", "Hur kan individer förhindra obehörig åtkomst till känslig information?", 1 },
                    { 3, "Genom att kryptera data förhindras obehörig åtkomst och skyddar integriteten för personuppgifter.", "Varför är datakryptering viktigt för att skydda integriteten?", 1 },
                    { 4, "Att använda säkra betalningsgatewayer är en effektiv åtgärd för att säkerställa datasäkerhet vid online-transaktioner.", "Vilka åtgärder kan vidtas för att säkerställa datasäkerhet vid online-transaktioner?", 1 },
                    { 5, "Genom att granska integritetsinställningarna på sociala medieplattformar kan man identifiera potentiella risker för datas integritet.", "Hur identifierar man potentiella risker för datas integritet?", 1 },
                    { 6, "Kreditövervakning är en tjänst som hjälper till att övervaka kreditrapporter och upptäcka eventuella bedrägliga aktiviteter. Det fungerar genom att regelbundet övervaka kreditrapporter och varna för avvikelser.", "Vad är kreditövervakning och hur fungerar det?", 2 },
                    { 7, "En fördel med att använda kreditövervakningstjänster är att det möjliggör tidig upptäckt av identitetsstöld och bedrägerier på kreditrapporter.", "Vilka fördelar finns med att använda kreditövervakningstjänster?", 2 },
                    { 8, "Genom att regelbundet kontrollera kreditrapporter kan individer upptäcka ovanliga eller misstänkta aktiviteter, vilket kan vara tecken på bedrägeri.", "Hur kan individer upptäcka bedrägliga aktiviteter på sina kreditrapporter?", 2 },
                    { 9, "Om misstänksam aktivitet upptäcks på en kreditrapport bör individen omedelbart rapportera det till kreditbyråerna för vidare utredning.", "Vilka åtgärder bör vidtas om misstänksam aktivitet upptäcks på en kreditrapport?", 2 },
                    { 10, "Ja, att använda identitetsstödskontroller och övervaka kontoutdrag kan vara alternativ till kreditövervakning för bedrägeriupptäckt.", "Finns det några alternativ till kreditövervakning för bedrägeriupptäckt?", 2 },
                    { 11, "HTTPS-webbplatser använder kryptering för att säkra kommunikationen mellan webbläsaren och webbservern, vilket skyddar användares integritet och säkerhet vid surfning.", "Vad är HTTPS-webbplatser och varför är de viktiga för säker surfning?", 3 },
                    { 12, "Genom att använda VPN-tjänster kan individer kryptera sin internettrafik och säkra sina data när de använder offentliga Wi-Fi-nätverk.", "Hur kan individer skydda sina data när de använder offentliga Wi-Fi-nätverk?", 3 },
                    { 13, "Webbläsaruppdateringar är viktiga för att patcha säkerhetshål och sårbarheter, vilket minskar risken för attacker och säkerhetsintrång.", "Vilken roll spelar webbläsaruppdateringar för att upprätthålla nätverkssäkerheten?", 3 },
                    { 14, "Vanliga nätverkssäkerhetshot inkluderar phishingattacker och skadlig kod. De kan undvikas genom att vara försiktig med länkar och bifogade filer samt genom att använda säkerhetsprogramvara.", "Vilka är några vanliga nätverkssäkerhetshot och hur kan de undvikas?", 3 },
                    { 15, "Genom att kontrollera om webbplatsen använder HTTPS och har giltiga SSL-certifikat kan användare bedöma om det är säkert att genomföra online-transaktioner på webbplatsen.", "Hur kan användare identifiera om en webbplats är säker för online-transaktioner?", 3 },
                    { 16, "Phishing-e-postmeddelanden är bedrägliga meddelanden som utger sig för att vara från pålitliga källor för att lura mottagarna att lämna ut personlig eller känslig information. De fungerar genom att locka mottagaren att klicka på skadliga länkar eller bifogade filer.", "Vad är phishing-e-postmeddelanden och hur fungerar de?", 4 },
                    { 17, "Genom att vara uppmärksam på varningsflaggor, såsom oegentliga begäranden om känslig information eller brådskande åtgärder, kan individer undvika att bli lurade av phishing-bedrägerier.", "Hur kan individer känna igen och undvika att bli lurade av phishing-bedrägerier?", 4 },
                    { 18, "Misspelled avsändarens e-postadress och ovanliga begäranden om känslig information kan vara indikatorer på ett misstänkt e-postmeddelande.", "Vilka är några indikatorer på ett misstänkt e-postmeddelande?", 4 },
                    { 19, "Att verifiera avsändarens identitet kan förhindra att svara på phishing-e-postmeddelanden och därigenom undvika att lämna ut personlig eller känslig information till bedragare.", "Varför är det viktigt att verifiera avsändarens identitet innan man svarar på e-postmeddelanden?", 4 },
                    { 20, "Om en individ misstänker att de har fått ett phishing-e-postmeddelande bör de rapportera det till lämpliga myndigheter eller organisationer för att varna andra och förhindra ytterligare bedrägerier.", "Vilka åtgärder bör vidtas om en individ misstänker att de har fått ett phishing-e-postmeddelande?", 4 },
                    { 21, "En typisk riskbedömningsprocess för företag inkluderar identifiering av risker, bedömning av riskernas sannolikhet och påverkan, och utveckling av riskhanteringsstrategier.", "Vilka steg ingår i en typisk riskbedömningsprocess för företag?", 5 },
                    { 22, "Syftet med en riskhanteringsplan inom cybersäkerhet är att definiera företagets strategi för att hantera och minimera risker för dataintrång och förlust av företagsinformation.", "Vad är syftet med en riskhanteringsplan inom cybersäkerhet?", 5 },
                    { 23, "Företag kan förebygga spridning av skadlig programvara genom att använda uppdaterad antivirusprogramvara, implementera brandväggar och utbilda personalen om säker surfning och e-posthantering.", "Hur kan företag förebygga spridning av skadlig programvara på sina nätverk?", 6 },
                    { 24, "Ransomware är skadlig programvara som krypterar filer på offrets enhet och kräver betalning för att låsa upp dem. Företag kan skydda sig mot ransomware genom att säkerhetskopiera data regelbundet och undvika att klicka på misstänkta länkar eller öppna bifogade filer i e-postmeddelanden.", "Vad är ransomware och hur kan företag skydda sig mot det?", 6 },
                    { 25, "Det är viktigt att företagsanställda är medvetna om cybersäkerhetsrisker för att minska risken för dataintrång och bedrägerier. Genom att känna igen potentiella hot och följa bästa praxis kan anställda bidra till att skydda företagets data och nätverk.", "Varför är det viktigt att företagsanställda är medvetna om cybersäkerhetsrisker?", 7 },
                    { 26, "Anställda kan utsättas för risker som phishingattacker via e-post, skadlig programvara via nedladdningar, eller oavsiktlig dataexponering genom bristande säkerhetsmedvetenhet.", "Vilka typer av cybersäkerhetsrisker kan anställda utsättas för?", 7 },
                    { 27, "Företag kan genomföra cybersäkerhetsträning, skicka ut information om aktuella hot och bästa praxis regelbundet, och uppmuntra anställda att rapportera misstänkta aktiviteter.", "Vilka åtgärder kan företag vidta för att öka medvetenheten om cybersäkerhet bland sina anställda?", 7 },
                    { 28, "Lagar som GDPR (Dataskyddsförordningen) och CCPA (California Consumer Privacy Act) styr hanteringen av företagsdata och personlig information för att skydda användares integritet och reglera företags insamling och användning av personlig information.", "Vilka lagar och regler styr hanteringen av företagsdata och personlig information?", 8 },
                    { 29, "Efterlevnad av dataskyddsföreskrifter för företag innebär att de måste följa specifika regler och riktlinjer för att skydda användares personlig information, rapportera dataintrång och upprätthålla säkerhetsåtgärder för att förhindra obehörig åtkomst.", "Vad innebär efterlevnad av dataskyddsföreskrifter för företag?", 8 },
                    { 30, "Konsekvenserna av att inte följa dataskyddsföreskrifter för företag kan inkludera böter, rättsliga påföljder, förlorat förtroende från kunder och skada på företagets rykte.", "Vad är konsekvenserna av att inte följa dataskyddsföreskrifter för företag?", 8 },
                    { 31, "Företag kan säkra sina nätverk och system mot skadlig programvara genom att använda brandväggar, antivirusprogram, intrusion detection systems (IDS), och genom att implementera strikta behörighetsåtgärder och uppdatera programvara regelbundet.", "Hur kan företag säkra sina nätverk och system mot skadlig programvara?", 6 },
                    { 32, "En DDOS (Distributed Denial of Service) attack är när en angripare översvämmar en server eller nätverk med en stor mängd trafik för att överbelasta det och göra det otillgängligt för legitima användare. Företag kan skydda sig mot DDOS-attacker genom att använda DDOS-skyddstjänster och konfigurera nätverksutrustning för att filtrera ut skadlig trafik.", "Vad är en DDOS-attack och hur kan företag skydda sig mot det?", 6 },
                    { 33, "En säkerhetspolicy för företaget är en uppsättning riktlinjer och förfaranden som definierar hur företaget skyddar sina data och informationssystem från interna och externa hot. Det är viktigt eftersom det skapar en ram för att etablera och upprätthålla säkerhetsåtgärder och säkerställer efterlevnad av lagar och regler.", "Vad är en säkerhetspolicy för företaget och varför är det viktigt?", 8 },
                    { 34, "Social ingenjörskonst är när en angripare manipulerar människor för att få tillgång till känslig information eller system. Företag kan skydda sig mot social ingenjörskonst genom att utbilda anställda om vanliga taktiker, implementera strikta autentiseringsåtgärder och uppmuntra en kultur av säkerhet och skepticism.", "Vad är social ingenjörskonst och hur kan företag skydda sig mot det?", 7 },
                    { 35, "Företag kan säkra sina interna system och data från insiderhot genom att tillämpa principen om minsta privilegium, övervaka användaraktivitet, använda åtkomstkontroller och genomföra regelbundna säkerhetsrevisioner.", "Hur kan företag säkra sina interna system och data från insiderhot?", 6 },
                    { 36, "Det är viktigt för företag att säkerhetskopiera sina data regelbundet eftersom det minskar risken för permanent dataförlust vid händelser som ransomware-attacker, systemfel eller naturkatastrofer.", "Varför är det viktigt för företag att säkerhetskopiera sina data regelbundet?", 6 },
                    { 37, "Företag kan övervaka sina nätverk med hjälp av intrångsdetektionssystem (IDS), intrångsförebyggande system (IPS) och säkerhetsinformation- och händelsehantering (SIEM)-verktyg för att upptäcka och svara på misstänkta aktiviteter.", "Hur kan företag övervaka sina nätverk för att upptäcka potentiella intrång?", 5 },
                    { 38, "Fördelarna med att implementera en säkerhetsmedvetenhetskultur inom företaget inkluderar minskad risk för dataintrång och förluster, ökad upptäckt av hot och incidenter och förbättrad efterlevnad av säkerhetspolicyer och föreskrifter.", "Vilka är fördelarna med att implementera en säkerhetsmedvetenhetskultur inom företaget?", 7 },
                    { 39, "Företag kan utveckla en effektiv incidenthanteringsprocess för cybersäkerhet genom att etablera en incidentresponsplan, tilldela roller och ansvarsområden, och genomföra regelbundna övningar och utvärderingar för att förbättra responsförmågan.", "Hur kan företag utveckla en effektiv incidenthanteringsprocess för cybersäkerhet?", 5 },
                    { 40, "Fördelarna med att använda säkerhetsinformation- och händelsehantering (SIEM)-verktyg inkluderar realtidsövervakning av nätverk och system, snabb identifiering och respons på incidenter, och möjligheten att analysera och rapportera om säkerhetsdata för att förbättra framtida skyddsstrategier.", "Vad är fördelarna med att använda säkerhetsinformation- och händelsehantering (SIEM)-verktyg?", 5 },
                    { 41, "Genom att konfigurera brandväggar med strikta regler och filtrera nätverkstrafik kan man förhindra obehöriga användare från att komma åt nätverket.", "Vilken typ av åtgärder kan vidtas för att förhindra obehörig åtkomst till nätverk?", 9 },
                    { 42, "Intrångsdetektionssystem övervakar nätverkstrafik och upptäcker avvikande mönster som kan indikera en cyberattack, vilket möjliggör snabb identifiering och hantering av intrångsförsök.", "Hur kan man identifiera och hantera intrång i nätverket med intrångsdetektionssystem?", 10 },
                    { 43, "Symmetrisk kryptering är snabbare och mer effektiv för att kryptera stora mängder data jämfört med asymmetrisk kryptering, vilket gör det lämpligt för säker kommunikation inom nätverk.", "Vad är fördelarna med symmetrisk kryptering jämfört med asymmetrisk kryptering?", 11 },
                    { 45, "Intrångsdetektionssystem övervakar nätverkstrafik och upptäcker avvikande mönster som kan indikera en cyberattack, vilket gör det möjligt för administratörer att vidta åtgärder för att förhindra intrång.", "Hur fungerar intrångsdetektionssystem för att skydda nätverk?", 9 },
                    { 46, "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation.", "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", 10 },
                    { 47, "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data.", "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", 11 },
                    { 49, "Genom att konfigurera brandväggar med rätt regler och filtrering av trafik kan man förhindra obehörig åtkomst och skydda mot skadlig programvara.", "Vilka åtgärder kan vidtas för att skydda nätverk genom brandväggskonfiguration?", 9 },
                    { 50, "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation.", "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", 10 },
                    { 51, "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data.", "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", 11 },
                    { 53, "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation.", "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", 9 },
                    { 54, "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation.", "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", 10 },
                    { 55, "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data.", "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", 11 },
                    { 57, "Asymmetrisk kryptering används vanligtvis för att kryptera känsliga data som lösenord, kryptonycklar och digitala signaturer för säker kommunikation över nätverk.", "Vilken typ av data kan krypteras med asymmetrisk kryptering?", 9 },
                    { 58, "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation.", "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", 10 },
                    { 59, "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data.", "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", 11 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Answer", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "Implementera starka lösenord", true, 1 },
                    { 2, "Uppdatera programvara regelbundet", false, 1 },
                    { 3, "Dela personlig information på sociala medier", false, 1 },
                    { 4, "Aktivera tvåfaktorsautentisering", true, 2 },
                    { 5, "Använda offentliga Wi-Fi utan försiktighet", false, 2 },
                    { 6, "Lagra känslig information på osäkra enheter", false, 2 },
                    { 7, "Förhindrar obehörig åtkomst till data", true, 3 },
                    { 8, "Krypterar data under överföring", false, 3 },
                    { 9, "Minskar kostnaderna för datalagring", false, 3 },
                    { 10, "Använda säkra betalningsgatewayer", true, 4 },
                    { 11, "Dela lösenord med andra", false, 4 },
                    { 12, "Använda osäkra Wi-Fi-nätverk för transaktioner", false, 4 },
                    { 13, "Granska integritetsinställningar på sociala medieplattformar", true, 5 },
                    { 14, "Ladda ner programvara från okända källor", false, 5 },
                    { 15, "Använda samma lösenord för flera konton", false, 5 },
                    { 16, "Övervaka kreditrapporter för misstänksam aktivitet", true, 6 },
                    { 17, "Ignorera kreditrapporter", false, 6 },
                    { 18, "Dela kreditkortsuppgifter online", false, 6 },
                    { 19, "Tidig upptäckt av identitetsstöld", true, 7 },
                    { 20, "Utsätta personlig information på sociala medier", false, 7 },
                    { 21, "Undvika finansiella transaktioner", false, 7 },
                    { 22, "Kontrollera kreditrapporter regelbundet", true, 8 },
                    { 23, "Ignorera kreditkortsutdrag", false, 8 },
                    { 24, "Dela personlig information med okända personer", false, 8 },
                    { 25, "Rapportera till kreditbyråer", true, 9 },
                    { 26, "Ignorera misstänksam aktivitet", false, 9 },
                    { 27, "Dela kreditkortsuppgifter online", false, 9 },
                    { 28, "Använda identitetsskyddstjänster", true, 10 },
                    { 29, "Dela personlig information på sociala medier", false, 10 },
                    { 30, "Ignorera bedrägliga aktiviteter", false, 10 },
                    { 31, "Säkra anslutningar med kryptering", true, 11 },
                    { 32, "Dela personuppgifter på osäkra webbplatser", false, 11 },
                    { 33, "Ignorera indikatorer för webbplatsens säkerhet", false, 11 },
                    { 34, "Använda VPN för krypterade anslutningar", true, 12 },
                    { 35, "Dela personuppgifter på offentliga nätverk", false, 12 },
                    { 36, "Inaktivera brandväggsinställningar", false, 12 },
                    { 37, "Säkerställa att webbläsaruppdateringar är aktuella", true, 13 },
                    { 38, "Inaktivera webbläsaruppdateringar", false, 13 },
                    { 39, "Ignorera webbläsarsäkerhetsvarningar", false, 13 },
                    { 40, "Phishingattacker", true, 14 },
                    { 41, "Uppdatera programvara regelbundet", false, 14 },
                    { 42, "Använda starka lösenord", false, 14 },
                    { 43, "Kontrollera SSL-certifikat", true, 15 },
                    { 44, "Lämna personlig information på vilken webbplats som helst", false, 15 },
                    { 45, "Ignorera indikatorer för webbplatsens säkerhet", false, 15 },
                    { 46, "Bedrägliga e-postmeddelanden som syftar till att få personlig information", true, 16 },
                    { 47, "Legitima e-postmeddelanden från betrodda källor", false, 16 },
                    { 48, "Ladda ner bilagor från okända avsändare", false, 16 },
                    { 49, "Kontrollera avsändarens e-postadress för äkthet", true, 17 },
                    { 50, "Klicka på misstänkta länkar i e-postmeddelanden", false, 17 },
                    { 51, "Lämna personlig information som svar på e-postmeddelanden", false, 17 },
                    { 52, "Felstavat avsändarens e-postadress", true, 18 },
                    { 53, "Kontrollera endast ämnesraden på e-postmeddelanden", false, 18 },
                    { 54, "Öppna alla bifogade filer i e-postmeddelanden", false, 18 },
                    { 55, "För att undvika att lämna ut personlig information till bedragare", true, 19 },
                    { 56, "För att ge mer information till avsändaren", false, 19 },
                    { 57, "För att visa intresse för e-postmeddelandet", false, 19 },
                    { 58, "Rapportera till lämpliga myndigheter eller organisationer", true, 20 },
                    { 59, "Svara på e-postmeddelandet och fråga om mer information", false, 20 },
                    { 60, "Ignorera e-postmeddelandet och radera det", false, 20 },
                    { 61, "Genomföra regelbundna sårbarhetsskanningar", true, 21 },
                    { 62, "Uppgradera nätverksservrar", false, 21 },
                    { 63, "Implementera säkerhetsrevisioner", false, 21 },
                    { 64, "Definiera strategier för att hantera risker", true, 22 },
                    { 65, "Utvärdera konkurrenternas säkerhetsåtgärder", false, 22 },
                    { 66, "Skapa företagshemligheter", false, 22 },
                    { 67, "Använda uppdaterad antivirusprogramvara", true, 23 },
                    { 68, "Klicka på misstänkta länkar i e-postmeddelanden", false, 23 },
                    { 69, "Använda samma lösenord för alla konton", false, 23 },
                    { 70, "Skicka betalning om ransomware attackeras", true, 24 },
                    { 71, "Ignorera ransomware-meddelanden", false, 24 },
                    { 72, "Rapportera ransomware-attacken till myndigheterna", false, 24 },
                    { 73, "För att minska risken för dataintrång och bedrägerier", true, 25 },
                    { 74, "För att dela företagshemligheter med konkurrenter", false, 25 },
                    { 75, "För att öka antalet anställda inom företaget", false, 25 },
                    { 76, "Phishingattacker via e-post, skadlig programvara via nedladdningar, eller oavsiktlig dataexponering genom bristande säkerhetsmedvetenhet", true, 26 },
                    { 77, "Fysiskt intrång i företagets lokaler", false, 26 },
                    { 78, "Nätverksbaserade attacker mot konkurrenter", false, 26 },
                    { 79, "Genomföra cybersäkerhetsträning, skicka ut information om aktuella hot och bästa praxis regelbundet, och uppmuntra anställda att rapportera misstänkta aktiviteter", true, 27 },
                    { 80, "Ignorera säkerhetsmeddelanden från IT-avdelningen", false, 27 },
                    { 81, "Dela inloggningsuppgifter med externa parter", false, 27 },
                    { 82, "GDPR (Dataskyddsförordningen) och CCPA (California Consumer Privacy Act)", true, 28 },
                    { 83, "SOC 2 (Service Organization Control 2) och HIPAA (Health Insurance Portability and Accountability Act)", false, 28 },
                    { 84, "ISO 9001 (International Organization for Standardization) och PCI DSS (Payment Card Industry Data Security Standard)", false, 28 },
                    { 85, "Att de måste följa specifika regler och riktlinjer för att skydda användares personlig information, rapportera dataintrång och upprätthålla säkerhetsåtgärder för att förhindra obehörig åtkomst", true, 29 },
                    { 86, "Att de måste dela företagshemligheter med andra företag", false, 29 },
                    { 87, "Att de måste ignorera dataintrångsförsök från externa parter", false, 29 },
                    { 88, "Böter, rättsliga påföljder, förlorat förtroende från kunder och skada på företagets rykte", true, 30 },
                    { 89, "Ökad tillväxt och konkurrensfördelar", false, 30 },
                    { 90, "Större exponering för externa investerare", false, 30 },
                    { 91, "För att minska risken för dataintrång och bedrägerier", true, 31 },
                    { 92, "För att skydda företagets immateriella tillgångar och säkerställa kontinuitet i verksamheten", false, 31 },
                    { 93, "För att öka företagets skuldsättning", false, 31 },
                    { 94, "Implementera brandväggar och intrusionsskyddssystem", true, 32 },
                    { 95, "Använda osäker Wi-Fi-anslutning", false, 32 },
                    { 96, "Öppna e-postbilagor från okända avsändare", false, 32 },
                    { 97, "Medarbetarnas beteende och medvetenhet", true, 33 },
                    { 98, "Installation av antivirusprogramvara", false, 33 },
                    { 99, "Användning av svaga lösenord", false, 33 },
                    { 100, "För att skydda företagsnätverket mot obehörig åtkomst och skadlig kod", true, 34 },
                    { 101, "För att dela känslig information offentligt", false, 34 },
                    { 102, "För att öka nedladdningshastigheten", false, 34 },
                    { 103, "Konfigurera användarbehörigheter och behörighetsgrupper", true, 35 },
                    { 104, "Dela inloggningsuppgifter med andra användare", false, 35 },
                    { 105, "Använda samma lösenord för alla konton", false, 35 },
                    { 106, "Säkerhetskopiering och återställning av data", true, 36 },
                    { 107, "Användning av svaga lösenord", false, 36 },
                    { 108, "Delning av företagshemligheter på sociala medieplattformar", false, 36 },
                    { 109, "Kryptering av känslig information", true, 37 },
                    { 110, "Publicering av företagsuppgifter på offentliga webbplatser", false, 37 },
                    { 111, "Användning av standardlösenord för Wi-Fi-router", false, 37 },
                    { 112, "Ett ransomware-angrepp som krypterar företagets filer och kräver en lösensumma för att dekryptera dem", true, 38 },
                    { 113, "Ett säkerhetskopieringsverktyg för att säkerhetskopiera företagets data", false, 38 },
                    { 114, "Ett program för att skicka spam-e-post", false, 38 },
                    { 115, "Utbildning av anställda om cybersäkerhetsbästa praxis", true, 39 },
                    { 116, "Uppgradering av datorernas operativsystem", false, 39 },
                    { 117, "Delning av inloggningsuppgifter med okända parter", false, 39 },
                    { 118, "För att skydda företagets informationstillgångar, upprätthålla affärsfortsättning och följa lagliga krav", true, 40 },
                    { 119, "För att dela känslig information på osäkra nätverk", false, 40 },
                    { 120, "För att öka möjligheten till dataläckage", false, 40 },
                    { 121, "Konfigurera brandväggar med strikta regler och filtrera nätverkstrafik", true, 41 },
                    { 122, "Använda publika Wi-Fi-nätverk utan försiktighet", false, 41 },
                    { 123, "Dela lösenord med andra", false, 41 },
                    { 124, "Övervakar nätverkstrafik och upptäcker avvikande mönster", true, 45 },
                    { 125, "Ignorerar intrångsförsök", false, 45 },
                    { 126, "Blockerar all nätverkstrafik", false, 45 },
                    { 127, "Konfigurera brandväggar med rätt regler och filtrering av trafik", true, 49 },
                    { 128, "Använda publika Wi-Fi-nätverk utan försiktighet", false, 49 },
                    { 129, "Dela lösenord med andra", false, 49 },
                    { 130, "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", true, 53 },
                    { 131, "Använda publika Wi-Fi-nätverk utan försiktighet", false, 53 },
                    { 132, "Dela lösenord med andra", false, 53 },
                    { 133, "Känsliga data som lösenord, kryptonycklar och digitala signaturer", true, 57 },
                    { 134, "Allmänna webbsidor", false, 57 },
                    { 135, "Offentliga nycklar", false, 57 },
                    { 136, "Övervakar nätverkstrafik och upptäcker avvikande mönster", true, 42 },
                    { 137, "Ignorerar intrångsförsök", false, 42 },
                    { 138, "Blockerar all nätverkstrafik", false, 42 },
                    { 139, "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", true, 46 },
                    { 140, "Använda publika Wi-Fi-nätverk utan försiktighet", false, 46 },
                    { 141, "Dela lösenord med andra", false, 46 },
                    { 142, "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", true, 50 },
                    { 143, "Använda publika Wi-Fi-nätverk utan försiktighet", false, 50 },
                    { 144, "Dela lösenord med andra", false, 50 },
                    { 145, "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", true, 54 },
                    { 146, "Använda publika Wi-Fi-nätverk utan försiktighet", false, 54 },
                    { 147, "Dela lösenord med andra", false, 54 },
                    { 148, "Snabbare och mer effektiv för att kryptera stora mängder data", true, 43 },
                    { 149, "Mindre säker än asymmetrisk kryptering", false, 43 },
                    { 150, "Endast lämplig för säker kommunikation inom nätverk", false, 43 },
                    { 151, "Snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering", true, 47 },
                    { 152, "Mindre säker än asymmetrisk kryptering", false, 47 },
                    { 153, "Endast lämplig för kryptering av lösenord", false, 47 },
                    { 154, "Snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering", true, 51 },
                    { 155, "Mindre säker än asymmetrisk kryptering", false, 51 },
                    { 156, "Endast lämplig för kryptering av lösenord", false, 51 },
                    { 157, "Snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering", true, 55 },
                    { 158, "Mindre säker än asymmetrisk kryptering", false, 55 },
                    { 159, "Endast lämplig för kryptering av lösenord", false, 55 }
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
