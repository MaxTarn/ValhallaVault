using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{

    public class SegmentRepo
    {
        private readonly ProgramDbContext _dbContext;

        public SegmentRepo(ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SegmentModel>> GetAllSegments()
        {
            return await _dbContext.Segments.ToListAsync();
        }

        public async Task<SegmentModel?> GetSegmentById(int id)
        {
            return await _dbContext.Set<SegmentModel>().FindAsync(id);
        }

        //make method that gets all segments with a specific category Id //menade du kanske segemnt med sub?
        public async Task<SegmentModel?> GetSegmentByIdIncludingSubcategoriesAsync(int id)
        {
            return await _dbContext.Segments.Include(x => x.Subcategories).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddSegment(SegmentModel segment)
        {
            _dbContext.Set<SegmentModel>().Add(segment);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateSegment(SegmentModel segment)
        {
            _dbContext.Entry(segment).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task<SegmentModel?> DeleteSegment(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var segment = await _dbContext.Set<SegmentModel>().FindAsync(id);
            if (segment != null)
            {
                _dbContext.Set<SegmentModel>().Remove(segment);
                return segment;
            }
            else
            {
                throw new Exception("No segment found with the specified ID.");
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}