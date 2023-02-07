using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class ModFamiliaDto
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de modificacion es obligatoria")]
        public DateTime FechaModificacion { get; set; }
    }
}
