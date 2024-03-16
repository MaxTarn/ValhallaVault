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


        public UserQuestionService(IUserQuestionRepository userQuestionRepository, ISegmentRepository segmentRepository, IQuestionRepository questionRepository, ICategoryRepository categoryRepository)
        {
            _userQuestionRepository = userQuestionRepository;
            _segmentRepository = segmentRepository;
            _questionRepository = questionRepository;
            _categoryRepository = categoryRepository;
        }


        /// <summary>
        /// Returns a percentage of questions answer correctly by Category
        /// </summary>
        /// <returns></returns>
        public async Task<double?> PercentageOfQuestionsAnswerdForCategoryId(int categoryId, string userId)
        {
            // Get all categories
            List<CategoryModel> categories = (await _categoryRepository.GetAllCategoriesAsync()).ToList();

            // Find the category with the specified ID
            CategoryModel? category = categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return null;
            }

            // Get all questions within the category
            IEnumerable<QuestionModel> categoryQuestions = category?.Segments?.SelectMany(s => s.Subcategories.SelectMany(sc => sc.Questions));

            // Get all user questions
            IEnumerable<UserQuestionModel> userQuestions = await _userQuestionRepository.GetAllUserQuestionsAsync();

            // Filter user questions by category questions
            IEnumerable<UserQuestionModel> userCategoryQuestions = userQuestions.Where(uq => categoryQuestions.Any(q => q.Id == uq.QuestionId));

            // If no questions are answered for the category, return 0
            if (!userCategoryQuestions.Any())
            {
                return 0;
            }

            // Count the number of correctly answered questions
            int correctCount = userCategoryQuestions.Count(uq => uq.IsCorrect == true);

            // Calculate the percentage of correctly answered questions
            double percentage = (double)correctCount / userCategoryQuestions.Count() * 100;

            return percentage;
        }
    }
}
