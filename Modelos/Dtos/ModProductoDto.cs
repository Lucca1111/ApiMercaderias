using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class ModProductoDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "La cantidad maxima de caracteres es de 50")]
        public string DescripcionProducto { get; set; }

        [Required(ErrorMessage = "La fecha de modificacion es obligatoria")]
        public DateTime FechaModificacion { get; set; }
        public int PrecioCosto { get; set; }
        public int PrecioVenta { get; set; }

        public int IdMarca { get; set; }

        public int IdFamilia { get; set; }
    }
}
