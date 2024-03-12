using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<AnswerModel>> GetAllAnswersAsync();
        Task<AnswerModel?> GetAnswerByIdAsync(int id);
        Task AddAnswerAsync(AnswerModel answer);
        Task UpdateAnswerAsync(AnswerModel answer);
        Task<AnswerModel?> DeleteAnswerAsync(int id);
        Task SaveAsync();
    }
}
