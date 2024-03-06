

﻿// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ValhallaVault.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AnswerController : ControllerBase
    //{

    //    private readonly AnswerRepo _answerRepo;

    //    public AnswerController(AnswerRepo<AnswerModel> answerRepo)
    //    {
    //        _answerRepo = answerRepo;
    //    }

    //    [HttpGet]
    //    public async Task<IEnumerable<AnswerModel>> GetAll()
    //    {
    //        var answers = await _answerRepo.GetAllAnswers();

    //        if (answers != null)
    //        {
    //            return Ok(answers);
    //        }

    //        return (IEnumerable<AnswerModel>)NotFound("The answers could not be found");
    //    }


    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var answer = await _answerRepo.Find(a => a.Id == id);

    //        if (answer != null)
    //        {
    //            return Ok(answer);
    //        }

    //        return NotFound("The answer that you were looking for could not be found");
    //    }


    //    [HttpPost]
    //    public async Task<IActionResult> Post(AnswerModel answer)
    //    {

    //        if (answer != null)
    //        {
    //            await _answerRepo.AddAnswer(answer);

    //            await _answerRepo.Complete();

    //            return Ok(answer);
    //        }

    //        return NotFound("The answer that you were trying to post could not be found");
    //    }


    //    [HttpPut("{Id}")]
    //    public async Task<IActionResult> Put(AnswerModel previousAnswer, int Id)
    //    {
    //        var result = await _answerRepo.Get(previousAnswer.Id);

    //        if (result != null)
    //        {
    //            result.Answer = previousAnswer.Answer;
    //            result.IsCorrect = previousAnswer.IsCorrect;

    //            await _answerRepo.Complete();

    //            return Ok(result);
    //        }

    //        return NotFound("The answer that you wanted to update could not be found");
    //    }


    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var answer = await _answerRepo.DeleteAnswer(id);

    //        if (answer != null)
    //        {
    //            return Ok(answer);
    //        }

    //        return NotFound("The answer that you wanted to delete could not be found");
    //    }
    //    }
}

