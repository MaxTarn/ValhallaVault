using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;


namespace ValhallaVault.Data.Repositories
{
    public class QuestionRepo
    {
        private readonly DbContext _dbContext;

        public QuestionRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<QuestionModel>> GetAllQuestions()
        {

            return _dbContext.Set<QuestionModel>().ToList();
        }

        public QuestionModel GetQuestionById(int id)
        {
            return _dbContext.Set<QuestionModel>().Find(id);
        }

        public void AddQuestion(QuestionModel question)
        {
            _dbContext.Set<QuestionModel>().Add(question);
            _dbContext.SaveChanges();
        }

        public void UpdateQuestion(QuestionModel question)
        {
            _dbContext.Entry(question).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteQuestion(int id)
        {
            var question = _dbContext.Set<QuestionModel>().Find(id);
            if (question != null)
            {
                _dbContext.Set<QuestionModel>().Remove(question);
            }
            else
            {
                throw new Exception("No question found with the specified ID.");
            }
        }
    }
}
