using Exercicio1.Models; // Importa los modelos
using Exercicio1.Repositories; // Importa el repositorio
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ex01.Controllers
{
    [ApiController]
    [Route("api/piezas")]
    public class PiezaController : ControllerBase
    {
        private readonly IPiezaRepository _repository;

        public PiezaController(IPiezaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/piezas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pieza>>> GetPiezas()
        {
            var piezas = await _repository.GetAllAsync();
            return Ok(piezas);
        }

        // GET: api/piezas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pieza>> GetPieza(int id)
        {
            var pieza = await _repository.GetByIdAsync(id);

            if (pieza == null)
            {
                return NotFound();
            }

            return Ok(pieza);
        }

        // POST: api/piezas
        [HttpPost]
        public async Task<ActionResult<Pieza>> CreatePieza(Pieza pieza)
        {
            var createdPieza = await _repository.CreateAsync(pieza);
            return CreatedAtAction(nameof(GetPieza), new { id = createdPieza.Codigo }, createdPieza);
        }

        // PUT: api/piezas/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePieza(int id, Pieza pieza)
        {
            var updatedPieza = await _repository.UpdateAsync(id, pieza);

            if (updatedPieza == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/piezas/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePieza(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
