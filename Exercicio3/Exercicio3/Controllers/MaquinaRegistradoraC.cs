using Exercicio3.Models;
using Exercicio3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ex03.Controllers
{
    [ApiController]
    [Route("api/maquinas-registradoras")]
    public class MaquinaRegistradoraController : ControllerBase
    {
        private readonly IMaquinaRegistradoraRepository _maquinaRegistradoraRepository;

        public MaquinaRegistradoraController(IMaquinaRegistradoraRepository maquinaRegistradoraRepository)
        {
            _maquinaRegistradoraRepository = maquinaRegistradoraRepository;
        }

        // Obtener todas las máquinas registradoras
        [HttpGet]
        public async Task<IEnumerable<MaquinaRegistradora>> GetAll()
        {
            return await _maquinaRegistradoraRepository.GetAllAsync();
        }

        // Obtener máquina registradora por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinaRegistradora>> GetById(int id)
        {
            var maquinaRegistradora = await _maquinaRegistradoraRepository.GetByIdAsync(id);
            if (maquinaRegistradora == null)
                return NotFound();

            return maquinaRegistradora;
        }

        // Crear nueva máquina registradora
        [HttpPost]
        public async Task<ActionResult<MaquinaRegistradora>> Create(MaquinaRegistradora maquinaRegistradora)
        {
            var createdMaquinaRegistradora = await _maquinaRegistradoraRepository.CreateAsync(maquinaRegistradora);
            return CreatedAtAction(nameof(GetById), new { id = createdMaquinaRegistradora.Codigo }, createdMaquinaRegistradora);
        }

        // Actualizar máquina registradora por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MaquinaRegistradora maquinaRegistradora)
        {
            var updatedMaquinaRegistradora = await _maquinaRegistradoraRepository.UpdateAsync(id, maquinaRegistradora);
            if (updatedMaquinaRegistradora == null)
                return NotFound();

            return NoContent();
        }

        // Eliminar máquina registradora por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _maquinaRegistradoraRepository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
