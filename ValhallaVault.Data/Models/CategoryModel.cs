using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SegmentModel>? Segments { get; set; }
        public List<int> SegmentIds { get; set; }
    }
}
