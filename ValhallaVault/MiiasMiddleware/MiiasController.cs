using Microsoft.AspNetCore.Mvc;

namespace ValhallaVault.MiiasMiddleware
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiiasController : ControllerBase
    {
        [HttpGet("kollaOmDetFungerar")]
        public Task<IActionResult> FunkarDetta()
        {
            throw new Exception("Hej alla barn!");
        }
    }
}
