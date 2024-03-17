using System.Diagnostics;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;

namespace ValhallaVault.Data.DbServices
{
    public class UserQuestionService
    {
        private readonly IUserQuestionRepository _userQuestionRepository;
        private readonly ISegmentRepository _segmentRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;


        public UserQuestionService(ISubcategoryRepository subcategoryrepo, IUserQuestionRepository userQuestionRepository, ISegmentRepository segmentRepository, IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _userQuestionRepository = userQuestionRepository;
            _segmentRepository = segmentRepository;
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryrepo;
        }


        /// <summary>
        /// Returns a percentage of questions answer correctly by Category
        /// </summary>
        /// <returns></returns>
        public async Task<(int totalQuestions, int rightQuestions, double percentageComplete)> PercentageOfQuestionsAnswerdForCategoryId(int categoryId, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return (0, 0, 0); // Return default values if userId is null or empty

            // Find the category with the specified ID
            CategoryModel? category = await _categoryRepository.GetCategoryByIdWithEagerLoadingAsync(categoryId);

            if (category == null)
                return (0, 0, 0); // Return default values if category is not found

            // Calculate the total number of questions
            int totalQuestions = category.Segments?
                .SelectMany(segment => segment.Subcategories)
                .SelectMany(subcategory => subcategory.Questions)
                .Count() ?? 0;
            Debug.WriteLine("Questions counted");

            // Retrieve user questions from the repository
            var userQuestions = await _userQuestionRepository.GetAllUserQuestionsAsync();

            // Calculate the number of correct answers by the user
            int rightQuestions = userQuestions
                .Where(uq => uq.UserId == userId
                             && uq.IsCorrect == true
                             && category.Segments
                                 .SelectMany(segment => segment.Subcategories)
                                 .SelectMany(subcategory => subcategory.Questions)
                                 .Any(question => question.Id == uq.QuestionId))
                .Count();

            // Calculate the percentage of questions answered correctly
            double percentageComplete = totalQuestions == 0 ? 0 : (double)rightQuestions / totalQuestions * 100;

            return (totalQuestions, rightQuestions, percentageComplete);
        }


        public async Task<(int totalQuestions, int rightQuestions, double percentageComplete)> PercentageOfQuestionsAnsweredForSegmentId(int segmentId, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return (0, 0, 0); // Return default values if userId is null or empty

            // Find the segment with the specified ID
            SegmentModel? segment = await _segmentRepository.GetSegmentByIdWithEagerLoadingAsync(segmentId);

            if (segment == null)
                return (0, 0, 0); // Return default values if segment is not found

            // Calculate the total number of questions in the segment
            int totalQuestions = segment.Subcategories?
                .SelectMany(subcategory => subcategory.Questions)
                .Count() ?? 0;
            Debug.WriteLine("Questions in segment counted");

            // Retrieve user questions from the repository
            var userQuestions = await _userQuestionRepository.GetAllUserQuestionsAsync();

            // Calculate the number of correct answers by the user within the segment
            int rightQuestions = userQuestions
                .Where(uq => uq.UserId == userId
                             && uq.IsCorrect == true
                             && segment.Subcategories
                                 .SelectMany(subcategory => subcategory.Questions)
                                 .Any(question => question.Id == uq.QuestionId))
                .Count();
            Debug.WriteLine("Currect answers in segment counted");

            // Calculate the percentage of questions answered correctly within the segment
            double percentageComplete = totalQuestions == 0 ? 0 : (double)rightQuestions / totalQuestions * 100;

            return (totalQuestions, rightQuestions, percentageComplete);
        }

        public async Task<(int totalQuestions, int rightQuestions, double percentageComplete)> PercentageOfQuestionsAnsweredForSubcategoryId(int subcategoryId, string userId)
        {

            if (string.IsNullOrEmpty(userId)) return (0, 0, 0);

            SubcategoryModel? subcategory = await _subcategoryRepository.GetSubCategoryByIdIncludingThingsAsync(subcategoryId);

            if (subcategory == null) return (0, 0, 0);

            var userQuestions = await _userQuestionRepository.GetAllUserQuestionsAsync();

            int totalQuestions = subcategory.Questions?.Count ?? 0;

            int rightQuestions = userQuestions
                .Where(uq => uq.UserId == userId
                             && uq.IsCorrect == true
                             && subcategory.Questions.Any(q => q.Id == uq.QuestionId && q.SubcategoryId == subcategoryId))
                .Count();

            double percentageComplete = totalQuestions == 0 ? 0 : (double)rightQuestions / totalQuestions * 100;
            Debug.WriteLine("Calculation done");

            return (totalQuestions, rightQuestions, percentageComplete);
        }

    }
}
