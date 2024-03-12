// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;

namespace ValhallaVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {

        private readonly AnswerRepo _answerRepo;

        public AnswerController(AnswerRepo answerRepo)
        {
            _answerRepo = answerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerModel>>> GetAll()
        {
            var answers = await _answerRepo.GetAllAnswersAsync();

            if (answers != null)
            {
                return Ok(answers);
            }

            return NotFound("The answers could not be found");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var answer = await _answerRepo.GetAnswerByIdAsync(id);

            if (answer != null)
            {
                return Ok(answer);
            }

            return NotFound("The answer that you were looking for could not be found");
        }


        [HttpPost]
        public async Task<IActionResult> Post(AnswerModel answer)
        {

            if (answer != null)
            {
                await _answerRepo.AddAnswerAsync(answer);

                await _answerRepo.SaveAsync();

                return Ok(answer);
            }

            return NotFound("The answer that you were trying to post could not be found");
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(AnswerModel previousAnswer, int Id)
        {
            var result = await _answerRepo.GetAnswerByIdAsync(previousAnswer.Id);

            if (result != null)
            {
                result.Answer = previousAnswer.Answer;
                result.IsCorrect = previousAnswer.IsCorrect;

                await _answerRepo.SaveAsync();

                return Ok(result);
            }

            return NotFound("The answer that you wanted to update could not be found");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var answer = await _answerRepo.DeleteAnswerAsync(id);

            if (answer != null)
            {
                return Ok(answer);
            }

            return NotFound("The answer that you wanted to delete could not be found");
        }
    }
}
