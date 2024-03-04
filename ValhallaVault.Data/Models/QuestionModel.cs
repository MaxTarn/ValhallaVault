using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaVault.Data.Models;

public class QuestionModel
{
    public string? Question { get; set; } = null!;
    public List<AnswerModel>? Answers { get; set; } = null!;


}

