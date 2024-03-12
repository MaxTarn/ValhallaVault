using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models;

public class UserQuestionModel
{
    [Key]
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int QuestionId { get; set; }

    public bool? IsCorrect { get; set; }
}

