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
				new SubcategoryModel { Id = 13, Name = "Virus, maskar och trojaner", SegmentId = 8 }

			);

			modelBuilder.Entity<QuestionModel>().HasData(
				new QuestionModel { Id = 1, Question = "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank...", SubcategoryId = 1, Explanation = "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri." },
				new QuestionModel { Id = 2, Question = "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida...", SubcategoryId = 2, Explanation = "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri." },
				new QuestionModel { Id = 3, Question = "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag...", SubcategoryId = 3, Explanation = "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier." }

			);
			modelBuilder.Entity<AnswerModel>().HasData(
	new AnswerModel { Id = 1, Answer = "Ett potentiellt telefonbedrägeri", QuestionId = 1, IsCorrect = true },
	new AnswerModel { Id = 2, Answer = "Ett legitimt försök från banken att skydda ditt konto", QuestionId = 1, IsCorrect = false },
	new AnswerModel { Id = 3, Answer = "En informationsinsamling för en marknadsundersökning", QuestionId = 1, IsCorrect = false },


	new AnswerModel { Id = 4, Answer = "Ett romansbedrägeri", QuestionId = 2, IsCorrect = true },
	new AnswerModel { Id = 5, Answer = "En legitim begäran om hjälp från en person i nöd", QuestionId = 2, IsCorrect = false },

	new AnswerModel { Id = 6, Answer = "Investeringsbedrägeri", QuestionId = 3, IsCorrect = true },
	new AnswerModel { Id = 7, Answer = "Genomföra omedelbar investering för att inte missa möjligheten", QuestionId = 3, IsCorrect = false },


);

		}
	}
}
