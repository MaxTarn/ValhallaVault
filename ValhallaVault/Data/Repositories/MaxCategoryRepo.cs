using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories;

public class MaxCategoryRepo
{
    private readonly ProgramDbContext _context;

    public MaxCategoryRepo(ProgramDbContext dbContext)
    {
        _context = dbContext;
    }

    public CategoryModel? GetFirst()
    {
        return _context.Categories.FirstOrDefault();
    }

    public List<CategoryModel>? GetAll()
    {
        return _context.Categories.ToList();
    }
}

