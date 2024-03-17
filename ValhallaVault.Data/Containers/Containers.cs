using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Containers;

public class AnswerContainer
{
    public bool IsChecked { get; set; }
    public AnswerModel Original { get; set; }
    public bool ShowStyle { get; set; } // New property for controlling when to show correct answer

    public string Style => GetAnswerStyle();

    private string GetAnswerStyle()
    {
        if (ShowStyle == false) return "";

        if (Original.IsCorrect == true)
        {
            return "background-color:green;";
        }
        else if (IsChecked)
        {
            return "background-color:red;";
        }

        return "";
    }
}

public class QuestionContainer
{
    public string Question { get; set; }
    public List<AnswerContainer> Answers { get; set; }
    public QuestionModel Original { get; set; }
}

public class SubCategoryContainer
{
    public SubcategoryModel Original { get; set; }
    public List<QuestionContainer> Questions { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectQuestions { get; set; }
    public double PercentageComplete { get; set; }
}

public class CategoryContainer
{
    public CategoryModel Original { get; set; }
    public double PercentageCompleted { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectQuestions { get; set; }

}

public class SegmentContainer
{
    public SegmentModel Original { get; set; }
    public List<SubCategoryContainer> SubCategoryContainers { get; set; }
    public int TotalQuestions { get; set; }
    public int CorrectQuestions { get; set; }
    public double PercentageComplete { get; set; }
}

