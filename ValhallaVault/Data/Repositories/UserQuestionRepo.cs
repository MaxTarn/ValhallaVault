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
    public async Task<IEnumerable<UserQuestionModel>> GetAllUserQuestionsAsync()
    {
        return await _dbContext.UserQuestions.ToListAsync();
    }

    public async Task AddUserQuestionAsync(UserQuestionModel? userQuestion)
    {
        if (userQuestion == null)
        {
            return;
        }
        _dbContext.UserQuestions.Add(userQuestion);
    }

    public async Task DeleteUserQuestionAsync(int id)
    {
        //tror inte metoden behövs?
    }
    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserQuestionModel?> GetUserQuestionByIdAsync(int id)
    {
        if (id == null)
        {
            return null;
        }
        return await _dbContext.UserQuestions.FindAsync(id);
    }

    public async Task UpdateUserQuestionAsync(int id, UserQuestionModel updatedUserQuestionModel)
    {
        UserQuestionModel? userQuestionToUpdate = await GetUserQuestionByIdAsync(id);
        if (id == null)
        {
            return;
        }

        userQuestionToUpdate.UserId = updatedUserQuestionModel.UserId;
        userQuestionToUpdate.QuestionId = updatedUserQuestionModel.QuestionId;
        userQuestionToUpdate.IsCorrect = updatedUserQuestionModel.IsCorrect;
    }
}
