
using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;


namespace ValhallaVault.Data.Repositories
{
    public class QuestionRepo : IQuestionRepository
    {
        private readonly ProgramDbContext _dbContext;

        public QuestionRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestionsAsync()
        {

            return await _dbContext.Questions.ToListAsync();
        }

        public async Task<QuestionModel?> GetQuestionByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Questions.FindAsync(id);
        }

        public async Task<QuestionModel?> GetQuestionByIdIncludingAnswersAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Questions.Include(x => x.Answers).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task AddQuestionAsync(QuestionModel? question)
        {
            if (question == null)
            {
                return;
            }
            _dbContext.Set<QuestionModel>().Add(question);
        }

        public void UpdateQuestion(QuestionModel? question)
        {
            if (question == null)
            {
                return;
            }
            _dbContext.Entry(question).State = EntityState.Modified;
        }

        public async Task<QuestionModel?> DeleteQuestionAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var question = await _dbContext.Questions.FindAsync(id);

            if (question != null)
            {
                _dbContext.Questions.Remove(question);
                await _dbContext.SaveChangesAsync();
                return question;
            }
            else
            {
                throw new Exception("No question found with the specified ID.");
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<QuestionModel?> GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionModel?> GetQuestionByIdIncludingAnswersAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}