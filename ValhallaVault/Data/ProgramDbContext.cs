using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;


namespace ValhallaVault.Data;


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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryModel>()
            .HasMany(c => c.Segments)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryModelId);

        modelBuilder.Entity<SegmentModel>()
            .HasMany(s => s.Subcategories)
            .WithOne(s => s.Segment)
            .HasForeignKey(s => s.SegmentModelId);

        modelBuilder.Entity<SubcategoryModel>()
            .HasMany(s => s.Questions)
            .WithOne(q => q.Subcategory)
            .HasForeignKey(q => q.SubcategoryId);

        modelBuilder.Entity<QuestionModel>()
            .HasMany(q => q.Answers)
            .WithOne(s => s.Question)
            .HasForeignKey(q => q.QuestionId);




        modelBuilder.Entity<CategoryModel>().HasData(
            new CategoryModel { Id = 1, Name = "Att skydda sig mot Bedrägerier" },
            new CategoryModel { Id = 2, Name = "Cybersäkerhet för företag" },
            new CategoryModel { Id = 3, Name = "Cyberspionage" }
        );

        modelBuilder.Entity<SegmentModel>().HasData(
            new SegmentModel { Id = 1, Name = "Del 1", CategoryModelId = 1 },
            new SegmentModel { Id = 2, Name = "Del 2", CategoryModelId = 1 },
            new SegmentModel { Id = 3, Name = "Del 3", CategoryModelId = 1 },
            new SegmentModel { Id = 4, Name = "Del 1", CategoryModelId = 2 },
            new SegmentModel { Id = 5, Name = "Del 2", CategoryModelId = 2 },
            new SegmentModel { Id = 6, Name = "Del 1", CategoryModelId = 3 },
            new SegmentModel { Id = 7, Name = "Del 2", CategoryModelId = 3 },
            new SegmentModel { Id = 8, Name = "Del 3", CategoryModelId = 3 }
        );

        modelBuilder.Entity<SubcategoryModel>().HasData(
            new SubcategoryModel { Id = 1, Name = "Kreditkortsbedrägeri", SegmentModelId = 1 },
            new SubcategoryModel { Id = 2, Name = "Romansbedrägeri", SegmentModelId = 1 },
            new SubcategoryModel { Id = 3, Name = "Investeringsbedrägeri", SegmentModelId = 1 },
            new SubcategoryModel { Id = 4, Name = "Telefonbedrägeri", SegmentModelId = 1 },
            new SubcategoryModel { Id = 5, Name = "Digital säkerhet på företag", SegmentModelId = 4 },
            new SubcategoryModel { Id = 6, Name = "Risker och beredskap", SegmentModelId = 4 },
            new SubcategoryModel { Id = 7, Name = "Cyberangrepp mot känsliga sektorer", SegmentModelId = 4 },
            new SubcategoryModel { Id = 8, Name = "Allmänt om cyberspionage", SegmentModelId = 6 },
            new SubcategoryModel { Id = 9, Name = "Metoder för cyberspionage", SegmentModelId = 6 },
            new SubcategoryModel { Id = 10, Name = "Säkerhetsskyddslagen", SegmentModelId = 6 },
            new SubcategoryModel { Id = 11, Name = "Cyberspionagets aktörer", SegmentModelId = 6 },
            new SubcategoryModel { Id = 12, Name = "Social engineering", SegmentModelId = 7 },
            new SubcategoryModel { Id = 13, Name = "Virus, maskar och trojaner", SegmentModelId = 8 },

            //NY DATA PÅHITTAD AV CHAT GPT
            new SubcategoryModel { Id = 14, Name = "Abonnemangsfällor och falska fakturor", SegmentModelId = 5 },
            new SubcategoryModel { Id = 15, Name = "Ransomware", SegmentModelId = 5 },
            new SubcategoryModel { Id = 16, Name = "Statistik och förhållningssätt", SegmentModelId = 5 },
             new SubcategoryModel { Id = 17, Name = "Utpressningsvirus", SegmentModelId = 6 },
             new SubcategoryModel { Id = 18, Name = "Attacker mot servrar", SegmentModelId = 6 },
             new SubcategoryModel { Id = 19, Name = "Cyberangrepp i Norden", SegmentModelId = 6 },
             new SubcategoryModel { Id = 20, Name = "Varning för vishing", SegmentModelId = 7 },
              new SubcategoryModel { Id = 21, Name = "Identifiera VD-mejl", SegmentModelId = 7 },
             new SubcategoryModel { Id = 22, Name = "Öneangrepp och presentkortsbluffar", SegmentModelId = 7 },
             new SubcategoryModel { Id = 23, Name = "Värvningsförsök", SegmentModelId = 8 },
             new SubcategoryModel { Id = 24, Name = "Affärsspionage", SegmentModelId = 8 },
              new SubcategoryModel { Id = 25, Name = "Påverkanskampanjer", SegmentModelId = 8 }


        );

        modelBuilder.Entity<QuestionModel>().HasData(
            new QuestionModel { Id = 1, Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank...", SubcategoryId = 1, Explanation = "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri." },
            new QuestionModel { Id = 2, Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida...", SubcategoryId = 2, Explanation = "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri." },
            new QuestionModel { Id = 3, Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag...", SubcategoryId = 3, Explanation = "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier." },
            //DATA FRÅN CHATGPT
            new QuestionModel { Id = 4, Question = "Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?", SubcategoryId = 14, Explanation = "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö." },
            new QuestionModel { Id = 5, Question = "Vilken typ av angrepp har de sannolikt blivit utsatta för?", SubcategoryId = 15, Explanation = "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård." },
            new QuestionModel { Id = 6, Question = "Vilken typ av malware var primärt ansvarig för denna incident?", SubcategoryId = 16, Explanation = "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system." },
            new QuestionModel { Id = 7, Question = "Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?", SubcategoryId = 17, Explanation = "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper." },
             new QuestionModel { Id = 8, Question = "Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?", SubcategoryId = 18, Explanation = "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor." },
            new QuestionModel { Id = 9, Question = "Vilken lagstiftning ger ramverket för detta skydd?", SubcategoryId = 19, Explanation = "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot." }

        );
        modelBuilder.Entity<AnswerModel>().HasData(
        new AnswerModel { Id = 1, Answer = "Ett potentiellt telefonbedrägeri", QuestionId = 1, IsCorrect = true },
        new AnswerModel { Id = 2, Answer = "Ett legitimt försök från banken att skydda ditt konto", QuestionId = 1, IsCorrect = false },
        new AnswerModel { Id = 3, Answer = "En informationsinsamling för en marknadsundersökning", QuestionId = 1, IsCorrect = false },
         new AnswerModel { Id = 4, Answer = "Ett romansbedrägeri", QuestionId = 2, IsCorrect = true },
        new AnswerModel { Id = 5, Answer = "En legitim begäran om hjälp från en person i nöd", QuestionId = 2, IsCorrect = false },
         new AnswerModel { Id = 6, Answer = "Investeringsbedrägeri", QuestionId = 3, IsCorrect = true },
         new AnswerModel { Id = 7, Answer = "Genomföra omedelbar investering för att inte missa möjligheten", QuestionId = 3, IsCorrect = false },
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
        new AnswerModel { Id = 19, Answer = "Brandväggar", QuestionId = 8, IsCorrect = false });
    }
}
