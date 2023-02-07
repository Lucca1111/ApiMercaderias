using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class AltaMarcaDto
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(50, ErrorMessage = "El número máximo de caracteres es de 50!")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de modificacion es obligatoria")]
        public DateTime FechaModificacion { get; set; }
    }
}
