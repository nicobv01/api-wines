using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;
        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        // POST: api/Wine
        [HttpPost]
        public async Task<ActionResult<Wine>> Post(Wine wine)
        {
            await _wineService.Insert(wine);
            return Ok(wine);
        }


    }
}
