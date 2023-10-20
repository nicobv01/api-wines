using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WinesController : ControllerBase
    {
        private readonly IWineRepository _wineRepository;
        public WinesController(IWineRepository wineRepository)
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

        //GET: api/Wine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wine>>> Get()
        {
            return Ok(await _wineRepository.GetAll());
        }

        //GET: api/Wine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wine>> GetById(int id)
        {
            var wine = await _wineRepository.GetById(id);
            return Ok(wine);
        }

        //PUT: api/Wine/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Wine>> Put(int id, Wine wine)
        {
            if (id != wine.Id)
            {
                return BadRequest();
            }

            var updatedWine = await _wineRepository.Update(wine);
            return Ok(updatedWine);
        }


    }
}
