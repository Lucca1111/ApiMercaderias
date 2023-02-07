using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/RutaMarcas")]
    [ApiController]
    public class RutaMarcasController : ControllerBase
    {
        private readonly IMarcaRepositorio _maRepo;
        private readonly IMapper _mapper;

        public RutaMarcasController(IMarcaRepositorio maRepo, IMapper mapper)
        {
            _maRepo = maRepo;
            _mapper = mapper;
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetMarca()
        {
            var listaMarcas = _maRepo.GetMarca();
            var listaaltaMarcaDto = new List<AltaMarcaDto>();

            foreach (var lista in listaMarcas)
            {
                listaaltaMarcaDto.Add(_mapper.Map<AltaMarcaDto>(lista));
            }

            return Ok(listaaltaMarcaDto);
        }
        
        [HttpGet("{IdMarca:int}", Name = "GetMarca")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMarca(int IdMarca)
        {
            var itemMarca = _maRepo.GetMarca(IdMarca);

            if (itemMarca == null)
            {
                return NotFound();
            }

            var itemaltaMarcaDto = _mapper.Map<AltaMarcaDto>(itemMarca);

            return Ok(itemaltaMarcaDto);
        }
    }
}
