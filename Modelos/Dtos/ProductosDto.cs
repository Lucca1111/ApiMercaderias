using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class ProductosDto
    {
        [Required(ErrorMessage = "El codigo del producto es obligatorio")]
        public string CodigoProducto { get; set; }

        [Required(ErrorMessage = "La descripcion del producto es obligatoria")]
        [MaxLength(50, ErrorMessage = "La cantidad maxima de caracteres es de 50")]
        public string DescripcionProducto { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int IdMarca { get; set; }

        public int IdFamilia { get; set; }

        [Required(ErrorMessage = "La fecha de modificacion es obligatoria")]
        public DateTime FechaModificacion { get; set; }
    }
}
