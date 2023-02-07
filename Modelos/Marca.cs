using System;
using System.Collections.Generic;

namespace APImercaderias.Modelos;

public partial class Marca
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaModificacion { get; set; }

    public bool Baja { get; set; }

    public DateTime? FechaBaja { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
