﻿using Microsoft.EntityFrameworkCore;
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
            return _dbContext.Set<SegmentModel>().ToList();
        }

        public async Task<SegmentModel?> GetSegmentById(int id)
        {
            return await _dbContext.Set<SegmentModel>().FindAsync(id);
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
