using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface IUserQuestionRepository
    {
        Task<IEnumerable<UserQuestionModel>> GetAllUserQuestionAsync();
        Task<UserQuestionModel?> GetUserQuestionByIdAsync(int id);
        Task AddUserQuestionAsync(UserQuestionModel userQuestion);
        Task UpdateUserQuestionAsync(int id, UserQuestionModel updatedUserQuestionModel);
        Task DeleteUserQuestionAsync(int id);
        Task SaveAsync();
    }
}
