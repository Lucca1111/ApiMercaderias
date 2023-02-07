using APImercaderias.Modelos;
using APImercaderias.Modelos.Dtos;
using APImercaderias.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Controllers
{
    [Route("api/Familias")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaRepositorio _faRepo;
        private readonly IMapper _mapper;

        public FamiliaController(IFamiliaRepositorio faRepo, IMapper mapper)
        {
            _faRepo = faRepo;
            _mapper = mapper;


        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FamiliaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult AltaFamilia([FromBody] FamiliaDto FamiliaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (FamiliaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_faRepo.ExisteFamilia(FamiliaDto.Descripcion))
            {
                ModelState.AddModelError("", "La familia ya existe");
                return StatusCode(404, ModelState);
            }

            var familia = _mapper.Map<Familia>(FamiliaDto);
            if (!_faRepo.AltaFamilia(familia))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando la familia{familia.Descripcion}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetFamilia", new { IdFamilia = familia.Id }, familia);
        }

        [HttpPatch("{IdFamilia:int}", Name = "ModificacionFamilia")]
        [ProducesResponseType(201, Type = typeof(FamiliaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ModificacionFamilia([FromBody] ModFamiliaDto modfamiliaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (modfamiliaDto == null)
            {
                return BadRequest(ModelState);
            }

            var familia = _mapper.Map<Familia>(modfamiliaDto);

            if (!_faRepo.ModificacionFamilia(familia))
            {
                ModelState.AddModelError("", $"Algo salio mal modificando la familia{familia.Descripcion}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{IdFamilia:int}", Name = "BajaFamilia")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public IActionResult BajaFamilia(int IdFamilia, [FromBody] BajaFamDto BajaFamDto)
        {
            if (!_faRepo.ExisteFamilia(IdFamilia))
            {
                return NotFound();
            }

            var familia = _faRepo.GetFamilia(IdFamilia);

            if (!_faRepo.BajaFamilia(familia))
            {
                ModelState.AddModelError("", $"No se puede dar de baja la familia ya que tiene producto asociado activo {familia.Descripcion}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}

    
    

