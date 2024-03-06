using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models;

public class QuestionModel
{

	[Key]
	public int Id { get; set; }
	public string? Question { get; set; } = null!;
	public int SubcategoryId { get; set; }
	public SubcategoryModel? Subcategory { get; set; }
	public List<AnswerModel>? Answers { get; set; } = null!;
  public string Explanation { get; set; }


}