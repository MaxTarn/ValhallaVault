using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class AnswerRepo
    {
        private readonly DbContext _dbContext;

        public AnswerRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AnswerModel>> GetAllAnswers()
        {
            return _dbContext.Set<AnswerModel>().ToList();
        }

        public AnswerModel GetAnswerById(int id)
        {
            return _dbContext.Set<AnswerModel>().Find(id);
        }

        public void AddAnswer(AnswerModel answer)
        {
            _dbContext.Set<AnswerModel>().Add(answer);
            _dbContext.SaveChanges();
        }

        public void UpdateAnswer(AnswerModel answer)
        {
            _dbContext.Entry(answer).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteAnswer(int id)
        {
            var answer = _dbContext.Set<AnswerModel>().Find(id);
            if (answer != null)
            {
                _dbContext.Set<AnswerModel>().Remove(answer);
            }
            else
            {
                throw new Exception("No answer found with the specified ID.");
            }
        }
    }
}
