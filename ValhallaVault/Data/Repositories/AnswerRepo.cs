using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class AnswerRepo : IAnswerRepository
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

        public async Task<AnswerModel?> GetAnswerByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await _dbContext.Answers.FindAsync(id);
        }

        public async Task AddAnswerAsync(AnswerModel? answer)
        {
            if (answer == null)
            {
                return;
            }
            _dbContext.Set<AnswerModel>().Add(answer);
        }

        public async Task UpdateAnswerAsync(AnswerModel? answer)
        {
            if (answer == null)
            {
                return;
            }
            _dbContext.Entry(answer).State = EntityState.Modified;
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
                _dbContext.Answers.Remove(answer);
                await _dbContext.SaveChangesAsync();
                return answer;
            }
            else
            {
                throw new Exception("No answer found with the specified ID.");
            }
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<AnswerModel?> GetAnswerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}