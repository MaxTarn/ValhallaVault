using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaVault.Data.Models;

public class AnswerContainer
{
    public string Style { get; set; }
    public bool IsChecked { get; set; }

    public AnswerModel Answer { get; set; }
}

