using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories;


public class UserQuestionRepo
{
    //TODO add Crud operations
    private readonly ProgramDbContext _dbContext;

    public UserQuestionRepo(ProgramDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<UserQuestionModel> GetAll()
    {
        return _dbContext.UserQuestions.ToList();
    }

    public void Add(UserQuestionModel addThis)
    {
        _dbContext.UserQuestions.Add(addThis);
    }

    public int CountCorrectAnswers(string userId )
    {
        return _dbContext.UserQuestions.Where(u => u.UserId == userId && u.IsCorrect == true).Count();
    }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }
}
