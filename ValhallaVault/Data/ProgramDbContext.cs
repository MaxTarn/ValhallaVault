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
                .HasForeignKey(s => s.CategoryModelId);

            modelBuilder.Entity<SegmentModel>()
                .HasMany(s => s.Subcategories)
                .WithOne(s => s.Segment)
                .HasForeignKey(s => s.SegmentModelId);

            modelBuilder.Entity<SubcategoryModel>()
                .HasMany(s => s.Questions)
                .WithOne(q => q.Subcategory)
                .HasForeignKey(q => q.SubcategoryModelId);

            modelBuilder.Entity<QuestionModel>()
                .HasMany(q => q.Answers)
                .WithOne(s => s.Question)
                .HasForeignKey(q => q.QuestionModelId);

            modelBuilder.Entity<UserQuestionModel>()
                .HasOne<QuestionModel>() // One UserQuestionModel has one associated QuestionModel
                .WithMany()
                .HasForeignKey(uq => uq.QuestionId);
        }
    }
}
