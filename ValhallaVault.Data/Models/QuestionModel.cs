using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models;

public class QuestionModel
{
    [Key]
    public int Id { get; set; }
    public string? Question { get; set; } = null!;
    public int SubcategoryModelId { get; set; }
    public SubcategoryModel? Subcategory { get; set; }
    public List<AnswerModel>? Answers { get; set; } = null!;
    public List<int> AnswerIds { get; set; }

}