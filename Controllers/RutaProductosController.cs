using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/RutaProductos")]
    [ApiController]
    public class RutaProductosController : ControllerBase
    {
        private readonly IProductosRepositorio _prRepo;
        private readonly IMapper _mapper;

        public RutaProductosController(IProductosRepositorio prRepo, IMapper mapper)
        {
            _prRepo = prRepo;
            _mapper = mapper;
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetProductos()
        {
            var listaProductos = _prRepo.GetProductos();
            var listaProductosDto = new List<ProductosDto>();

            foreach (var lista in listaProductos)
            {
                listaProductosDto.Add(_mapper.Map<ProductosDto>(lista));
            }
            return Ok(listaProductosDto);
        }

        
        [HttpGet("{CodigoProducto}", Name = "GetProductos")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetProductos(string CodigoProducto)
        {
            var ItemProducto = _prRepo.GetProductos(CodigoProducto);

            if (ItemProducto == null)
            {
                return NotFound();
            }
            var itemProductosDto = _mapper.Map<ProductosDto>(ItemProducto);
            return Ok(itemProductosDto);
        }
    }
}
