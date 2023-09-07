using Exercicio1.Models; // Importa los modelos
using Exercicio1.Repositories; // Importa el repositorio
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercicio1.Controllers
{
    [ApiController]
    [Route("api/suministra")]
    public class SuministraController : ControllerBase
    {
        private readonly ISuministraRepository _repository;

        public SuministraController(ISuministraRepository repository)
        {
            _repository = repository;
        }

        // GET: api/suministra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suministra>>> GetSuministros()
        {
            var suministros = await _repository.GetAllAsync();
            return Ok(suministros);
        }

        // GET: api/suministra/{codigoPieza}/{idProveedor}
        [HttpGet("{codigoPieza}/{idProveedor}")]
        public async Task<ActionResult<Suministra>> GetSuministra(int codigoPieza, string idProveedor)
        {
            var suministra = await _repository.GetByCodigoPiezaIdProveedorAsync(codigoPieza, idProveedor);

            if (suministra == null)
            {
                return NotFound();
            }

            return Ok(suministra);
        }

        // POST: api/suministra
        [HttpPost]
        public async Task<ActionResult<Suministra>> CreateSuministra(Suministra suministra)
        {
            var createdSuministra = await _repository.CreateAsync(suministra);
            return CreatedAtAction(nameof(GetSuministra), new { codigoPieza = createdSuministra.CodigoPieza, idProveedor = createdSuministra.IdProveedor }, createdSuministra);
        }

        // PUT: api/suministra/{codigoPieza}/{idProveedor}
        [HttpPut("{codigoPieza}/{idProveedor}")]
        public async Task<IActionResult> UpdateSuministra(int codigoPieza, string idProveedor, Suministra suministra)
        {
            var updatedSuministra = await _repository.UpdateAsync(codigoPieza, idProveedor, suministra);

            if (updatedSuministra == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/suministra/{codigoPieza}/{idProveedor}
        [HttpDelete("{codigoPieza}/{idProveedor}")]
        public async Task<IActionResult> DeleteSuministra(int codigoPieza, string idProveedor)
        {
            var deleted = await _repository.DeleteAsync(codigoPieza, idProveedor);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
