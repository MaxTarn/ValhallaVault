using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models;

public class AnswerModel
{
    [Key]
    public int Id { get; set; }
    public string? Answer { get; set; } = null!;
    public int QuestionModelId { get; set; }
    public QuestionModel? Question { get; set; }
    public bool? IsCorrect { get; set; }

}

