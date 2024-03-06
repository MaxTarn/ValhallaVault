
﻿namespace ValhallaVault.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class SegmentController : ControllerBase
    //{
    //    private readonly SegmentRepo _segmentRepo;

    //    public SegmentController(SegmentRepo<SegmentModel> segmentRepo)
    //    {
    //        _segmentRepo = segmentRepo;
    //    }

    //    [HttpGet]
    //    public async Task<IEnumerable<AnswerModel>> GetAll()
    //    {
    //        var segment = await _segmentRepo.GetAllSegments();

    //        if (segment != null)
    //        {
    //            return Ok(segment);
    //        }

    //        return (IEnumerable<AnswerModel>)NotFound("The segments could not be found");
    //    }



    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var segment = await _segmentRepo.Find(a => a.Id == id);

    //        if (segment != null)
    //        {
    //            return Ok(segment);
    //        }

    //        return NotFound("The segment that you were looking for could not be found");
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Post(SegmentModel segment)
    //    {

    //        if (segment != null)
    //        {
    //            await _segmentRepo.AddSegment(segment);

    //            await _segmentRepo.Complete();

    //            return Ok(segment);
    //        }

    //        return NotFound("The segment that you were trying to post could not be found");
    //    }

    //    [HttpPut("{Id}")]
    //    public async Task<IActionResult> Put(SegmentModel previousSegment, int Id)
    //    {
    //        var result = await _segmentRepo.Get(previousSegment.Id);

    //        if (result != null)
    //        {
    //            result.Name = previousSegment.Name;

    //            await _segmentRepo.Complete();

    //            return Ok(result);
    //        }

    //        return NotFound("The segment that you wanted to update could not be found");
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var segment = await _segmentRepo.DeleteQuestion(id);

    //        if (segment != null)
    //        {
    //            return Ok(segment);
    //        }

    //        return NotFound("The segment that you wanted to delete could not be found");


    //    }
    //}
}

