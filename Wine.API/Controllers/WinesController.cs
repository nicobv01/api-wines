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
            var result = await _wineRepository.Insert(wine);

            if (!result)
            {
                return BadRequest();
            }

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

            if (wine == null)
            {
                return NotFound();
            }

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

            if (!updatedWine)
            {
                return NotFound();
            }

            return Ok(updatedWine);
        }

        //DELETE: api/Wine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _wineRepository.DeleteById(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }


    }
}
