using Exercicio3.Models;
using Exercicio3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio3.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class VentaC : ControllerBase
    {
        private readonly IVentaRepository _ventaRepository;

        public VentaC(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        // Obtener todas las ventas
        [HttpGet]
        public async Task<IEnumerable<Venta>> GetAll()
        {
            return await _ventaRepository.GetAllAsync();
        }

        // Obtener venta por cajero, producto y máquina
        [HttpGet("{cajeroCodigo}/{productoCodigo}/{maquinaCodigo}")]
        public async Task<ActionResult<Venta>> GetById(int cajeroCodigo, int productoCodigo, int maquinaCodigo)
        {
            var venta = await _ventaRepository.GetByIdAsync(cajeroCodigo, productoCodigo, maquinaCodigo);
            if (venta == null)
                return NotFound();

            return venta;
        }

        // Crear nueva venta
        [HttpPost]
        public async Task<ActionResult<Venta>> Create(Venta venta)
        {
            var createdVenta = await _ventaRepository.CreateAsync(venta);
            return CreatedAtAction(nameof(GetById), new { cajeroCodigo = venta.CajeroCodigo, productoCodigo = venta.ProductoCodigo, maquinaCodigo = venta.MaquinaCodigo }, createdVenta);
        }

        // Actualizar venta por cajero, producto y máquina
        [HttpPut("{cajeroCodigo}/{productoCodigo}/{maquinaCodigo}")]
        public async Task<IActionResult> Update(int cajeroCodigo, int productoCodigo, int maquinaCodigo, Venta venta)
        {
            if (cajeroCodigo != venta.CajeroCodigo || productoCodigo != venta.ProductoCodigo || maquinaCodigo != venta.MaquinaCodigo)
                return BadRequest();

            var updatedVenta = await _ventaRepository.UpdateAsync(venta);
            if (updatedVenta == null)
                return NotFound();

            return NoContent();
        }

        // Eliminar venta por cajero, producto y máquina
        [HttpDelete("{cajeroCodigo}/{productoCodigo}/{maquinaCodigo}")]
        public async Task<IActionResult> Delete(int cajeroCodigo, int productoCodigo, int maquinaCodigo)
        {
            var result = await _ventaRepository.DeleteAsync(cajeroCodigo, productoCodigo, maquinaCodigo);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // Buscar ventas por cajero, producto y/o máquina
        [HttpGet("search")]
        public async Task<IEnumerable<Venta>> Search(int? cajeroCodigo, int? productoCodigo, int? maquinaCodigo)
        {
            return await _ventaRepository.SearchAsync(cajeroCodigo, productoCodigo, maquinaCodigo);
        }
    }
}
