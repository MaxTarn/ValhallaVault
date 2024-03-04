namespace ValhallaVault.Data.Models;

public class QuestionModel
{
    public string? Question { get; set; } = null!;
    public List<AnswerModel>? Answers { get; set; } = null!;
    public string Category { get; set; }
}

