using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/ListadoProductos")]
    [ApiController]
    public class ListadoProductosController : ControllerBase
    {
        private readonly IProductosRepositorio _prRepo;
        private readonly IMapper _mapper;

        public ListadoProductosController(IProductosRepositorio prRepo, IMapper mapper)
        {

            _prRepo = prRepo;
            _mapper = mapper;
        }
        [HttpGet("GetFiltroPorCodigo/{CodigoProducto},{IdMarca:int},{IdFamilia:int}")]
        public IActionResult GetFiltroPorCodigo(string CodigoProducto, int IdMarca, int IdFamilia)
        {
            var listaProductos1 = _prRepo.GetFiltroPorCodigo(CodigoProducto, IdMarca, IdFamilia);
            if (listaProductos1 == null)
            {
                return NotFound();
            }
            var itemProducto1 = new List<ListadoProductosDto>();
            foreach (var lista1 in listaProductos1)
            {
                itemProducto1.Add(_mapper.Map<ListadoProductosDto>(lista1));
            }
            return Ok(itemProducto1);
        }
    }
}
