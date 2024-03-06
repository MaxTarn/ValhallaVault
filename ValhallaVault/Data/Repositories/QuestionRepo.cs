
using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;


namespace ValhallaVault.Data.Repositories
{
    public class QuestionRepo
    {
        private readonly ProgramDbContext _dbContext;

        public QuestionRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestions()
        {

            return _dbContext.Set<QuestionModel>().ToList();
        }

        public async Task<QuestionModel?> GetQuestionById(int id)
        {
            return await _dbContext.Set<QuestionModel>().FindAsync(id);
        }

        public async Task AddQuestion(QuestionModel question)
        {
            _dbContext.Set<QuestionModel>().Add(question);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateQuestion(QuestionModel question)
        {
            _dbContext.Entry(question).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<QuestionModel?> DeleteQuestion(int id)
        {
            var question = _dbContext.Questions.Find(id);
            if (question != null)
            {
                await _dbContext.Questions.RemoveAsync(question);
            }
            else
            {
                throw new Exception("No question found with the specified ID.");
            }
        }
    }
}
