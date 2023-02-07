using System.ComponentModel.DataAnnotations;

namespace APImercaderias.Modelos.Dtos
{
    public class BajaProductoDto
    {
        [Required]
        public string CodigoProducto { get; set; }

        public bool Baja { get; set; }

        public DateTime FechaBaja { get; set; }
    }
}
