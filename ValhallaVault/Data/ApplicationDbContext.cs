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
    }
}
