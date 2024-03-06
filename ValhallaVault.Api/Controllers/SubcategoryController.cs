
﻿namespace ValhallaVault.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class SubcategoryController : ControllerBase
    //{
    //    private readonly SubcategoryRepoy _subcategoryRepo;

    //    public SubcategoryController(SubcategoryRepo<SubcategoryModel> subcategoryRepo)
    //    {
    //        _subcategoryRepo = subcategoryRepo;
    //    }

    //    [HttpGet]
    //    public async Task<IEnumerable<SubcategoryModel>> GetAll()
    //    {
    //        var subcategorys = await _subcategoryRepo.GetAllSubs();

    //        if (subcategorys != null)
    //        {
    //            return Ok(subcategorys);
    //        }

    //        return (IEnumerable<SubcategoryModel>)NotFound("The subcategories could not be found");
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var subcategory = await _subcategoryRepo.Find(a => a.Id == id);

    //        if (subcategory != null)
    //        {
    //            return Ok(subcategory);
    //        }

    //        return NotFound("The subcategory that you were looking for could not be found");
    //    }

    //    [HttpPost]
    //    public async Task<IActionResult> Post(SubcategoryModel subcategory)
    //    {

    //        if (subcategory != null)
    //        {
    //            await _subcategoryRepo.AddSub(subcategory);

    //            await _subcategoryRepo.Complete();

    //            return Ok(subcategory);
    //        }

    //        return NotFound("The subcategory that you were trying to post could not be found");
    //    }

    //    [HttpPut("{Id}")]
    //    public async Task<IActionResult> Put(SubcategoryModel previousSubcategory, int Id)
    //    {
    //        var result = await _subcategoryRepo.Get(previousSubcategory.Id);

    //        if (result != null)
    //        {
    //            result.Name = previousSubcategory.Name;

    //            await _subcategoryRepo.Complete();

    //            return Ok(result);
    //        }

    //        return NotFound("The subcategory that you wanted to update could not be found");
    //    }

    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var subcategory = await _subcategoryRepo.DeleteSub(id);

    //        if (subcategory != null)
    //        {
    //            return Ok(subcategory);
    //        }

    //        return NotFound("The subcategory that you wanted to delete could not be found");
    //    }

    //}
}
