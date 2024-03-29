﻿using Microsoft.AspNetCore.Mvc;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;

namespace ValhallaVault.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly QuestionRepo _questionRepo;

        public QuestionController(QuestionRepo questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionModel>>> GetAll()
        {
            var question = await _questionRepo.GetAllQuestionsAsync();

            if (question != null)
            {
                return Ok(question);
            }

            return NotFound("The questions could not be found");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var question = await _questionRepo.GetQuestionByIdAsync(id);

            if (question != null)
            {
                return Ok(question);
            }

            return NotFound("The question that you were looking for could not be found");
        }


        [HttpPost]
        public async Task<IActionResult> Post(QuestionModel question)
        {

            if (question != null)
            {
                await _questionRepo.AddQuestionAsync(question);



                return Ok(question);
            }

            return NotFound("The question that you were trying to post could not be found");
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(QuestionModel previousQuestion, int Id)
        {
            var result = await _questionRepo.GetQuestionByIdAsync(previousQuestion.Id);

            if (result != null)
            {
                result.Question = previousQuestion.Question;

                return Ok(result);
            }

            return NotFound("The question that you wanted to update could not be found");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _questionRepo.DeleteQuestionAsync(id);

            if (question != null)
            {
                return Ok(question);
            }

            return NotFound("The question that you wanted to delete could not be found");
        }

    }
}
