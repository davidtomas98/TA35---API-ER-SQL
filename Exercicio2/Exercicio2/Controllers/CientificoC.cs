using Microsoft.AspNetCore.Mvc;
using Exercicio2.Repositories;
using Exercicio2.Models;

namespace Exercicio2.Controllers
{
    [ApiController]
    [Route("api/cientificos")]
    public class CientificoC : ControllerBase
    {
        private readonly ICientificoRepository _cientificoRepository;

        public CientificoC(ICientificoRepository cientificoRepository)
        {
            _cientificoRepository = cientificoRepository;
        }

        // Obtiene una lista de todos los científicos
        [HttpGet]
        public async Task<IEnumerable<Cientifico>> GetAll()
        {
            return await _cientificoRepository.GetAllAsync();
        }

        // Obtiene un científico por su DNI
        [HttpGet("{dni}")]
        public async Task<ActionResult<Cientifico>> GetByDni(string dni)
        {
            var cientifico = await _cientificoRepository.GetByDniAsync(dni);
            if (cientifico == null)
            {
                return NotFound(); // Si el científico no se encuentra, devuelve un error NotFound
            }
            return cientifico;
        }

        // Crea un nuevo científico y devuelve el resultado de la creación
        [HttpPost]
        public async Task<ActionResult<Cientifico>> Create(Cientifico cientifico)
        {
            await _cientificoRepository.CreateAsync(cientifico);

            // Devuelve una respuesta con el estado 201 Created y la ubicación del nuevo científico
            return CreatedAtAction(nameof(GetByDni), new { dni = cientifico.Dni }, cientifico);
        }

        // Actualiza un científico existente por su DNI
        [HttpPut("{dni}")]
        public async Task<IActionResult> Update(string dni, Cientifico cientifico)
        {
            if (dni != cientifico.Dni)
            {
                return BadRequest(); // Si el DNI en la URL no coincide con el DNI en el objeto, devuelve un error BadRequest
            }

            await _cientificoRepository.UpdateAsync(cientifico);
            return NoContent(); // Devuelve un resultado sin contenido si la actualización es exitosa
        }

        // Elimina un científico por su DNI
        [HttpDelete("{dni}")]
        public async Task<IActionResult> Delete(string dni)
        {
            var cientifico = await _cientificoRepository.GetByDniAsync(dni);
            if (cientifico == null)
            {
                return NotFound(); // Si el científico no se encuentra, devuelve un error NotFound
            }

            await _cientificoRepository.DeleteAsync(dni);
            return NoContent(); // Devuelve un resultado sin contenido si la eliminación es exitosa
        }
    }
}
