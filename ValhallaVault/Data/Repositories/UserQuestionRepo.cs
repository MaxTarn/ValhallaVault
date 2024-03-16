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

    public async Task<UserQuestionModel?> GetUserQuestionByIdAsync(int? id)
    {
        if (id == null)
        {
            return null;
        }
        return await _dbContext.UserQuestions.FindAsync(id);
    }

    public async Task AddUserQuestionAsync(UserQuestionModel? userQuestion)
    {
        if (userQuestion == null)
        {
            return;
        }
        _dbContext.UserQuestions.Add(userQuestion);
    }

    public async Task UpdateUserQuestionAsync(int? id, UserQuestionModel? updatedUserQuestionModel)
    {
        UserQuestionModel? userQuestionToUpdate = await GetUserQuestionByIdAsync(id);
        if (id == null || userQuestionToUpdate == null)
        {
            return;
        }

        userQuestionToUpdate.UserId = updatedUserQuestionModel.UserId;
        userQuestionToUpdate.QuestionId = updatedUserQuestionModel.QuestionId;
        userQuestionToUpdate.IsCorrect = updatedUserQuestionModel.IsCorrect;

    }

    public double? CorrectAnswerPercentageSegment(string userId, string segment)
    {
        if (userId == null || segment == null)
        {
            return null;
        }

        int totalQuestions = _dbContext.UserQuestions.Count(u => u.UserId == userId && u.Subcategory.Segment.Name == segment);
        int correctAnswers = _dbContext.UserQuestions.Count(u => u.UserId == userId && u.IsCorrect == true && u.Subcategory.Segment.Name == segment);


        if (totalQuestions == 0)
        {
            return 0;
        }

        double percentage = (double)correctAnswers / totalQuestions * 100;

        return Math.Round(percentage, 2);
    }

    public double? CorrectAnswersSubcategory(string userId, string subcategory)
    {
        if (userId == null || subcategory == null)
        {
            return null;
        }

        int totalQuestions = _dbContext.UserQuestions.Count(u => u.UserId == userId && u.Question.Subcategory.Name == subcategory);
        int correctAnswers = _dbContext.UserQuestions.Count(u => u.UserId == userId && u.IsCorrect == true && u.Question.Subcategory.Name == subcategory);


        if (totalQuestions == 0)
        {
            return 0;
        }

        double percentage = (double)correctAnswers / totalQuestions * 100;

        return Math.Round(percentage, 2);
    }

    public async Task DeleteUserQuestionAsync(int id)
    {
        //tror inte metoden behövs?
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();

    }

    public Task<UserQuestionModel?> GetUserQuestionByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserQuestionAsync(int id, UserQuestionModel updatedUserQuestionModel)
    {
        throw new NotImplementedException();
    }
}
