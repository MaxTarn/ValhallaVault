using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        DbSet<AnswerModel> Answers { get; set; }
        DbSet<QuestionModel> Questions { get; set; }
        DbSet<CategoryModel> Categories { get; set; }
        DbSet<SubcategoryModel> Subcategories { get; set; }
        DbSet<SegmentModel> Segments { get; set; }

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


        }
    }
}
