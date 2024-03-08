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

        public async Task<IEnumerable<AnswerModel>> GetAllAnswersAsync()
        {
            return await _dbContext.Answers.ToListAsync();
        }

        public async Task<AnswerModel?> GetAnswerByIdAsync(int id)
        {
            return await _dbContext.Answers.FindAsync(id);
        }

        public async Task AddAnswerAsync(AnswerModel answer)
        {
            _dbContext.Set<AnswerModel>().Add(answer);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateAnswerAsync(AnswerModel answer)
        {
            _dbContext.Entry(answer).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<AnswerModel?> DeleteAnswerAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var answer = await _dbContext.Answers.FindAsync(id);
            if (answer != null)
            {
                _dbContext.Set<AnswerModel>().Remove(answer);
                return answer;
            }
            else
            {
                throw new Exception("No answer found with the specified ID.");
            }
        }
        public async Task SaveAsyncAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}