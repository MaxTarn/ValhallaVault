using Microsoft.AspNetCore.Mvc;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;

namespace ValhallaVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private readonly SegmentRepo _segmentRepo;

        public SegmentController(SegmentRepo segmentRepo)
        {
            _segmentRepo = segmentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerModel>>> GetAll()
        {
            var segment = await _segmentRepo.GetAllSegmentsAsync();

            if (segment != null)
            {
                return Ok(segment);
            }

            return NotFound("The segments could not be found");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var segment = await _segmentRepo.GetSegmentByIdAsync(id);

            if (segment != null)
            {
                return Ok(segment);
            }

            return NotFound("The segment that you were looking for could not be found");
        }


        [HttpPost]
        public async Task<IActionResult> Post(SegmentModel segment)
        {

            if (segment != null)
            {
                await _segmentRepo.AddSegmentAsync(segment);

                await _segmentRepo.SaveAsync();

                return Ok(segment);
            }

            return NotFound("The segment that you were trying to post could not be found");
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(SegmentModel previousSegment, int Id)
        {
            var result = await _segmentRepo.GetSegmentByIdAsync(previousSegment.Id);

            if (result != null)
            {
                result.Name = previousSegment.Name;

                await _segmentRepo.SaveAsync();

                return Ok(result);
            }

            return NotFound("The segment that you wanted to update could not be found");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var segment = await _segmentRepo.DeleteSegmentAsync(id);

            if (segment != null)
            {
                return Ok(segment);
            }

            return NotFound("The segment that you wanted to delete could not be found");


        }
    }
}
