﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<RequestLogs> RequestLogs { get; set; }

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

            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Att skydda sig mot Bedrägerier" },
                new CategoryModel { Id = 2, Name = "Cybersäkerhet för företag" },
                new CategoryModel { Id = 3, Name = "Cyberspionage" }
            );

            modelBuilder.Entity<SegmentModel>().HasData(
                new SegmentModel { Id = 1, Name = "Del 1", CategoryId = 1 },
                new SegmentModel { Id = 2, Name = "Del 2", CategoryId = 1 },
                new SegmentModel { Id = 3, Name = "Del 3", CategoryId = 1 },
                new SegmentModel { Id = 4, Name = "Del 1", CategoryId = 2 },
                new SegmentModel { Id = 5, Name = "Del 2", CategoryId = 2 },
                new SegmentModel { Id = 6, Name = "Del 1", CategoryId = 3 },
                new SegmentModel { Id = 7, Name = "Del 2", CategoryId = 3 },
                new SegmentModel { Id = 8, Name = "Del 3", CategoryId = 3 }
            );

            modelBuilder.Entity<SubcategoryModel>().HasData(
                new SubcategoryModel { Id = 1, Name = "Kreditkortsbedrägeri", SegmentId = 1 },
                new SubcategoryModel { Id = 2, Name = "Romansbedrägeri", SegmentId = 1 },
                new SubcategoryModel { Id = 3, Name = "Investeringsbedrägeri", SegmentId = 1 },
                new SubcategoryModel { Id = 4, Name = "Telefonbedrägeri", SegmentId = 1 },
                new SubcategoryModel { Id = 5, Name = "Digital säkerhet på företag", SegmentId = 4 },
                new SubcategoryModel { Id = 6, Name = "Risker och beredskap", SegmentId = 4 },
                new SubcategoryModel { Id = 7, Name = "Cyberangrepp mot känsliga sektorer", SegmentId = 4 },
                new SubcategoryModel { Id = 8, Name = "Allmänt om cyberspionage", SegmentId = 6 },
                new SubcategoryModel { Id = 9, Name = "Metoder för cyberspionage", SegmentId = 6 },
                new SubcategoryModel { Id = 10, Name = "Säkerhetsskyddslagen", SegmentId = 6 },
                new SubcategoryModel { Id = 11, Name = "Cyberspionagets aktörer", SegmentId = 6 },
                new SubcategoryModel { Id = 12, Name = "Social engineering", SegmentId = 7 },
                new SubcategoryModel { Id = 13, Name = "Virus, maskar och trojaner", SegmentId = 8 },


            #region GptData
                //NY DATA PÅHITTAD AV CHAT GPT
                new SubcategoryModel { Id = 14, Name = "Abonnemangsfällor och falska fakturor", SegmentId = 5 },
                new SubcategoryModel { Id = 15, Name = "Ransomware", SegmentId = 5 },
                new SubcategoryModel { Id = 16, Name = "Statistik och förhållningssätt", SegmentId = 5 },
                new SubcategoryModel { Id = 17, Name = "Utpressningsvirus", SegmentId = 6 },
                new SubcategoryModel { Id = 18, Name = "Attacker mot servrar", SegmentId = 6 },
                new SubcategoryModel { Id = 19, Name = "Cyberangrepp i Norden", SegmentId = 6 },
                new SubcategoryModel { Id = 20, Name = "Varning för vishing", SegmentId = 7 },
                new SubcategoryModel { Id = 21, Name = "Identifiera VD-mejl", SegmentId = 7 },
                new SubcategoryModel { Id = 22, Name = "Öneangrepp och presentkortsbluffar", SegmentId = 7 },
                new SubcategoryModel { Id = 23, Name = "Värvningsförsök", SegmentId = 8 },
                new SubcategoryModel { Id = 24, Name = "Affärsspionage", SegmentId = 8 },
                new SubcategoryModel { Id = 25, Name = "Påverkanskampanjer", SegmentId = 8 }
                #endregion

            );

            modelBuilder.Entity<QuestionModel>().HasData(
                new QuestionModel { Id = 1, Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank...", SubcategoryId = 1, Explanation = "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri." },
                new QuestionModel { Id = 2, Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida...", SubcategoryId = 2, Explanation = "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri." },
                new QuestionModel { Id = 3, Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag...", SubcategoryId = 3, Explanation = "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier." },

            #region GptData
                //DATA FRÅN CHATGPT
                new QuestionModel { Id = 4, Question = "Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?", SubcategoryId = 14, Explanation = "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö." },
                new QuestionModel { Id = 5, Question = "Vilken typ av angrepp har de sannolikt blivit utsatta för?", SubcategoryId = 15, Explanation = "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård." },
                new QuestionModel { Id = 6, Question = "Vilken typ av malware var primärt ansvarig för denna incident?", SubcategoryId = 16, Explanation = "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system." },
                new QuestionModel { Id = 7, Question = "Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?", SubcategoryId = 17, Explanation = "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper." },
                new QuestionModel { Id = 8, Question = "Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?", SubcategoryId = 18, Explanation = "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor." },
                new QuestionModel { Id = 9, Question = "Vilken lagstiftning ger ramverket för detta skydd?", SubcategoryId = 19, Explanation = "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot." },
                new QuestionModel { Id = 11, Question = "Vad ska du göra om du upptäcker obehöriga transaktioner på ditt kreditkort?", SubcategoryId = 1, Explanation = "Omedelbart kontakta ditt kreditkortsföretag för att rapportera de obehöriga transaktionerna och blockera ditt kort för att förhindra ytterligare skador." },
                new QuestionModel { Id = 12, Question = "Vilket är ett vanligt sätt för bedragare att stjäla kreditkortsuppgifter online?", SubcategoryId = 1, Explanation = "Phishing-webbplatser och skadlig programvara är vanliga metoder för att stjäla kreditkortsuppgifter online." },
                new QuestionModel { Id = 13, Question = "Hur kan du öka säkerheten när du handlar online med ditt kreditkort?", SubcategoryId = 1, Explanation = "Använd säkra och pålitliga webbplatser, kontrollera att webbadressen börjar med 'https://' och undvik att lagra kreditkortsuppgifter på webbplatser." },
                new QuestionModel { Id = 14, Question = "Varför är det viktigt att regelbundet övervaka dina kreditkortsutdrag?", SubcategoryId = 1, Explanation = "Regelbunden övervakning av kreditkortsutdrag hjälper till att upptäcka obehöriga transaktioner i tid och minskar risken för bedrägeri." },
                new QuestionModel { Id = 15, Question = "Vilken åtgärd bör vidtas om du misstänker att ditt kreditkort har blivit stulet?", SubcategoryId = 1, Explanation = "Omedelbart kontakta ditt kreditkortsföretag, spärra ditt kort och rapportera det till polisen för att förebygga obehöriga transaktioner." },
                new QuestionModel { Id = 16, Question = "Hur kan du undvika att bli offer för skimming på betalningsautomater?", SubcategoryId = 1, Explanation = "Undvik att använda betalningsautomater som ser misstänkta ut, täck ditt knappsatsinmatning när du skriver in din PIN-kod och övervaka ditt kreditkortsutdrag." },
                new QuestionModel { Id = 17, Question = "Vilket är ett vanligt tecken på kreditkortsbedrägeri vid onlineköp?", SubcategoryId = 1, Explanation = "Oregistrerade eller oseriösa webbplatser, särskilt med onormalt låga priser, kan vara tecken på kreditkortsbedrägeri." },
                new QuestionModel { Id = 18, Question = "Varför är det viktigt att inte dela ditt kreditkorts CVV-kod (säkerhetskod) med andra?", SubcategoryId = 1, Explanation = "CVV-koden används för att bekräfta att du har ditt fysiska kreditkort och bör hållas konfidentiell för att förhindra obehörig användning." },
                new QuestionModel { Id = 19, Question = "Hur kan du säkert förvara ditt fysiska kreditkort för att undvika stöld?", SubcategoryId = 1, Explanation = "Förvara ditt kreditkort på en säker plats, undvik att lämna det obevakat och använd plånböcker eller skyddsfodral för extra säkerhet." },
                new QuestionModel { Id = 20, Question = "Vilken åtgärd bör du vidta om ditt kreditkortsinformation har blivit komprometterad?", SubcategoryId = 1, Explanation = "Omedelbart kontakta ditt kreditkortsföretag, begär att kortet spärras och överväg att ändra ditt lösenord för extra säkerhet." }
                #endregion

            );
            modelBuilder.Entity<AnswerModel>().HasData(
                new AnswerModel { Id = 1, Answer = "Ett potentiellt telefonbedrägeri", QuestionId = 1, IsCorrect = true },
                new AnswerModel { Id = 2, Answer = "Ett legitimt försök från banken att skydda ditt konto", QuestionId = 1, IsCorrect = false },
                new AnswerModel { Id = 3, Answer = "En informationsinsamling för en marknadsundersökning", QuestionId = 1, IsCorrect = false },
                new AnswerModel { Id = 4, Answer = "Ett romansbedrägeri", QuestionId = 2, IsCorrect = true },
                new AnswerModel { Id = 5, Answer = "En legitim begäran om hjälp från en person i nöd", QuestionId = 2, IsCorrect = false },
                new AnswerModel { Id = 6, Answer = "Investeringsbedrägeri", QuestionId = 3, IsCorrect = true },
                new AnswerModel { Id = 7, Answer = "Genomföra omedelbar investering för att inte missa möjligheten", QuestionId = 3, IsCorrect = false },





            #region GptData
                // FRÅN CHAT GPT
                new AnswerModel { Id = 8, Answer = "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst", QuestionId = 4, IsCorrect = true },
                new AnswerModel { Id = 9, Answer = "Återgå till kontorsarbete", QuestionId = 4, IsCorrect = false },
                new AnswerModel { Id = 10, Answer = "Förbjuda användning av personliga enheter för arbete", QuestionId = 4, IsCorrect = false },
                new AnswerModel { Id = 11, Answer = "Organiserade cyberbrottsliga grupper", QuestionId = 7, IsCorrect = true },
                new AnswerModel { Id = 12, Answer = "En enskild hackare med ett personligt vendetta", QuestionId = 7, IsCorrect = false },
                new AnswerModel { Id = 13, Answer = "Implementera en ny brandvägg", QuestionId = 7, IsCorrect = false },
                new AnswerModel { Id = 14, Answer = "Slå på tvåfaktorsautentisering för alla fjärranslutningar", QuestionId = 5, IsCorrect = true },
                new AnswerModel { Id = 15, Answer = "Skriv ut alla dokument och undvik digital delning", QuestionId = 6, IsCorrect = false },
                new AnswerModel { Id = 16, Answer = "Använd samma lösenord för alla konton för enkelhetens skull", QuestionId = 7, IsCorrect = false },

                new AnswerModel { Id = 17, Answer = "Social engineering", QuestionId = 4, IsCorrect = true },
                new AnswerModel { Id = 18, Answer = "Stark kryptering", QuestionId = 3, IsCorrect = false },
                new AnswerModel { Id = 19, Answer = "Brandväggar", QuestionId = 8, IsCorrect = false },
                new AnswerModel { Id = 20, Answer = "Kontakta omedelbart kreditkortsföretaget och rapportera transaktionerna.", QuestionId = 11, IsCorrect = true },

                new AnswerModel { Id = 21, Answer = "Avvakta och se om det händer igen innan du agerar.", QuestionId = 11, IsCorrect = false },
                new AnswerModel { Id = 22, Answer = "Ignorera det och hoppas att det löser sig självt.", QuestionId = 11, IsCorrect = false },
                new AnswerModel { Id = 23, Answer = "Publicera informationen på sociala medier för att varna andra.", QuestionId = 11, IsCorrect = false },

                // Answers for Question 12
                new AnswerModel { Id = 24, Answer = "Skimming på betalningsautomater.", QuestionId = 12, IsCorrect = true },
                new AnswerModel { Id = 25, Answer = "Användning av säkra webbplatser.", QuestionId = 12, IsCorrect = false },
                new AnswerModel { Id = 26, Answer = "Delning av kreditkortsuppgifter via e-post.", QuestionId = 12, IsCorrect = false },
                new AnswerModel { Id = 27, Answer = "Användning av offentliga Wi-Fi-nätverk.", QuestionId = 12, IsCorrect = false },

                // Answers for Question 13
                new AnswerModel { Id = 28, Answer = "Använd säkra och pålitliga webbplatser.", QuestionId = 13, IsCorrect = true },
                new AnswerModel { Id = 29, Answer = "Lagra kreditkortsuppgifter offentligt.", QuestionId = 13, IsCorrect = false },
                new AnswerModel { Id = 30, Answer = "Dela kreditkortsuppgifter via e-post.", QuestionId = 13, IsCorrect = false },
                new AnswerModel { Id = 31, Answer = "Använda samma lösenord överallt för bekvämlighet.", QuestionId = 13, IsCorrect = false },

                // Answers for Question 14
                new AnswerModel { Id = 32, Answer = "Förhindra ytterligare skador.", QuestionId = 14, IsCorrect = true },
                new AnswerModel { Id = 33, Answer = "Ignorera det och hoppas att det försvinner.", QuestionId = 14, IsCorrect = false },
                new AnswerModel { Id = 34, Answer = "Rapportera det till ditt internetleverantörsupport.", QuestionId = 14, IsCorrect = false },
                new AnswerModel { Id = 35, Answer = "Kontakta ditt lokala postkontor.", QuestionId = 14, IsCorrect = false },

                // Answers for Question 15
                new AnswerModel { Id = 36, Answer = "Spärra kortet och rapportera till polisen.", QuestionId = 15, IsCorrect = true },
                new AnswerModel { Id = 37, Answer = "Avvakta och se om något händer.", QuestionId = 15, IsCorrect = false },
                new AnswerModel { Id = 38, Answer = "Publicera informationen på sociala medier.", QuestionId = 15, IsCorrect = false },
                new AnswerModel { Id = 39, Answer = "Inget behov av att göra något.", QuestionId = 15, IsCorrect = false },

                // Answers for Question 16
                new AnswerModel { Id = 40, Answer = "Undvik att använda misstänkta betalningsautomater.", QuestionId = 16, IsCorrect = true },
                new AnswerModel { Id = 41, Answer = "Använd alltid samma automater.", QuestionId = 16, IsCorrect = false },
                new AnswerModel { Id = 42, Answer = "Använd offentliga Wi-Fi-nätverk för att göra inköp.", QuestionId = 16, IsCorrect = false },
                new AnswerModel { Id = 43, Answer = "Dela din PIN-kod med andra för säkerhet.", QuestionId = 16, IsCorrect = false },

                // Answers for Question 17
                new AnswerModel { Id = 44, Answer = "Oregistrerade eller oseriösa webbplatser.", QuestionId = 17, IsCorrect = true },
                new AnswerModel { Id = 45, Answer = "Enbart välkända och etablerade webbplatser.", QuestionId = 17, IsCorrect = false },
                new AnswerModel { Id = 46, Answer = "Webbplatser med höga priser.", QuestionId = 17, IsCorrect = false },
                new AnswerModel { Id = 47, Answer = "Webbplatser med stort utbud av produkter.", QuestionId = 17, IsCorrect = false },

                // Answers for Question 18
                new AnswerModel { Id = 48, Answer = "Förhindra obehörig användning.", QuestionId = 18, IsCorrect = true },
                new AnswerModel { Id = 49, Answer = "Dela CVV-koden med nära vänner.", QuestionId = 18, IsCorrect = false },
                new AnswerModel { Id = 50, Answer = "Publicera CVV-koden online.", QuestionId = 18, IsCorrect = false },
                new AnswerModel { Id = 51, Answer = "Använda samma CVV-kod överallt.", QuestionId = 18, IsCorrect = false },

                // Answers for Question 19
                new AnswerModel { Id = 52, Answer = "Förvara det på en säker plats.", QuestionId = 19, IsCorrect = true },
                new AnswerModel { Id = 53, Answer = "Lämna det obevakat på offentliga platser.", QuestionId = 19, IsCorrect = false },
                new AnswerModel { Id = 54, Answer = "Dela det med okända personer.", QuestionId = 19, IsCorrect = false },
                new AnswerModel { Id = 55, Answer = "Använd det som bokmärke.", QuestionId = 19, IsCorrect = false },

                // Answers for Question 20
                new AnswerModel { Id = 56, Answer = "Kontakta kreditkortsföretaget och spärra kortet.", QuestionId = 20, IsCorrect = true },
                new AnswerModel { Id = 57, Answer = "Ignorera det och fortsätt använda det som vanligt.", QuestionId = 20, IsCorrect = false },
                new AnswerModel { Id = 58, Answer = "Publicera informationen på sociala medier.", QuestionId = 20, IsCorrect = false },
                new AnswerModel { Id = 59, Answer = "Använda samma lösenord på andra konton.", QuestionId = 20, IsCorrect = false }
                #endregion
                );


        }
    }

}
