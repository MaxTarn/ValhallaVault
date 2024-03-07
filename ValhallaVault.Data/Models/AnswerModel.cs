using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValhallaVault.Data.Models;

public class AnswerModel
{
    [Key]
    public int Id { get; set; }
    public string? Answer { get; set; }
    public int QuestionId { get; set; }
    [JsonIgnore]
    public QuestionModel? Question { get; set; }
    public bool? IsCorrect { get; set; }

}

