using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class ModMarcaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de modificacion es obligatoria")]
        public DateTime FechaModificacion { get; set; }
    }
}
