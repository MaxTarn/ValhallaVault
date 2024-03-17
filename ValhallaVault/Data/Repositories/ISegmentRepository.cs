using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Repositories
{
    public interface ISegmentRepository
    {
        Task<IEnumerable<SegmentModel>> GetAllSegmentsAsync();
        Task<SegmentModel?> GetSegmentByIdAsync(int id);
        Task<SegmentModel?> GetSegmentByIdWithEagerLoadingAsync(int id);
        Task AddSegmentAsync(SegmentModel segment);
        void UpdateSegmentAsync(SegmentModel segment);
        Task<SegmentModel?> DeleteSegmentAsync(int id);
        Task SaveAsync();
    }
}
