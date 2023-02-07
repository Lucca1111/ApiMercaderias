using APImercaderias.Modelos;
using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/Productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosRepositorio _prRepo;
        private readonly IMapper _mapper;

        public ProductosController(IProductosRepositorio prRepo, IMapper mapper)
        {
            _prRepo = prRepo;
            _mapper = mapper;
        }

        
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProductosDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult AltaProducto([FromBody] ProductosDto ProductosDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ProductosDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_prRepo.ExisteProducto(ProductosDto.DescripcionProducto))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return StatusCode(404, ModelState);
            }

            var producto = _mapper.Map<Producto>(ProductosDto);
            if (!_prRepo.AltaProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el producto {producto.DescripcionProducto}");
                return StatusCode(404, ModelState);
            }
            return CreatedAtRoute("GetProductos", new { CodigoProducto = producto.CodigoProducto }, producto);
        }
        
        [HttpPatch("{CodigoProducto}", Name = "ModificarProducto")]
        [ProducesResponseType(201, Type = typeof(ModProductoDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult ModificacionProducto(string CodigoProducto, [FromBody] ModProductoDto ModProductoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ModProductoDto == null || CodigoProducto != ModProductoDto.DescripcionProducto)
            {
                return BadRequest(ModelState);
            }
            var producto = _mapper.Map<Producto>(ModProductoDto);
            if (!_prRepo.ModificacionProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{producto.DescripcionProducto}");
                return StatusCode(404, ModelState);
            }
            return NoContent();
        }
        
        [HttpDelete("{CodigoProducto}", Name = "BorrarProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult BajaProducto(string CodigoProducto, [FromBody] BajaProductoDto BajaProductoDto)
        {
            if (!_prRepo.ExisteProduct(CodigoProducto))
            {
                return NotFound();
            }

            var producto = _prRepo.GetProductos(CodigoProducto);

            if (!_prRepo.BajaProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro{producto.DescripcionProducto}");
                return StatusCode(500, ModelState);
            }
            return NoContent();


        }
    }
}
