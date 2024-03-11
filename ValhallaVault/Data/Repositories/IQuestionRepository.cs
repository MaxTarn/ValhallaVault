using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<QuestionModel>> GetAllQuestionsAsync();
        Task<QuestionModel?> GetQuestionByIdAsync(int id);
        Task<QuestionModel?> GetQuestionByIdIncludingAnswersAsync(int id);
        Task AddQuestionAsync(QuestionModel question);
        void UpdateQuestion(QuestionModel question);
        Task<QuestionModel?> DeleteQuestionAsync(int id);
        Task SaveAsync();
    }
}
