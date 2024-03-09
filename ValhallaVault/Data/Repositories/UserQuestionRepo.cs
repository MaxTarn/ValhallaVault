using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories;


public class UserQuestionRepo : IUserQuestionRepository
{

    private readonly ProgramDbContext _dbContext;

    public UserQuestionRepo(ProgramDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<UserQuestionModel>> GetAllUserQuestionAsync()
    {
        return await _dbContext.UserQuestions.ToListAsync();
    }

    public async Task<UserQuestionModel?> GetUserQuestionByIdAsync(int id)
    {
        return await _dbContext.UserQuestions.FindAsync(id);
    }

    public async Task AddUserQuestionAsync(UserQuestionModel userQuestion)
    {
        _dbContext.UserQuestions.Add(userQuestion);
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateUserQuestionAsync(int id, UserQuestionModel updatedUserQuestionModel)
    {
        UserQuestionModel? userQuestionToUpdate = await GetUserQuestionByIdAsync(id);
        if (userQuestionToUpdate != null)
        {
            userQuestionToUpdate.UserId = updatedUserQuestionModel.UserId;
            userQuestionToUpdate.QuestionId = updatedUserQuestionModel.QuestionId;
            userQuestionToUpdate.IsCorrect = updatedUserQuestionModel.IsCorrect;
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("User question not found.");
        }
    }

    public async Task DeleteUserQuestionAsync(int id)
    {
        //tror inte metoden behövs?
    }
    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
