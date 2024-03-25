using Autofac.Extras.Moq;
using ValhallaVault.Data;
using ValhallaVault.Data.Models;

namespace ValhallaTest
{
    public class ValhallaMoqTest
    {
        [Fact]
        public void GetAllAnswersAsyncMoq()
        {
            using (var mock = AutoMock.GetLoose()) //med getLoose ser man om en metod har kallats??
            {
                mock.Mock<ProgramDbContext>()
                    .Setup(x => x.Answers)
                    .Returns(GetAllAnswers());
            }
        }
        private List<AnswerModel> GetAllAnswers()
        {


            List<AnswerModel> AllAnswers = new();
            {
                new AnswerModel
                {
                    Answer = "hej",
                    QuestionId = 1,
                    IsCorrect = true,
                },
                new AnswerModel
                {
                    Answer = "då",
                    QuestionId = 2,
                    IsCorrect = false,
                },
                new AnswerModel
                {
                    Answer = "mammut",
                    QuestionId = 1,
                    IsCorrect = false,
                },
                new AnswerModel
                {
                    Answer = "dino",
                    QuestionId = 1,
                    IsCorrect = true,
                };
            }
        }
    }
}
