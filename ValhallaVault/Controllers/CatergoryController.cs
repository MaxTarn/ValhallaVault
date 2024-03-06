using Microsoft.AspNetCore.Mvc;
using ValhallaVault.Data.Models;
using ValhallaVault.Data.Repositories;

namespace ValhallaVault.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatergoryController : ControllerBase
    {
        private readonly CategoryRepo _catergoryRepo;

        public CatergoryController(CategoryRepo catergoryRepo)
        {
            _catergoryRepo = catergoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetAll()
        {
            var categories = await _catergoryRepo.GetAllCategories();

            if (categories != null)
            {
                return Ok(categories);
            }

            return NotFound("The categories could not be found");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _catergoryRepo.GetCategoryById(id);

            if (category != null)
            {
                return Ok(category);
            }

            return NotFound("The category that you were looking for could not be found");
        }


        [HttpPost]
        public async Task<IActionResult> Post(CategoryModel category)
        {

            if (category != null)
            {
                await _catergoryRepo.AddCategory(category);

                await _catergoryRepo.Complete();

                return Ok(category);
            }

            return NotFound("The category that you were trying to post could not be found");
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(CategoryModel previousCategory, int Id)
        {
            var result = await _catergoryRepo.GetCategoryById(previousCategory.Id);

            if (result != null)
            {
                result.Name = previousCategory.Name;


                await _catergoryRepo.Complete();

                return Ok(result);
            }


            return NotFound("The category that you wanted to update could not be found");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _catergoryRepo.DeleteCategory(id);

            if (category != null)
            {
                return Ok(category);
            }

            return NotFound("The category that you wanted to delete could not be found");
        }

    }
}
