using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValhallaVault.Data.Models
{
    public class SubcategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int SegmentId { get; set; }
        public SegmentModel? Segment { get; set; }
        [JsonIgnore]
        public List<QuestionModel>? Questions { get; set; } = new();

    }
}
