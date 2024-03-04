using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValhallaVault.Data.Models;

public class Questions
{
    private static List<QuestionModel> DummyQuestions = new()
{
    new QuestionModel
    {
        Question = "What is the capital of Australia?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Canberra", IsCorrect = true },
            new AnswerModel { Answer = "Sydney", IsCorrect = false },
            new AnswerModel { Answer = "Melbourne", IsCorrect = false },
            new AnswerModel { Answer = "Perth", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "Which planet is known as the 'Red Planet'?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Mars", IsCorrect = true },
            new AnswerModel { Answer = "Venus", IsCorrect = false },
            new AnswerModel { Answer = "Mercury", IsCorrect = false },
            new AnswerModel { Answer = "Jupiter", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "Who is the author of 'To Kill a Mockingbird'?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Harper Lee", IsCorrect = true },
            new AnswerModel { Answer = "J.K. Rowling", IsCorrect = false },
            new AnswerModel { Answer = "Ernest Hemingway", IsCorrect = false },
            new AnswerModel { Answer = "George Orwell", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "What is the currency of Japan?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Yen", IsCorrect = true },
            new AnswerModel { Answer = "Won", IsCorrect = false },
            new AnswerModel { Answer = "Dollar", IsCorrect = false },
            new AnswerModel { Answer = "Euro", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "In which year did the Titanic sink?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "1912", IsCorrect = true },
            new AnswerModel { Answer = "1905", IsCorrect = false },
            new AnswerModel { Answer = "1925", IsCorrect = false },
            new AnswerModel { Answer = "1930", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "Who painted the Mona Lisa?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Leonardo da Vinci", IsCorrect = true },
            new AnswerModel { Answer = "Vincent van Gogh", IsCorrect = false },
            new AnswerModel { Answer = "Pablo Picasso", IsCorrect = false },
            new AnswerModel { Answer = "Claude Monet", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "What is the largest mammal on Earth?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Blue Whale", IsCorrect = true },
            new AnswerModel { Answer = "Elephant", IsCorrect = false },
            new AnswerModel { Answer = "Giraffe", IsCorrect = false },
            new AnswerModel { Answer = "Polar Bear", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "Which country is known as the 'Land of the Rising Sun'?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Japan", IsCorrect = true },
            new AnswerModel { Answer = "China", IsCorrect = false },
            new AnswerModel { Answer = "Korea", IsCorrect = false },
            new AnswerModel { Answer = "Vietnam", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "Who wrote 'The Great Gatsby'?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "F. Scott Fitzgerald", IsCorrect = true },
            new AnswerModel { Answer = "Hemingway", IsCorrect = false },
            new AnswerModel { Answer = "Jane Austen", IsCorrect = false },
            new AnswerModel { Answer = "Charles Dickens", IsCorrect = false }
        }
    },
    new QuestionModel
    {
        Question = "What is the world's largest ocean?",
        Answers = new List<AnswerModel>
        {
            new AnswerModel { Answer = "Pacific Ocean", IsCorrect = true },
            new AnswerModel { Answer = "Atlantic Ocean", IsCorrect = false },
            new AnswerModel { Answer = "Indian Ocean", IsCorrect = false },
            new AnswerModel { Answer = "Arctic Ocean", IsCorrect = false }
        }
    },
};
}

