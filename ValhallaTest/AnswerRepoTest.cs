using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data;
using ValhallaVault.Data.Repositories;


namespace ValhallaTest
{

    //public async Task<IEnumerable<AnswerModel>> GetAllAnswersAsync()
    //{
    //    return await _dbContext.Answers.ToListAsync();
    //}
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
            var expectedAmountOfAnswers = 159;

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
        }



    }

}
