//namespace ValhallaVault.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class QuestionController : ControllerBase
//    {

//        private readonly QuestionRepository _questionRepo;

//        public QuestionController(QuestionRepository<QuestionModel> questionRepo)
//        {
//            _questionRepo = questionRepo;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<QuestionModel>> GetAll()
//        {
//            var question = await _questionRepo.GetAll();

//            if (question != null)
//            {
//                return Ok(question);
//            }

//            return (IEnumerable<QuestionModel>)NotFound("The questions could not be found");
//        }


//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var question = await _questionRepo.Find(a => a.Id == id);

//            if (question != null)
//            {
//                return Ok(question);
//            }

//            return NotFound("The question that you were looking for could not be found");
//        }


//        [HttpPost]
//        public async Task<IActionResult> Post(QuestionModel question)
//        {

//            if (question != null)
//            {
//                await _questionRepo.Add(question);

//                await _questionRepo.Complete();

//                return Ok(question);
//            }

//            return NotFound("The question that you were trying to post could not be found");
//        }


//        [HttpPut("{Id}")]
//        public async Task<IActionResult> Put(QuestionModel previousQuestion, int Id)
//        {
//            var result = await _questionRepo.Get(previousQuestion.Id);

//            if (result != null)
//            {
//                result.Question = previousQuestion.Question;

//                await _questionRepo.Complete();

//                return Ok(result);
//            }

//            return NotFound("The question that you wanted to update could not be found");
//        }


//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var question = await _questionRepo.Delete(id);

//            if (question != null)
//            {
//                return Ok(question);
//            }

//            return NotFound("The question that you wanted to delete could not be found");
//        }

//    }
//}
