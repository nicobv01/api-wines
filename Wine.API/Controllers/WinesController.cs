using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly IWineRepository _wineRepository;
        public WineController(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        // POST: api/Wine
        [HttpPost]
        public async Task<ActionResult<Wine>> Post(Wine wine)
        {
            await _wineRepository.Insert(wine);
            return Ok(wine);
        }


    }
}
