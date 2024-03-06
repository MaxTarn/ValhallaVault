using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public class SegmentRepo
    {
        private readonly DbContext _dbContext;

        public SegmentRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SegmentModel>> GetAllSegments()
        {
            return _dbContext.Set<SegmentModel>().ToList();
        }

        public SegmentModel GetSegmentById(int id)
        {
            return _dbContext.Set<SegmentModel>().Find(id);
        }

        public void AddSegment(SegmentModel segment)
        {
            _dbContext.Set<SegmentModel>().Add(segment);
            _dbContext.SaveChanges();
        }

        public void UpdateSegment(SegmentModel segment)
        {
            _dbContext.Entry(segment).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteSegment(int id)
        {
            var segment = _dbContext.Set<SegmentModel>().Find(id);
            if (segment != null)
            {
                _dbContext.Set<SegmentModel>().Remove(segment);
            }
            else
            {
                throw new Exception("No segment found with the specified ID.");
            }
        }
    }
}
