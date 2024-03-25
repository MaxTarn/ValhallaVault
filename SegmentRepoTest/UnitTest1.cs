using Microsoft.EntityFrameworkCore;
using ValhallaVault.Data;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;

namespace SegmentRepoTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllSegmentsTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProgramDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ProgramDbContext(dbContextOptions))
            {
                var segmentRepo = new SegmentRepo(dbContext);
                var segments = new List<SegmentModel>
                    {
                        new SegmentModel { Id = 1, Name = "Segment 1" },
                        new SegmentModel { Id = 2, Name = "Segment 2" },
                        new SegmentModel { Id = 3, Name = "Segment 3" }
                    };
                dbContext.Segments.AddRange(segments);
                await dbContext.SaveChangesAsync();

                // Act
                var result = await segmentRepo.GetAllSegmentsAsync();

                // Assert
                Assert.Equal(segments.Count, result.Count());
                Assert.Equal(segments.Select(s => s.Id), result.Select(r => r.Id));
                Assert.Equal(segments.Select(s => s.Name), result.Select(r => r.Name));
            }
        }

        [Fact]
        public async Task GetSegmentByIdTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProgramDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ProgramDbContext(dbContextOptions))
            {
                var segmentRepo = new SegmentRepo(dbContext);
                var segment = new SegmentModel { Id = 1, Name = "Segment 1" };
                dbContext.Segments.Add(segment);
                await dbContext.SaveChangesAsync();

                // Act
                var result = await segmentRepo.GetSegmentByIdAsync(segment.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(segment.Id, result.Id);
                Assert.Equal(segment.Name, result.Name);
            }
        }

        [Fact]
        public async Task GetSegmentByIdWithEagerLoadingTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProgramDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ProgramDbContext(dbContextOptions))
            {
                var segmentRepo = new SegmentRepo(dbContext);
                var segment = new SegmentModel { Id = 1, Name = "Segment 1" };
                var subcategory = new SubcategoryModel { Id = 1, Name = "Subcategory 1" };
                var question = new QuestionModel { Id = 1, Explanation = "Question 1" };

                segment.Subcategories = new List<SubcategoryModel> { subcategory };
                subcategory.Questions = new List<QuestionModel> { question };

                dbContext.Segments.Add(segment);
                await dbContext.SaveChangesAsync();

                // Act
                var result = await segmentRepo.GetSegmentByIdWithEagerLoadingAsync(segment.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(segment.Id, result.Id);
                Assert.Equal(segment.Name, result.Name);
                Assert.Single(result.Subcategories);
                Assert.Single(result.Subcategories[0].Questions);
                Assert.Equal(subcategory.Id, result.Subcategories[0].Id);
                Assert.Equal(subcategory.Name, result.Subcategories[0].Name);
                Assert.Equal(question.Id, result.Subcategories[0].Questions[0].Id);
                Assert.Equal(question.Explanation, result.Subcategories[0].Questions[0].Explanation);
            }
        }

        [Fact]
        public async Task AddSegmentAsyncTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProgramDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ProgramDbContext(dbContextOptions))
            {
                var segmentRepo = new SegmentRepo(dbContext);
                var segment = new SegmentModel { Id = 1, Name = "Segment 1" };

                // Act
                await segmentRepo.AddSegmentAsync(segment);

                // Assert
                var result = await dbContext.Segments.FindAsync(segment.Id);
                Assert.NotNull(result);
                Assert.Equal(segment.Id, result.Id);
                Assert.Equal(segment.Name, result.Name);
            }
        }

        [Fact]
        public async Task UpdateSegmentAsyncTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProgramDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ProgramDbContext(dbContextOptions))
            {
                var segmentRepo = new SegmentRepo(dbContext);
                var segment = new SegmentModel { Id = 1, Name = "Segment 1" };
                dbContext.Segments.Add(segment);
                await dbContext.SaveChangesAsync();

                // Act
                segment.Name = "Updated Segment";
                segmentRepo.UpdateSegmentAsync(segment);

                // Assert
                var result = await dbContext.Segments.FindAsync(segment.Id);
                Assert.NotNull(result);
                Assert.Equal(segment.Id, result.Id);
                Assert.Equal(segment.Name, result.Name);
            }
        }

        [Fact]
        public async Task DeleteSegmentAsyncTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ProgramDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ProgramDbContext(dbContextOptions))
            {
                var segmentRepo = new SegmentRepo(dbContext);
                var segment = new SegmentModel { Id = 1, Name = "Segment 1" };
                dbContext.Segments.Add(segment);
                await dbContext.SaveChangesAsync();

                // Act
                var deletedSegment = await segmentRepo.DeleteSegmentAsync(segment.Id);

                // Assert
                Assert.NotNull(deletedSegment);
                Assert.Equal(segment.Id, deletedSegment.Id);
                Assert.Equal(segment.Name, deletedSegment.Name);

                var result = await dbContext.Segments.FindAsync(segment.Id);
                Assert.Null(result);
            }
        }

    }
}