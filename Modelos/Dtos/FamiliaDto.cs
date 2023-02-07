using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class FamiliaDto
    {
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [MaxLength(50, ErrorMessage = "La cantidad maxima de caracteres es de 50!")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime FechaModificacion { get; set; }
    }
}
