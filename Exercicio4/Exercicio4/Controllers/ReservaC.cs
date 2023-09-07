using Exercicio4.Models;
using Exercicio4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio4.Controllers
{
    // Define la ruta base para todas las rutas de este controlador
    [Route("api/reservas")]
    [ApiController]
    public class ReservaC : ControllerBase
    {
        private readonly IReservaRepository _repository;

        // Inyecta la dependencia del repositorio en el constructor
        public ReservaC(IReservaRepository repository)
        {
            _repository = repository;
        }

        // Endpoint para obtener todas las reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservas()
        {
            var reservas = await _repository.GetAllAsync();
            return Ok(reservas); // Devuelve una respuesta HTTP 200 OK con las reservas
        }

        // Endpoint para obtener una reserva por el DNI del investigador y el número de serie del equipo
        [HttpGet("{dni}/{numSerie}")]
        public async Task<ActionResult<Reserva>> GetReserva(string dni, string numSerie)
        {
            var reserva = await _repository.GetByDNIAndNumSerieAsync(dni, numSerie);

            if (reserva == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si la reserva no existe
            }

            return Ok(reserva); // Devuelve una respuesta HTTP 200 OK con la reserva encontrada
        }

        // Endpoint para crear una nueva reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            var createdReserva = await _repository.CreateAsync(reserva);
            return CreatedAtAction(nameof(GetReserva), new { dni = createdReserva.DNI, numSerie = createdReserva.NumSerie }, createdReserva);
            // Devuelve una respuesta HTTP 201 Created con la reserva creada y una URL para obtenerla
        }

        // Endpoint para actualizar una reserva existente
        [HttpPut("{dni}/{numSerie}")]
        public async Task<IActionResult> PutReserva(string dni, string numSerie, Reserva reserva)
        {
            if (dni != reserva.DNI || numSerie != reserva.NumSerie)
            {
                return BadRequest(); // Devuelve una respuesta HTTP 400 Bad Request si los DNI o números de serie no coinciden
            }

            var updatedReserva = await _repository.UpdateAsync(dni, numSerie, reserva);

            if (updatedReserva == null)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si la reserva no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la actualización fue exitosa
        }

        // Endpoint para eliminar una reserva por el DNI del investigador y el número de serie del equipo
        [HttpDelete("{dni}/{numSerie}")]
        public async Task<IActionResult> DeleteReserva(string dni, string numSerie)
        {
            var deleted = await _repository.DeleteAsync(dni, numSerie);

            if (!deleted)
            {
                return NotFound(); // Devuelve una respuesta HTTP 404 Not Found si la reserva no existe
            }

            return NoContent(); // Devuelve una respuesta HTTP 204 No Content si la eliminación fue exitosa
        }
    }
}
