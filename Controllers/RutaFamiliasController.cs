using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/RutaFamilia")]
    [ApiController]
    public class RutaFamiliasController : ControllerBase
    {
        private readonly IFamiliaRepositorio _faRepo;
        private readonly IMapper _mapper;

        public RutaFamiliasController(IFamiliaRepositorio faRepo, IMapper mapper)
        {
            _faRepo = faRepo;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetFamilia()
        {
            var listaFamilias = _faRepo.GetFamilia();
            var listaFamiliaDto = new List<FamiliaDto>();

            foreach (var lista in listaFamilias)
            {
                listaFamiliaDto.Add(_mapper.Map<FamiliaDto>(lista));
            }

            return Ok(listaFamiliaDto);
        }
        
        [HttpGet("{IdFamilia:int}", Name = "GetFamilia")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetFamilia(int IdFamilia)
        {
            var itemFamilia = _faRepo.GetFamilia(IdFamilia);

            if (itemFamilia == null)
            {
                return NotFound();
            }

            var itemFamiliaDto = _mapper.Map<FamiliaDto>(itemFamilia);

            return Ok(itemFamiliaDto);
        }
    }
}
