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





    /// <summary>
    /// This will not store any data in the DataBase.
    /// Only used when getting data and knowing if the user has ticked in this particular answer.
    /// [[ Yanky as all hell ]]
    /// but most likely the easiest way to do this(if it actually works the way im thinking?? hopefully)
    /// Ask Max if this should be deleted before deleting this 
    /// </summary>
    public bool? IsChecked { get; set; }



}

