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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Wine))]
        public async Task<ActionResult<Wine>> Post(Wine wine)
        {
            var result = await _wineRepository.Insert(wine);

            if (!result)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = wine.Id }, wine);
        }

        //GET: api/Wine
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Wine))]
        public async Task<ActionResult<IEnumerable<Wine>>> Get()
        {
            var result = await _wineRepository.GetAll();
            return Ok(result);
        }

        //GET: api/Wine/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Wine))]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Wine))]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Wine))]
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
