
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

        public async Task<IEnumerable<QuestionModel>> GetAllQuestionsAsync()
        {

            return await _dbContext.Questions.ToListAsync();
        }

        public async Task<QuestionModel?> GetQuestionByIdAsync(int id)
        {
            return await _dbContext.Questions.FindAsync(id);
        }

        // make method that takes in a question id and then returns that question with all the associated answers
        public async Task<QuestionModel?> GetQuestionByIdIncludingAnswersAsync(int id)
        {
            return await _dbContext.Questions.Include(x => x.Answers).FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task AddQuestionAsync(QuestionModel question)
        {
            _dbContext.Set<QuestionModel>().Add(question);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateQuestion(QuestionModel question)
        {
            _dbContext.Entry(question).State = EntityState.Modified;
            _dbContext.SaveChanges();
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
    }
}