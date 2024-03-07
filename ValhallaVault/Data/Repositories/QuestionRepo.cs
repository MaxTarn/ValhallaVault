
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
        }

        public void UpdateQuestion(QuestionModel question)
        {
            _dbContext.Entry(question).State = EntityState.Modified;
        }

        public async Task<QuestionModel> DeleteQuestion(int id)
        {
            var question = await _dbContext.Questions.FindAsync(id);

            if (question != null)
            {
                _dbContext.Questions.Remove(question);

                return question;
            }
            else
            {
                throw new Exception("No question found with the specified ID.");
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}