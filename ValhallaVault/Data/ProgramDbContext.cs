using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data
{

    public class ProgramDbContext : DbContext
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> options) : base(options)
        {

        }

        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SubcategoryModel> Subcategories { get; set; }
        public DbSet<SegmentModel> Segments { get; set; }
        public DbSet<UserQuestionModel> UserQuestions { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>()
                .HasMany(c => c.Segments)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<SegmentModel>()
                .HasMany(s => s.Subcategories)
                .WithOne(s => s.Segment)
                .HasForeignKey(s => s.SegmentId);

            modelBuilder.Entity<SubcategoryModel>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Subcategory)
                .HasForeignKey(q => q.SubcategoryId);

            modelBuilder.Entity<QuestionModel>()
                .HasMany(q => q.Answers)
                .WithOne(s => s.Question)
                .HasForeignKey(q => q.QuestionId);

            modelBuilder.Entity<UserQuestionModel>()
                .HasOne<QuestionModel>() // One UserQuestionModel has one associated QuestionModel
                .WithMany()
                .HasForeignKey(uq => uq.QuestionId);



            #region chatGPTData


            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Att Skydda Sig Mot Bedrägerier", Info = "Metoder för att skydda sig mot bedrägerier, inklusive att känna igen vanliga bedrägeriförsök, skydda personlig information och förstå hur man rapporterar bedrägliga aktiviteter. Denna kategori täcker olika aspekter av bedrägeriförebyggande, såsom skydd mot identitetsstöld, säkerhetspraxis på nätet och medvetenhet om finansiella bedrägerier. Genom att utbilda individer om potentiella hot och tillhandahålla strategier för att minska risker syftar denna kategori till att ge människor verktyg för att skydda sig från att bli offer för bedrägliga scheman och scams." },
                new CategoryModel
                {
                    Id = 2,
                    Name = "Cybersäkerhet för företag",
                    Info = "Information och riktlinjer för att säkra företagsdata och nätverk mot cyberhot. Denna kategori omfattar olika aspekter av cybersäkerhet för företag, inklusive riskhantering, skydd mot skadlig programvara, medvetenhetsträning för anställda och efterlevnad av dataskyddsföreskrifter. Genom att tillhandahålla strategier och bästa praxis syftar denna kategori till att hjälpa företag att stärka sin cyberförsvar och minimera risken för dataintrång och ekonomisk skada."
                },
                new CategoryModel
                {
                    Id = 3,
                    Name = "CyberSpionage",
                    Info = "Metoder för att förhindra och upptäcka spionage och attacker på internet, inklusive skydd av personlig information, igenkänning av vanliga cyberhot och rapportering av misstänkta aktiviteter. Denna kategori täcker olika aspekter av cyber- och spionageskydd, såsom säkerhetspraxis för nätverk, krypteringstekniker och förståelse för socialt ingenjörskap. Genom att öka medvetenheten och tillhandahålla strategier för att minska risker syftar denna kategori till att stärka användare för att skydda sig mot cyberattacker och spionagesyften."
                }

                );

            modelBuilder.Entity<SegmentModel>().HasData(
                new SegmentModel
                {
                    Id = 1,
                    Name = "Skydd mot Identitetsstöld",
                    Info = "Strategier och metoder för att förhindra identitetsstöld, inklusive att säkra personlig information och känna igen varningssignaler för potentiella bedrägeriförsök.",
                    CategoryId = 1
                },
                new SegmentModel
                {
                    Id = 2,
                    Name = "Säkerhetspraxis på Nätet",
                    Info = "Bästa praxis för att upprätthålla säkerhet på nätet, såsom att använda starka lösenord, aktivera tvåfaktorsautentisering och undvika phishingförsök.",
                    CategoryId = 1
                },
                new SegmentModel
                {
                    Id = 3,
                    Name = "Riskhantering",
                    Info = "Metoder och processer för att identifiera, bedöma och hantera risker relaterade till cybersäkerhet inom företagsmiljöer.",
                    CategoryId = 2
                },
                new SegmentModel
                {
                    Id = 4,
                    Name = "Skydd mot Skadlig Programvara",
                    Info = "Strategier och verktyg för att skydda företagsnätverk och system mot skadlig programvara, inklusive virus, spionprogram och ransomware.",
                    CategoryId = 2
                },
                new SegmentModel
                {
                    Id = 5,
                    Name = "Nätverkssäkerhet",
                    Info = "Praktiska åtgärder för att säkra nätverk mot cyberattacker, inklusive brandväggskonfiguration, intrångsdetektionssystem och nätverkssegmentering.",
                    CategoryId = 3
                },
                new SegmentModel
                {
                    Id = 6,
                    Name = "Krypteringstekniker",
                    Info = "Metoder för att använda kryptering för att skydda data mot obehörig åtkomst och avlyssning, inklusive symmetrisk och asymmetrisk kryptering samt säkra kommunikationsprotokoll.",
                    CategoryId = 3
                }
            );

            modelBuilder.Entity<SubcategoryModel>().HasData(
                new SubcategoryModel
                {
                    Id = 1,
                    Name = "Tips för Dataskydd",
                    Info = "Riktlinjer för att skydda personuppgifter och förhindra obehörig åtkomst till känslig information.",
                    SegmentId = 1
                },
                new SubcategoryModel
                {
                    Id = 2,
                    Name = "Kreditövervakningstjänster",
                    Info = "Information om kreditövervakningstjänster och hur de kan hjälpa individer att upptäcka bedrägliga aktiviteter relaterade till deras kreditrapporter.",
                    SegmentId = 1
                },
                new SubcategoryModel
                {
                    Id = 3,
                    Name = "Säkra Surfningspraxis",
                    Info = "Tips för att säkert surfa på internet, såsom att använda HTTPS-webbplatser, undvika offentliga Wi-Fi-nätverk och regelbundet uppdatera webbläsare.",
                    SegmentId = 2
                },
                new SubcategoryModel
                {
                    Id = 4,
                    Name = "E-postsäkerhetsåtgärder",
                    Info = "Metoder för att förbättra e-postsäkerheten, inklusive att känna igen phishing-e-postmeddelanden, verifiera avsändarens identitet och använda e-postkryptering.",
                    SegmentId = 2
                },
                new SubcategoryModel
                {
                    Id = 5,
                    Name = "Riskbedömning",
                    Info = "Processen att identifiera och bedöma potentiella risker för företagsdata och informationssystem för att fatta informerade beslut om riskhantering.",
                    SegmentId = 3
                },
                new SubcategoryModel
                {
                    Id = 6,
                    Name = "Malware Skydd",
                    Info = "Metoder och verktyg för att förebygga, upptäcka och ta bort skadlig programvara från företagsnätverk och enheter.",
                    SegmentId = 4
                },
                new SubcategoryModel
                {
                    Id = 7,
                    Name = "Anställd Medvetenhet",
                    Info = "Utbildning och träningsprogram för att öka medvetenheten hos företagsanställda om cybersäkerhetsrisker och bästa praxis för att minska riskerna.",
                    SegmentId = 3
                },
                new SubcategoryModel
                {
                    Id = 8,
                    Name = "Företags Dataskyddsregler",
                    Info = "Policyer och förfaranden som företag implementerar för att efterleva dataskyddsföreskrifter och säkra känslig företagsinformation.",
                    SegmentId = 4
                },
                new SubcategoryModel
                {
                    Id = 9,
                    Name = "Brandväggskonfiguration",
                    Info = "Inställningar och regler för att konfigurera brandväggar och filtrera nätverkstrafik för att förhindra obehörig åtkomst och skydda mot skadlig programvara.",
                    SegmentId = 5
                },
                new SubcategoryModel
                {
                    Id = 10,
                    Name = "Intrångsdetektionssystem",
                    Info = "Tekniker för att övervaka nätverkstrafik och identifiera avvikande beteenden som kan indikera en cyberattack, samt implementering av åtgärder för att förhindra intrång.",
                    SegmentId = 5
                },
                new SubcategoryModel
                {
                    Id = 11,
                    Name = "Symmetrisk Kryptering",
                    Info = "En krypteringsmetod där samma nyckel används för både kryptering och dekryptering av data, och implementeringen av algoritmer som AES för att säkra kommunikation.",
                    SegmentId = 6
                },
                new SubcategoryModel
                {
                    Id = 12,
                    Name = "Asymmetrisk Kryptering",
                    Info = "En krypteringsmetod där olika nycklar används för kryptering och dekryptering av data, samt användningen av RSA-algoritmen för att säkra överföring av kryptonycklar.",
                    SegmentId = 6
                }
            );

            modelBuilder.Entity<QuestionModel>().HasData(
                new QuestionModel { Id = 1, Question = "Vilka är några strategier för att säkra personuppgifter?", SubcategoryId = 1, Explanation = "Genom att implementera starka lösenord kan man förhindra obehörig åtkomst till personuppgifter." },
                new QuestionModel { Id = 2, Question = "Hur kan individer förhindra obehörig åtkomst till känslig information?", SubcategoryId = 1, Explanation = "Att aktivera tvåfaktorsautentisering är ett effektivt sätt att förhindra obehörig åtkomst till känslig information." },
                new QuestionModel { Id = 3, Question = "Varför är datakryptering viktigt för att skydda integriteten?", SubcategoryId = 1, Explanation = "Genom att kryptera data förhindras obehörig åtkomst och skyddar integriteten för personuppgifter." },
                new QuestionModel { Id = 4, Question = "Vilka åtgärder kan vidtas för att säkerställa datasäkerhet vid online-transaktioner?", SubcategoryId = 1, Explanation = "Att använda säkra betalningsgatewayer är en effektiv åtgärd för att säkerställa datasäkerhet vid online-transaktioner." },
                new QuestionModel { Id = 5, Question = "Hur identifierar man potentiella risker för datas integritet?", SubcategoryId = 1, Explanation = "Genom att granska integritetsinställningarna på sociala medieplattformar kan man identifiera potentiella risker för datas integritet." },
                new QuestionModel { Id = 6, Question = "Vad är kreditövervakning och hur fungerar det?", SubcategoryId = 2, Explanation = "Kreditövervakning är en tjänst som hjälper till att övervaka kreditrapporter och upptäcka eventuella bedrägliga aktiviteter. Det fungerar genom att regelbundet övervaka kreditrapporter och varna för avvikelser." },
                new QuestionModel { Id = 7, Question = "Vilka fördelar finns med att använda kreditövervakningstjänster?", SubcategoryId = 2, Explanation = "En fördel med att använda kreditövervakningstjänster är att det möjliggör tidig upptäckt av identitetsstöld och bedrägerier på kreditrapporter." },
                new QuestionModel { Id = 8, Question = "Hur kan individer upptäcka bedrägliga aktiviteter på sina kreditrapporter?", SubcategoryId = 2, Explanation = "Genom att regelbundet kontrollera kreditrapporter kan individer upptäcka ovanliga eller misstänkta aktiviteter, vilket kan vara tecken på bedrägeri." },
                new QuestionModel { Id = 9, Question = "Vilka åtgärder bör vidtas om misstänksam aktivitet upptäcks på en kreditrapport?", SubcategoryId = 2, Explanation = "Om misstänksam aktivitet upptäcks på en kreditrapport bör individen omedelbart rapportera det till kreditbyråerna för vidare utredning." },
                new QuestionModel { Id = 10, Question = "Finns det några alternativ till kreditövervakning för bedrägeriupptäckt?", SubcategoryId = 2, Explanation = "Ja, att använda identitetsstödskontroller och övervaka kontoutdrag kan vara alternativ till kreditövervakning för bedrägeriupptäckt." },
                new QuestionModel { Id = 11, Question = "Vad är HTTPS-webbplatser och varför är de viktiga för säker surfning?", SubcategoryId = 3, Explanation = "HTTPS-webbplatser använder kryptering för att säkra kommunikationen mellan webbläsaren och webbservern, vilket skyddar användares integritet och säkerhet vid surfning." },
                new QuestionModel { Id = 12, Question = "Hur kan individer skydda sina data när de använder offentliga Wi-Fi-nätverk?", SubcategoryId = 3, Explanation = "Genom att använda VPN-tjänster kan individer kryptera sin internettrafik och säkra sina data när de använder offentliga Wi-Fi-nätverk." },
                new QuestionModel { Id = 13, Question = "Vilken roll spelar webbläsaruppdateringar för att upprätthålla nätverkssäkerheten?", SubcategoryId = 3, Explanation = "Webbläsaruppdateringar är viktiga för att patcha säkerhetshål och sårbarheter, vilket minskar risken för attacker och säkerhetsintrång." },
                new QuestionModel { Id = 14, Question = "Vilka är några vanliga nätverkssäkerhetshot och hur kan de undvikas?", SubcategoryId = 3, Explanation = "Vanliga nätverkssäkerhetshot inkluderar phishingattacker och skadlig kod. De kan undvikas genom att vara försiktig med länkar och bifogade filer samt genom att använda säkerhetsprogramvara." },
                new QuestionModel { Id = 15, Question = "Hur kan användare identifiera om en webbplats är säker för online-transaktioner?", SubcategoryId = 3, Explanation = "Genom att kontrollera om webbplatsen använder HTTPS och har giltiga SSL-certifikat kan användare bedöma om det är säkert att genomföra online-transaktioner på webbplatsen." },
                new QuestionModel { Id = 16, Question = "Vad är phishing-e-postmeddelanden och hur fungerar de?", SubcategoryId = 4, Explanation = "Phishing-e-postmeddelanden är bedrägliga meddelanden som utger sig för att vara från pålitliga källor för att lura mottagarna att lämna ut personlig eller känslig information. De fungerar genom att locka mottagaren att klicka på skadliga länkar eller bifogade filer." },
                new QuestionModel { Id = 17, Question = "Hur kan individer känna igen och undvika att bli lurade av phishing-bedrägerier?", SubcategoryId = 4, Explanation = "Genom att vara uppmärksam på varningsflaggor, såsom oegentliga begäranden om känslig information eller brådskande åtgärder, kan individer undvika att bli lurade av phishing-bedrägerier." },
                new QuestionModel { Id = 18, Question = "Vilka är några indikatorer på ett misstänkt e-postmeddelande?", SubcategoryId = 4, Explanation = "Misspelled avsändarens e-postadress och ovanliga begäranden om känslig information kan vara indikatorer på ett misstänkt e-postmeddelande." },
                new QuestionModel { Id = 19, Question = "Varför är det viktigt att verifiera avsändarens identitet innan man svarar på e-postmeddelanden?", SubcategoryId = 4, Explanation = "Att verifiera avsändarens identitet kan förhindra att svara på phishing-e-postmeddelanden och därigenom undvika att lämna ut personlig eller känslig information till bedragare." },
                new QuestionModel { Id = 20, Question = "Vilka åtgärder bör vidtas om en individ misstänker att de har fått ett phishing-e-postmeddelande?", SubcategoryId = 4, Explanation = "Om en individ misstänker att de har fått ett phishing-e-postmeddelande bör de rapportera det till lämpliga myndigheter eller organisationer för att varna andra och förhindra ytterligare bedrägerier." },
                new QuestionModel { Id = 21, Question = "Vilka steg ingår i en typisk riskbedömningsprocess för företag?", SubcategoryId = 5, Explanation = "En typisk riskbedömningsprocess för företag inkluderar identifiering av risker, bedömning av riskernas sannolikhet och påverkan, och utveckling av riskhanteringsstrategier." },
                new QuestionModel { Id = 22, Question = "Vad är syftet med en riskhanteringsplan inom cybersäkerhet?", SubcategoryId = 5, Explanation = "Syftet med en riskhanteringsplan inom cybersäkerhet är att definiera företagets strategi för att hantera och minimera risker för dataintrång och förlust av företagsinformation." },
                new QuestionModel { Id = 23, Question = "Hur kan företag förebygga spridning av skadlig programvara på sina nätverk?", SubcategoryId = 6, Explanation = "Företag kan förebygga spridning av skadlig programvara genom att använda uppdaterad antivirusprogramvara, implementera brandväggar och utbilda personalen om säker surfning och e-posthantering." },
                new QuestionModel { Id = 24, Question = "Vad är ransomware och hur kan företag skydda sig mot det?", SubcategoryId = 6, Explanation = "Ransomware är skadlig programvara som krypterar filer på offrets enhet och kräver betalning för att låsa upp dem. Företag kan skydda sig mot ransomware genom att säkerhetskopiera data regelbundet och undvika att klicka på misstänkta länkar eller öppna bifogade filer i e-postmeddelanden." },
                new QuestionModel { Id = 25, Question = "Varför är det viktigt att företagsanställda är medvetna om cybersäkerhetsrisker?", SubcategoryId = 7, Explanation = "Det är viktigt att företagsanställda är medvetna om cybersäkerhetsrisker för att minska risken för dataintrång och bedrägerier. Genom att känna igen potentiella hot och följa bästa praxis kan anställda bidra till att skydda företagets data och nätverk." },
                new QuestionModel { Id = 26, Question = "Vilka typer av cybersäkerhetsrisker kan anställda utsättas för?", SubcategoryId = 7, Explanation = "Anställda kan utsättas för risker som phishingattacker via e-post, skadlig programvara via nedladdningar, eller oavsiktlig dataexponering genom bristande säkerhetsmedvetenhet." },
                new QuestionModel { Id = 27, Question = "Vilka åtgärder kan företag vidta för att öka medvetenheten om cybersäkerhet bland sina anställda?", SubcategoryId = 7, Explanation = "Företag kan genomföra cybersäkerhetsträning, skicka ut information om aktuella hot och bästa praxis regelbundet, och uppmuntra anställda att rapportera misstänkta aktiviteter." },
                new QuestionModel { Id = 28, Question = "Vilka lagar och regler styr hanteringen av företagsdata och personlig information?", SubcategoryId = 8, Explanation = "Lagar som GDPR (Dataskyddsförordningen) och CCPA (California Consumer Privacy Act) styr hanteringen av företagsdata och personlig information för att skydda användares integritet och reglera företags insamling och användning av personlig information." },
                new QuestionModel { Id = 29, Question = "Vad innebär efterlevnad av dataskyddsföreskrifter för företag?", SubcategoryId = 8, Explanation = "Efterlevnad av dataskyddsföreskrifter för företag innebär att de måste följa specifika regler och riktlinjer för att skydda användares personlig information, rapportera dataintrång och upprätthålla säkerhetsåtgärder för att förhindra obehörig åtkomst." },
                new QuestionModel { Id = 30, Question = "Vad är konsekvenserna av att inte följa dataskyddsföreskrifter för företag?", SubcategoryId = 8, Explanation = "Konsekvenserna av att inte följa dataskyddsföreskrifter för företag kan inkludera böter, rättsliga påföljder, förlorat förtroende från kunder och skada på företagets rykte." },
                new QuestionModel { Id = 31, Question = "Hur kan företag säkra sina nätverk och system mot skadlig programvara?", SubcategoryId = 6, Explanation = "Företag kan säkra sina nätverk och system mot skadlig programvara genom att använda brandväggar, antivirusprogram, intrusion detection systems (IDS), och genom att implementera strikta behörighetsåtgärder och uppdatera programvara regelbundet." },
                new QuestionModel { Id = 32, Question = "Vad är en DDOS-attack och hur kan företag skydda sig mot det?", SubcategoryId = 6, Explanation = "En DDOS (Distributed Denial of Service) attack är när en angripare översvämmar en server eller nätverk med en stor mängd trafik för att överbelasta det och göra det otillgängligt för legitima användare. Företag kan skydda sig mot DDOS-attacker genom att använda DDOS-skyddstjänster och konfigurera nätverksutrustning för att filtrera ut skadlig trafik." },
                new QuestionModel { Id = 33, Question = "Vad är en säkerhetspolicy för företaget och varför är det viktigt?", SubcategoryId = 8, Explanation = "En säkerhetspolicy för företaget är en uppsättning riktlinjer och förfaranden som definierar hur företaget skyddar sina data och informationssystem från interna och externa hot. Det är viktigt eftersom det skapar en ram för att etablera och upprätthålla säkerhetsåtgärder och säkerställer efterlevnad av lagar och regler." },
                new QuestionModel { Id = 34, Question = "Vad är social ingenjörskonst och hur kan företag skydda sig mot det?", SubcategoryId = 7, Explanation = "Social ingenjörskonst är när en angripare manipulerar människor för att få tillgång till känslig information eller system. Företag kan skydda sig mot social ingenjörskonst genom att utbilda anställda om vanliga taktiker, implementera strikta autentiseringsåtgärder och uppmuntra en kultur av säkerhet och skepticism." },
                new QuestionModel { Id = 35, Question = "Hur kan företag säkra sina interna system och data från insiderhot?", SubcategoryId = 6, Explanation = "Företag kan säkra sina interna system och data från insiderhot genom att tillämpa principen om minsta privilegium, övervaka användaraktivitet, använda åtkomstkontroller och genomföra regelbundna säkerhetsrevisioner." },
                new QuestionModel { Id = 36, Question = "Varför är det viktigt för företag att säkerhetskopiera sina data regelbundet?", SubcategoryId = 6, Explanation = "Det är viktigt för företag att säkerhetskopiera sina data regelbundet eftersom det minskar risken för permanent dataförlust vid händelser som ransomware-attacker, systemfel eller naturkatastrofer." },
                new QuestionModel { Id = 37, Question = "Hur kan företag övervaka sina nätverk för att upptäcka potentiella intrång?", SubcategoryId = 5, Explanation = "Företag kan övervaka sina nätverk med hjälp av intrångsdetektionssystem (IDS), intrångsförebyggande system (IPS) och säkerhetsinformation- och händelsehantering (SIEM)-verktyg för att upptäcka och svara på misstänkta aktiviteter." },
                new QuestionModel { Id = 38, Question = "Vilka är fördelarna med att implementera en säkerhetsmedvetenhetskultur inom företaget?", SubcategoryId = 7, Explanation = "Fördelarna med att implementera en säkerhetsmedvetenhetskultur inom företaget inkluderar minskad risk för dataintrång och förluster, ökad upptäckt av hot och incidenter och förbättrad efterlevnad av säkerhetspolicyer och föreskrifter." },
                new QuestionModel { Id = 39, Question = "Hur kan företag utveckla en effektiv incidenthanteringsprocess för cybersäkerhet?", SubcategoryId = 5, Explanation = "Företag kan utveckla en effektiv incidenthanteringsprocess för cybersäkerhet genom att etablera en incidentresponsplan, tilldela roller och ansvarsområden, och genomföra regelbundna övningar och utvärderingar för att förbättra responsförmågan." },
                new QuestionModel { Id = 40, Question = "Vad är fördelarna med att använda säkerhetsinformation- och händelsehantering (SIEM)-verktyg?", SubcategoryId = 5, Explanation = "Fördelarna med att använda säkerhetsinformation- och händelsehantering (SIEM)-verktyg inkluderar realtidsövervakning av nätverk och system, snabb identifiering och respons på incidenter, och möjligheten att analysera och rapportera om säkerhetsdata för att förbättra framtida skyddsstrategier." },
                // Questions for Subcategory: Nätverkssäkerhet (ID: 9)
                new QuestionModel { Id = 41, Question = "Vilken typ av åtgärder kan vidtas för att förhindra obehörig åtkomst till nätverk?", SubcategoryId = 9, Explanation = "Genom att konfigurera brandväggar med strikta regler och filtrera nätverkstrafik kan man förhindra obehöriga användare från att komma åt nätverket." },
                new QuestionModel { Id = 45, Question = "Hur fungerar intrångsdetektionssystem för att skydda nätverk?", SubcategoryId = 9, Explanation = "Intrångsdetektionssystem övervakar nätverkstrafik och upptäcker avvikande mönster som kan indikera en cyberattack, vilket gör det möjligt för administratörer att vidta åtgärder för att förhindra intrång." },
                new QuestionModel { Id = 49, Question = "Vilka åtgärder kan vidtas för att skydda nätverk genom brandväggskonfiguration?", SubcategoryId = 9, Explanation = "Genom att konfigurera brandväggar med rätt regler och filtrering av trafik kan man förhindra obehörig åtkomst och skydda mot skadlig programvara." },
                new QuestionModel { Id = 53, Question = "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", SubcategoryId = 9, Explanation = "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation." },
                new QuestionModel { Id = 57, Question = "Vilken typ av data kan krypteras med asymmetrisk kryptering?", SubcategoryId = 9, Explanation = "Asymmetrisk kryptering används vanligtvis för att kryptera känsliga data som lösenord, kryptonycklar och digitala signaturer för säker kommunikation över nätverk." },

                // Questions for Subcategory: Cyberförsvar (ID: 10)
                new QuestionModel { Id = 42, Question = "Hur kan man identifiera och hantera intrång i nätverket med intrångsdetektionssystem?", SubcategoryId = 10, Explanation = "Intrångsdetektionssystem övervakar nätverkstrafik och upptäcker avvikande mönster som kan indikera en cyberattack, vilket möjliggör snabb identifiering och hantering av intrångsförsök." },
                new QuestionModel { Id = 46, Question = "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", SubcategoryId = 10, Explanation = "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation." },
                new QuestionModel { Id = 50, Question = "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", SubcategoryId = 10, Explanation = "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation." },
                new QuestionModel { Id = 54, Question = "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", SubcategoryId = 10, Explanation = "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation." },
                new QuestionModel { Id = 58, Question = "Hur fungerar digitala certifikat för att säkra nätverkskommunikationen?", SubcategoryId = 10, Explanation = "Digitala certifikat används för att verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen, vilket garanterar en säker och pålitlig nätverkskommunikation." },

                // Questions for Subcategory: Krypteringstekniker (ID: 11)
                new QuestionModel { Id = 43, Question = "Vad är fördelarna med symmetrisk kryptering jämfört med asymmetrisk kryptering?", SubcategoryId = 11, Explanation = "Symmetrisk kryptering är snabbare och mer effektiv för att kryptera stora mängder data jämfört med asymmetrisk kryptering, vilket gör det lämpligt för säker kommunikation inom nätverk." },
                new QuestionModel { Id = 47, Question = "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", SubcategoryId = 11, Explanation = "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data." },
                new QuestionModel { Id = 51, Question = "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", SubcategoryId = 11, Explanation = "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data." },
                new QuestionModel { Id = 55, Question = "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", SubcategoryId = 11, Explanation = "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data." },
                new QuestionModel { Id = 59, Question = "Vad är fördelarna med att använda symmetrisk kryptering för filkryptering?", SubcategoryId = 11, Explanation = "Symmetrisk kryptering erbjuder snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering, vilket gör det lämpligt för att säkra lagrade data." }

                );

            modelBuilder.Entity<AnswerModel>().HasData(
                new AnswerModel { Id = 1, Answer = "Implementera starka lösenord", QuestionId = 1, IsCorrect = true },
                new AnswerModel { Id = 2, Answer = "Uppdatera programvara regelbundet", QuestionId = 1, IsCorrect = false },
                new AnswerModel { Id = 3, Answer = "Dela personlig information på sociala medier", QuestionId = 1, IsCorrect = false },
                new AnswerModel { Id = 4, Answer = "Aktivera tvåfaktorsautentisering", QuestionId = 2, IsCorrect = true },
                new AnswerModel { Id = 5, Answer = "Använda offentliga Wi-Fi utan försiktighet", QuestionId = 2, IsCorrect = false },
                new AnswerModel { Id = 6, Answer = "Lagra känslig information på osäkra enheter", QuestionId = 2, IsCorrect = false },
                new AnswerModel { Id = 7, Answer = "Förhindrar obehörig åtkomst till data", QuestionId = 3, IsCorrect = true },
                new AnswerModel { Id = 8, Answer = "Krypterar data under överföring", QuestionId = 3, IsCorrect = false },
                new AnswerModel { Id = 9, Answer = "Minskar kostnaderna för datalagring", QuestionId = 3, IsCorrect = false },
                new AnswerModel { Id = 10, Answer = "Använda säkra betalningsgatewayer", QuestionId = 4, IsCorrect = true },
                new AnswerModel { Id = 11, Answer = "Dela lösenord med andra", QuestionId = 4, IsCorrect = false },
                new AnswerModel { Id = 12, Answer = "Använda osäkra Wi-Fi-nätverk för transaktioner", QuestionId = 4, IsCorrect = false },
                new AnswerModel { Id = 13, Answer = "Granska integritetsinställningar på sociala medieplattformar", QuestionId = 5, IsCorrect = true },
                new AnswerModel { Id = 14, Answer = "Ladda ner programvara från okända källor", QuestionId = 5, IsCorrect = false },
                new AnswerModel { Id = 15, Answer = "Använda samma lösenord för flera konton", QuestionId = 5, IsCorrect = false },
                new AnswerModel { Id = 16, Answer = "Övervaka kreditrapporter för misstänksam aktivitet", QuestionId = 6, IsCorrect = true },
                new AnswerModel { Id = 17, Answer = "Ignorera kreditrapporter", QuestionId = 6, IsCorrect = false },
                new AnswerModel { Id = 18, Answer = "Dela kreditkortsuppgifter online", QuestionId = 6, IsCorrect = false },
                new AnswerModel { Id = 19, Answer = "Tidig upptäckt av identitetsstöld", QuestionId = 7, IsCorrect = true },
                new AnswerModel { Id = 20, Answer = "Utsätta personlig information på sociala medier", QuestionId = 7, IsCorrect = false },
                new AnswerModel { Id = 21, Answer = "Undvika finansiella transaktioner", QuestionId = 7, IsCorrect = false },
                new AnswerModel { Id = 22, Answer = "Kontrollera kreditrapporter regelbundet", QuestionId = 8, IsCorrect = true },
                new AnswerModel { Id = 23, Answer = "Ignorera kreditkortsutdrag", QuestionId = 8, IsCorrect = false },
                new AnswerModel { Id = 24, Answer = "Dela personlig information med okända personer", QuestionId = 8, IsCorrect = false },
                new AnswerModel { Id = 25, Answer = "Rapportera till kreditbyråer", QuestionId = 9, IsCorrect = true },
                new AnswerModel { Id = 26, Answer = "Ignorera misstänksam aktivitet", QuestionId = 9, IsCorrect = false },
                new AnswerModel { Id = 27, Answer = "Dela kreditkortsuppgifter online", QuestionId = 9, IsCorrect = false },
                new AnswerModel { Id = 28, Answer = "Använda identitetsskyddstjänster", QuestionId = 10, IsCorrect = true },
                new AnswerModel { Id = 29, Answer = "Dela personlig information på sociala medier", QuestionId = 10, IsCorrect = false },
                new AnswerModel { Id = 30, Answer = "Ignorera bedrägliga aktiviteter", QuestionId = 10, IsCorrect = false },
                new AnswerModel { Id = 31, Answer = "Säkra anslutningar med kryptering", QuestionId = 11, IsCorrect = true },
                new AnswerModel { Id = 32, Answer = "Dela personuppgifter på osäkra webbplatser", QuestionId = 11, IsCorrect = false },
                new AnswerModel { Id = 33, Answer = "Ignorera indikatorer för webbplatsens säkerhet", QuestionId = 11, IsCorrect = false },
                new AnswerModel { Id = 34, Answer = "Använda VPN för krypterade anslutningar", QuestionId = 12, IsCorrect = true },
                new AnswerModel { Id = 35, Answer = "Dela personuppgifter på offentliga nätverk", QuestionId = 12, IsCorrect = false },
                new AnswerModel { Id = 36, Answer = "Inaktivera brandväggsinställningar", QuestionId = 12, IsCorrect = false },
                new AnswerModel { Id = 37, Answer = "Säkerställa att webbläsaruppdateringar är aktuella", QuestionId = 13, IsCorrect = true },
                new AnswerModel { Id = 38, Answer = "Inaktivera webbläsaruppdateringar", QuestionId = 13, IsCorrect = false },
                new AnswerModel { Id = 39, Answer = "Ignorera webbläsarsäkerhetsvarningar", QuestionId = 13, IsCorrect = false },
                new AnswerModel { Id = 40, Answer = "Phishingattacker", QuestionId = 14, IsCorrect = true },
                new AnswerModel { Id = 41, Answer = "Uppdatera programvara regelbundet", QuestionId = 14, IsCorrect = false },
                new AnswerModel { Id = 42, Answer = "Använda starka lösenord", QuestionId = 14, IsCorrect = false },
                new AnswerModel { Id = 43, Answer = "Kontrollera SSL-certifikat", QuestionId = 15, IsCorrect = true },
                new AnswerModel { Id = 44, Answer = "Lämna personlig information på vilken webbplats som helst", QuestionId = 15, IsCorrect = false },
                new AnswerModel { Id = 45, Answer = "Ignorera indikatorer för webbplatsens säkerhet", QuestionId = 15, IsCorrect = false },
                new AnswerModel { Id = 46, Answer = "Bedrägliga e-postmeddelanden som syftar till att få personlig information", QuestionId = 16, IsCorrect = true },
                new AnswerModel { Id = 47, Answer = "Legitima e-postmeddelanden från betrodda källor", QuestionId = 16, IsCorrect = false },
                new AnswerModel { Id = 48, Answer = "Ladda ner bilagor från okända avsändare", QuestionId = 16, IsCorrect = false },
                new AnswerModel { Id = 49, Answer = "Kontrollera avsändarens e-postadress för äkthet", QuestionId = 17, IsCorrect = true },
                new AnswerModel { Id = 50, Answer = "Klicka på misstänkta länkar i e-postmeddelanden", QuestionId = 17, IsCorrect = false },
                new AnswerModel { Id = 51, Answer = "Lämna personlig information som svar på e-postmeddelanden", QuestionId = 17, IsCorrect = false },
                new AnswerModel { Id = 52, Answer = "Felstavat avsändarens e-postadress", QuestionId = 18, IsCorrect = true },
                new AnswerModel { Id = 53, Answer = "Kontrollera endast ämnesraden på e-postmeddelanden", QuestionId = 18, IsCorrect = false },
                new AnswerModel { Id = 54, Answer = "Öppna alla bifogade filer i e-postmeddelanden", QuestionId = 18, IsCorrect = false },
                new AnswerModel { Id = 55, Answer = "För att undvika att lämna ut personlig information till bedragare", QuestionId = 19, IsCorrect = true },
                new AnswerModel { Id = 56, Answer = "För att ge mer information till avsändaren", QuestionId = 19, IsCorrect = false },
                new AnswerModel { Id = 57, Answer = "För att visa intresse för e-postmeddelandet", QuestionId = 19, IsCorrect = false },
                new AnswerModel { Id = 58, Answer = "Rapportera till lämpliga myndigheter eller organisationer", QuestionId = 20, IsCorrect = true },
                new AnswerModel { Id = 59, Answer = "Svara på e-postmeddelandet och fråga om mer information", QuestionId = 20, IsCorrect = false },
                new AnswerModel { Id = 60, Answer = "Ignorera e-postmeddelandet och radera det", QuestionId = 20, IsCorrect = false },
                new AnswerModel { Id = 61, Answer = "Genomföra regelbundna sårbarhetsskanningar", QuestionId = 21, IsCorrect = true },
                new AnswerModel { Id = 62, Answer = "Uppgradera nätverksservrar", QuestionId = 21, IsCorrect = false },
                new AnswerModel { Id = 63, Answer = "Implementera säkerhetsrevisioner", QuestionId = 21, IsCorrect = false },
                new AnswerModel { Id = 64, Answer = "Definiera strategier för att hantera risker", QuestionId = 22, IsCorrect = true },
                new AnswerModel { Id = 65, Answer = "Utvärdera konkurrenternas säkerhetsåtgärder", QuestionId = 22, IsCorrect = false },
                new AnswerModel { Id = 66, Answer = "Skapa företagshemligheter", QuestionId = 22, IsCorrect = false },
                new AnswerModel { Id = 67, Answer = "Använda uppdaterad antivirusprogramvara", QuestionId = 23, IsCorrect = true },
                new AnswerModel { Id = 68, Answer = "Klicka på misstänkta länkar i e-postmeddelanden", QuestionId = 23, IsCorrect = false },
                new AnswerModel { Id = 69, Answer = "Använda samma lösenord för alla konton", QuestionId = 23, IsCorrect = false },
                new AnswerModel { Id = 70, Answer = "Skicka betalning om ransomware attackeras", QuestionId = 24, IsCorrect = true },
                new AnswerModel { Id = 71, Answer = "Ignorera ransomware-meddelanden", QuestionId = 24, IsCorrect = false },
                new AnswerModel { Id = 72, Answer = "Rapportera ransomware-attacken till myndigheterna", QuestionId = 24, IsCorrect = false },
                new AnswerModel { Id = 73, Answer = "För att minska risken för dataintrång och bedrägerier", QuestionId = 25, IsCorrect = true },
                new AnswerModel { Id = 74, Answer = "För att dela företagshemligheter med konkurrenter", QuestionId = 25, IsCorrect = false },
                new AnswerModel { Id = 75, Answer = "För att öka antalet anställda inom företaget", QuestionId = 25, IsCorrect = false },
                new AnswerModel { Id = 76, Answer = "Phishingattacker via e-post, skadlig programvara via nedladdningar, eller oavsiktlig dataexponering genom bristande säkerhetsmedvetenhet", QuestionId = 26, IsCorrect = true },
                new AnswerModel { Id = 77, Answer = "Fysiskt intrång i företagets lokaler", QuestionId = 26, IsCorrect = false },
                new AnswerModel { Id = 78, Answer = "Nätverksbaserade attacker mot konkurrenter", QuestionId = 26, IsCorrect = false },
                new AnswerModel { Id = 79, Answer = "Genomföra cybersäkerhetsträning, skicka ut information om aktuella hot och bästa praxis regelbundet, och uppmuntra anställda att rapportera misstänkta aktiviteter", QuestionId = 27, IsCorrect = true },
                new AnswerModel { Id = 80, Answer = "Ignorera säkerhetsmeddelanden från IT-avdelningen", QuestionId = 27, IsCorrect = false },
                new AnswerModel { Id = 81, Answer = "Dela inloggningsuppgifter med externa parter", QuestionId = 27, IsCorrect = false },
                new AnswerModel { Id = 82, Answer = "GDPR (Dataskyddsförordningen) och CCPA (California Consumer Privacy Act)", QuestionId = 28, IsCorrect = true },
                new AnswerModel { Id = 83, Answer = "SOC 2 (Service Organization Control 2) och HIPAA (Health Insurance Portability and Accountability Act)", QuestionId = 28, IsCorrect = false },
                new AnswerModel { Id = 84, Answer = "ISO 9001 (International Organization for Standardization) och PCI DSS (Payment Card Industry Data Security Standard)", QuestionId = 28, IsCorrect = false },
                new AnswerModel { Id = 85, Answer = "Att de måste följa specifika regler och riktlinjer för att skydda användares personlig information, rapportera dataintrång och upprätthålla säkerhetsåtgärder för att förhindra obehörig åtkomst", QuestionId = 29, IsCorrect = true },
                new AnswerModel { Id = 86, Answer = "Att de måste dela företagshemligheter med andra företag", QuestionId = 29, IsCorrect = false },
                new AnswerModel { Id = 87, Answer = "Att de måste ignorera dataintrångsförsök från externa parter", QuestionId = 29, IsCorrect = false },
                new AnswerModel { Id = 88, Answer = "Böter, rättsliga påföljder, förlorat förtroende från kunder och skada på företagets rykte", QuestionId = 30, IsCorrect = true },
                new AnswerModel { Id = 89, Answer = "Ökad tillväxt och konkurrensfördelar", QuestionId = 30, IsCorrect = false },
                new AnswerModel { Id = 90, Answer = "Större exponering för externa investerare", QuestionId = 30, IsCorrect = false },
                new AnswerModel { Id = 91, Answer = "För att minska risken för dataintrång och bedrägerier", QuestionId = 31, IsCorrect = true },
                new AnswerModel { Id = 92, Answer = "För att skydda företagets immateriella tillgångar och säkerställa kontinuitet i verksamheten", QuestionId = 31, IsCorrect = false },
                new AnswerModel { Id = 93, Answer = "För att öka företagets skuldsättning", QuestionId = 31, IsCorrect = false },
                new AnswerModel { Id = 94, Answer = "Implementera brandväggar och intrusionsskyddssystem", QuestionId = 32, IsCorrect = true },
                new AnswerModel { Id = 95, Answer = "Använda osäker Wi-Fi-anslutning", QuestionId = 32, IsCorrect = false },
                new AnswerModel { Id = 96, Answer = "Öppna e-postbilagor från okända avsändare", QuestionId = 32, IsCorrect = false },
                new AnswerModel { Id = 97, Answer = "Medarbetarnas beteende och medvetenhet", QuestionId = 33, IsCorrect = true },
                new AnswerModel { Id = 98, Answer = "Installation av antivirusprogramvara", QuestionId = 33, IsCorrect = false },
                new AnswerModel { Id = 99, Answer = "Användning av svaga lösenord", QuestionId = 33, IsCorrect = false },
                new AnswerModel { Id = 100, Answer = "För att skydda företagsnätverket mot obehörig åtkomst och skadlig kod", QuestionId = 34, IsCorrect = true },
                new AnswerModel { Id = 101, Answer = "För att dela känslig information offentligt", QuestionId = 34, IsCorrect = false },
                new AnswerModel { Id = 102, Answer = "För att öka nedladdningshastigheten", QuestionId = 34, IsCorrect = false },
                new AnswerModel { Id = 103, Answer = "Konfigurera användarbehörigheter och behörighetsgrupper", QuestionId = 35, IsCorrect = true },
                new AnswerModel { Id = 104, Answer = "Dela inloggningsuppgifter med andra användare", QuestionId = 35, IsCorrect = false },
                new AnswerModel { Id = 105, Answer = "Använda samma lösenord för alla konton", QuestionId = 35, IsCorrect = false },
                new AnswerModel { Id = 106, Answer = "Säkerhetskopiering och återställning av data", QuestionId = 36, IsCorrect = true },
                new AnswerModel { Id = 107, Answer = "Användning av svaga lösenord", QuestionId = 36, IsCorrect = false },
                new AnswerModel { Id = 108, Answer = "Delning av företagshemligheter på sociala medieplattformar", QuestionId = 36, IsCorrect = false },
                new AnswerModel { Id = 109, Answer = "Kryptering av känslig information", QuestionId = 37, IsCorrect = true },
                new AnswerModel { Id = 110, Answer = "Publicering av företagsuppgifter på offentliga webbplatser", QuestionId = 37, IsCorrect = false },
                new AnswerModel { Id = 111, Answer = "Användning av standardlösenord för Wi-Fi-router", QuestionId = 37, IsCorrect = false },
                new AnswerModel { Id = 112, Answer = "Ett ransomware-angrepp som krypterar företagets filer och kräver en lösensumma för att dekryptera dem", QuestionId = 38, IsCorrect = true },
                new AnswerModel { Id = 113, Answer = "Ett säkerhetskopieringsverktyg för att säkerhetskopiera företagets data", QuestionId = 38, IsCorrect = false },
                new AnswerModel { Id = 114, Answer = "Ett program för att skicka spam-e-post", QuestionId = 38, IsCorrect = false },
                new AnswerModel { Id = 115, Answer = "Utbildning av anställda om cybersäkerhetsbästa praxis", QuestionId = 39, IsCorrect = true },
                new AnswerModel { Id = 116, Answer = "Uppgradering av datorernas operativsystem", QuestionId = 39, IsCorrect = false },
                new AnswerModel { Id = 117, Answer = "Delning av inloggningsuppgifter med okända parter", QuestionId = 39, IsCorrect = false },
                new AnswerModel { Id = 118, Answer = "För att skydda företagets informationstillgångar, upprätthålla affärsfortsättning och följa lagliga krav", QuestionId = 40, IsCorrect = true },
                new AnswerModel { Id = 119, Answer = "För att dela känslig information på osäkra nätverk", QuestionId = 40, IsCorrect = false },
                new AnswerModel { Id = 120, Answer = "För att öka möjligheten till dataläckage", QuestionId = 40, IsCorrect = false },
                // Answers for Subcategory: Nätverkssäkerhet (ID: 9)
                new AnswerModel { Id = 121, Answer = "Konfigurera brandväggar med strikta regler och filtrera nätverkstrafik", QuestionId = 41, IsCorrect = true },
                new AnswerModel { Id = 122, Answer = "Använda publika Wi-Fi-nätverk utan försiktighet", QuestionId = 41, IsCorrect = false },
                new AnswerModel { Id = 123, Answer = "Dela lösenord med andra", QuestionId = 41, IsCorrect = false },
                new AnswerModel { Id = 124, Answer = "Övervakar nätverkstrafik och upptäcker avvikande mönster", QuestionId = 45, IsCorrect = true },
                new AnswerModel { Id = 125, Answer = "Ignorerar intrångsförsök", QuestionId = 45, IsCorrect = false },
                new AnswerModel { Id = 126, Answer = "Blockerar all nätverkstrafik", QuestionId = 45, IsCorrect = false },
                new AnswerModel { Id = 127, Answer = "Konfigurera brandväggar med rätt regler och filtrering av trafik", QuestionId = 49, IsCorrect = true },
                new AnswerModel { Id = 128, Answer = "Använda publika Wi-Fi-nätverk utan försiktighet", QuestionId = 49, IsCorrect = false },
                new AnswerModel { Id = 129, Answer = "Dela lösenord med andra", QuestionId = 49, IsCorrect = false },
                new AnswerModel { Id = 130, Answer = "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", QuestionId = 53, IsCorrect = true },
                new AnswerModel { Id = 131, Answer = "Använda publika Wi-Fi-nätverk utan försiktighet", QuestionId = 53, IsCorrect = false },
                new AnswerModel { Id = 132, Answer = "Dela lösenord med andra", QuestionId = 53, IsCorrect = false },
                new AnswerModel { Id = 133, Answer = "Känsliga data som lösenord, kryptonycklar och digitala signaturer", QuestionId = 57, IsCorrect = true },
                new AnswerModel { Id = 134, Answer = "Allmänna webbsidor", QuestionId = 57, IsCorrect = false },
                new AnswerModel { Id = 135, Answer = "Offentliga nycklar", QuestionId = 57, IsCorrect = false },

                // Answers for Subcategory: Cyberförsvar (ID: 10)
                new AnswerModel { Id = 136, Answer = "Övervakar nätverkstrafik och upptäcker avvikande mönster", QuestionId = 42, IsCorrect = true },
                new AnswerModel { Id = 137, Answer = "Ignorerar intrångsförsök", QuestionId = 42, IsCorrect = false },
                new AnswerModel { Id = 138, Answer = "Blockerar all nätverkstrafik", QuestionId = 42, IsCorrect = false },
                new AnswerModel { Id = 139, Answer = "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", QuestionId = 46, IsCorrect = true },
                new AnswerModel { Id = 140, Answer = "Använda publika Wi-Fi-nätverk utan försiktighet", QuestionId = 46, IsCorrect = false },
                new AnswerModel { Id = 141, Answer = "Dela lösenord med andra", QuestionId = 46, IsCorrect = false },
                new AnswerModel { Id = 142, Answer = "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", QuestionId = 50, IsCorrect = true },
                new AnswerModel { Id = 143, Answer = "Använda publika Wi-Fi-nätverk utan försiktighet", QuestionId = 50, IsCorrect = false },
                new AnswerModel { Id = 144, Answer = "Dela lösenord med andra", QuestionId = 50, IsCorrect = false },
                new AnswerModel { Id = 145, Answer = "Verifiera identiteten hos kommunikationsparter och säkerställa att data inte har manipulerats under överföringen", QuestionId = 54, IsCorrect = true },
                new AnswerModel { Id = 146, Answer = "Använda publika Wi-Fi-nätverk utan försiktighet", QuestionId = 54, IsCorrect = false },
                new AnswerModel { Id = 147, Answer = "Dela lösenord med andra", QuestionId = 54, IsCorrect = false },

                // Answers for Subcategory: Krypteringstekniker (ID: 11)
                new AnswerModel { Id = 148, Answer = "Snabbare och mer effektiv för att kryptera stora mängder data", QuestionId = 43, IsCorrect = true },
                new AnswerModel { Id = 149, Answer = "Mindre säker än asymmetrisk kryptering", QuestionId = 43, IsCorrect = false },
                new AnswerModel { Id = 150, Answer = "Endast lämplig för säker kommunikation inom nätverk", QuestionId = 43, IsCorrect = false },
                new AnswerModel { Id = 151, Answer = "Snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering", QuestionId = 47, IsCorrect = true },
                new AnswerModel { Id = 152, Answer = "Mindre säker än asymmetrisk kryptering", QuestionId = 47, IsCorrect = false },
                new AnswerModel { Id = 153, Answer = "Endast lämplig för kryptering av lösenord", QuestionId = 47, IsCorrect = false },
                new AnswerModel { Id = 154, Answer = "Snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering", QuestionId = 51, IsCorrect = true },
                new AnswerModel { Id = 155, Answer = "Mindre säker än asymmetrisk kryptering", QuestionId = 51, IsCorrect = false },
                new AnswerModel { Id = 156, Answer = "Endast lämplig för kryptering av lösenord", QuestionId = 51, IsCorrect = false },
                new AnswerModel { Id = 157, Answer = "Snabbare kryptering och avkryptering av filer jämfört med asymmetrisk kryptering", QuestionId = 55, IsCorrect = true },
                new AnswerModel { Id = 158, Answer = "Mindre säker än asymmetrisk kryptering", QuestionId = 55, IsCorrect = false },
                new AnswerModel { Id = 159, Answer = "Endast lämplig för kryptering av lösenord", QuestionId = 55, IsCorrect = false }

            );


            #endregion


        }
    }

}
