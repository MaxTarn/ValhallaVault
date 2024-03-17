using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{

    public class SegmentRepo : ISegmentRepository
    {
        private readonly ProgramDbContext _dbContext;

        public SegmentRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SegmentModel>> GetAllSegmentsAsync()
        {
            return await _dbContext.Segments.ToListAsync();
        }

        public async Task<SegmentModel?> GetSegmentByIdAsync(int id)
        {
            return await _dbContext.Segments.FindAsync(id);
        }

        public async Task<SegmentModel?> GetSegmentByIdWithEagerLoadingAsync(int id)
        {
            return await _dbContext.Segments
                .Include(x => x.Subcategories)
                .ThenInclude(subcategory => subcategory.Questions)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddSegmentAsync(SegmentModel segment)
        {
            _dbContext.Segments.Add(segment);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateSegmentAsync(SegmentModel segment)
        {
            _dbContext.Entry(segment).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<SegmentModel?> DeleteSegmentAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var segment = await _dbContext.Segments.FindAsync(id);
            if (segment != null)
            {
                _dbContext.Segments.Remove(segment);
                await _dbContext.SaveChangesAsync();
                return segment;
            }
            else
            {
                throw new Exception("No segment found with the specified ID.");
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}