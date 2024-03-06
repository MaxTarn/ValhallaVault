using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaVault.Data.Models;

public class UserQuestionModel
{
    [Key]
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public int QuestionId { get; set; }

    public bool? IsCorrect { get; set; }
}

