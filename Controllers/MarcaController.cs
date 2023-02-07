using APImercaderias.Modelos;
using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/Marcas")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepositorio _maRepo;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaRepositorio maRepo, IMapper mapper)
        {
            _maRepo = maRepo;
            _mapper = mapper;
        }

       
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(AltaMarcaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult AltaMarca([FromBody] AltaMarcaDto altaMarcaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (altaMarcaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_maRepo.ExisteMarca(altaMarcaDto.Descripcion))
            {
                ModelState.AddModelError("", "La marca ya existe");
                return StatusCode(404, ModelState);
            }

            var marca = _mapper.Map<Marca>(altaMarcaDto);
            if (!_maRepo.AltaMarca(marca))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando la marca{marca.Descripcion}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetMarca", new { IdMarca = marca.Id }, marca);
        }
        
        [HttpPatch("{IdMarca:int}", Name = "ModificacionMarca")]
        [ProducesResponseType(201, Type = typeof(AltaMarcaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ModificacionMarca([FromBody] AltaMarcaDto altamarcaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (altamarcaDto == null)
            {
                return BadRequest(ModelState);
            }

            var marca = _mapper.Map<Marca>(altamarcaDto);

            if (!_maRepo.ModificacionMarca(marca))
            {
                ModelState.AddModelError("", $"Algo salio mal modificando la marca{marca.Descripcion}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        
        [HttpDelete("{IdMarca:int}", Name = "BajaMarca")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]



        public IActionResult BajaMarca(int IdMarca,[FromBody] BajaMarcaDto BajaMarcaDto)
        {
            if (!_maRepo.ExisteMarca(IdMarca))
            {
                return NotFound();
            }

            var marca = _maRepo.GetMarca(IdMarca);

            if (!_maRepo.BajaMarca(marca))
            {
                ModelState.AddModelError("", $"No se puede dar de baja la marca ya que tiene producto asociado activo {marca.Descripcion}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
    }

