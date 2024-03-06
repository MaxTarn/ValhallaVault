using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class AnswerRepo
    {
        private readonly ProgramDbContext _dbContext;

        public AnswerRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AnswerModel>> GetAllAnswers()
        {
            return _dbContext.Set<AnswerModel>().ToList();
        }

        public async Task<AnswerModel?> GetAnswerById(int id)
        {
            return await _dbContext.Set<AnswerModel>().FindAsync(id);
        }

        public async Task AddAnswer(AnswerModel answer)
        {
            _dbContext.Set<AnswerModel>().Add(answer);
            await _dbContext.SaveChangesAsync();
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
