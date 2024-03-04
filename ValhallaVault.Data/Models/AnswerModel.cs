using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaVault.Data.Models;

public class AnswerModel
{
    [Key]
    public int Id { get; set; }

    public string? Answer { get; set; } = null!;
    public bool? IsCorrect { get; set; }

}

