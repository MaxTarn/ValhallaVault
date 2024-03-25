using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;


namespace ValhallaTest
{
    public class AnswerRepoTest
    {
        private readonly AnswerRepo _answerRepo;
        private readonly ProgramDbContext _dbContext;

        public AnswerRepoTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProgramDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContextVault;Trusted_Connection=True;MultipleActiveResultSets=true");

            _dbContext = new ProgramDbContext(optionsBuilder.Options);
            _answerRepo = new AnswerRepo(_dbContext);
        }

        [Fact]

        public async Task GetAllAnsersAsyncTest()
        {
            //Arrange
            var expectedAmountOfAnswers = 160;

            //Act
            var actualAnswers = await _answerRepo.GetAllAnswersAsync();
            var actualAmountOfAnswers = actualAnswers.Count();

            //Assert
            Assert.Equal(expectedAmountOfAnswers, actualAmountOfAnswers);
        }

        [Fact]
        public async Task GetAnswerByIdAsync_ReturnsCorrectAnswerTest()
        {
            // Arrange
            int findId = 1;
            var expectedAnswer = await _dbContext.Answers.FindAsync(findId);

            // Act
            var actualAnswer = await _answerRepo.GetAnswerByIdAsync(findId);

            // Assert
            Assert.NotNull(actualAnswer);
            Assert.Equal(expectedAnswer.Id, actualAnswer.Id);
            Assert.Equal(expectedAnswer.Answer, actualAnswer.Answer);
            //  Assert.NotNull(actualAnswer.Question); troligen onödig pga redan kollat ej null på hela
            Assert.Equal(expectedAnswer.Question, actualAnswer.Question);
        }

        [Fact]
        public async Task AddAnswerAsync_AddsAnswerToDatabaseTest()
        {
            // Arrange
            var addToThisQuestionId = 2;
            var addAnswer = new AnswerModel
            {
                Answer = "hello",
                IsCorrect = true,
                QuestionId = addToThisQuestionId
            };

            // Act
            await _answerRepo.AddAnswerAsync(addAnswer);

            // Assert
            var addedAnswer = await _dbContext.Answers.FindAsync(addAnswer.Id);
            Assert.NotNull(addedAnswer); // Kolla att svaret har lagts till
            Assert.Equal(addAnswer.Answer, addedAnswer.Answer);
            Assert.Equal(addAnswer.IsCorrect, addedAnswer.IsCorrect);
        }

        [Fact]
        public async Task UpdateAnswerAsyncTest()
        {
            //arrange
            var idOfAswerToUpdate = 2;

            //act

            //hämta det som ska uppdateras 
            var answerToUpdate = await _answerRepo.GetAnswerByIdAsync(idOfAswerToUpdate);

            if (answerToUpdate != null)
            {
                answerToUpdate.Answer = "Bye";
                answerToUpdate.IsCorrect = false;

                //skickar in det som ska uppdateras
                await _answerRepo.UpdateAnswerAsync(answerToUpdate);

                //assert
                //hämta hem det uppdaterade och kolla om det funkat
                var updatedAnswer = await _answerRepo.GetAnswerByIdAsync(idOfAswerToUpdate);

                Assert.NotNull(updatedAnswer);
                Assert.Equal("Bye", updatedAnswer.Answer);
                Assert.False(updatedAnswer.IsCorrect);
            }
            else
            {
                Assert.False(true, $"Could not find answer with ID {idOfAswerToUpdate}");
            }
        }

        [Fact]
        public async Task DeleteAnswerAsyncExceptionTest()
        {
            int notAnExcistingId = 2999;

            var exception = await Assert.ThrowsAsync<Exception>(async () => await _answerRepo.DeleteAnswerAsync(notAnExcistingId));
            Assert.Equal("No answer found with the specified ID.", exception.Message);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public async Task DeleteAnswerAsyncNullTest(int idToDelete)
        {
            // Act
            var deletedAnswer = await _answerRepo.DeleteAnswerAsync(idToDelete);

            // Assert
            //jag förväntar mig null och att inget raderas
            Assert.Null(deletedAnswer);
        }

        [Fact]
        public async Task DeleteAnswerAsyncTest()
        {
            //arrange
            var idToDelete = 1;

            //act
            var deletedAnswer = await _answerRepo.DeleteAnswerAsync(idToDelete);

            //assert
            Assert.NotNull(deletedAnswer); // den är inte null- vilket innbär att den existerar i databasen
            Assert.Equal(idToDelete, deletedAnswer.Id);

            var answerNotFound = await _dbContext.Answers.FindAsync(idToDelete);
            Assert.Null(answerNotFound); // nu är det null för den har tagits bort
        }
    }
}


