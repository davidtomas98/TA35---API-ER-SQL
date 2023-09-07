using Exercicio3.Models;
using Exercicio3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio3.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoC : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoC(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<IEnumerable<Producto>> GetAll()
        {
            return await _productoRepository.GetAllAsync();
        }

        // Obtener producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null)
                return NotFound();

            return producto;
        }

        // Crear nuevo producto
        [HttpPost]
        public async Task<ActionResult<Producto>> Create(Producto producto)
        {
            var createdProducto = await _productoRepository.CreateAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = createdProducto.Codigo }, createdProducto);
        }

        // Actualizar producto por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto producto)
        {
            var updatedProducto = await _productoRepository.UpdateAsync(id, producto);
            if (updatedProducto == null)
                return NotFound();

            return NoContent();
        }

        // Eliminar producto por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productoRepository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
