using APImercaderias.Modelos;
using APImercaderias.Repositorio.IRepositorio;

namespace APImercaderias.Repositorio
{
    public class ProductosRepositorio : IProductosRepositorio
    {

        private readonly UsersContext _bd;

        public ProductosRepositorio(UsersContext bd)
        {
            _bd = bd;
        }
        public bool ModificacionProducto(Producto producto)
        {
            producto.FechaModificacion = DateTime.Now;
            _bd.Productos.Update(producto);
            return Guardar();
        }

        public bool BajaProducto(Producto producto)
        {
            _bd.Productos.Remove(producto);
            producto.FechaBaja = DateTime.Now;
            return Guardar();
        }

        public bool AltaProducto(Producto producto)
        {
            var productoExistente = _bd.Productos.FirstOrDefault(p => p.DescripcionProducto == producto.DescripcionProducto);
            if (productoExistente != null && productoExistente.Baja)
            {
                producto.CodigoProducto = productoExistente.CodigoProducto;
            }
            producto.FechaModificacion = DateTime.Now;
            _bd.Productos.Add(producto);
            return Guardar();
        }

        public ICollection<Producto> GetProductos()
        {
            return _bd.Productos.OrderBy(p => p.DescripcionProducto).ToList();
        }

        public Producto GetProductos(string CodigoProducto)
        {
            return _bd.Productos.FirstOrDefault(p => p.CodigoProducto == CodigoProducto);
        }

        public bool ExisteProducto(string DescripcionProducto)
        {
            bool valor = _bd.Productos.Any(p => p.DescripcionProducto.ToLower().Trim() == DescripcionProducto.ToLower().Trim());
            return valor;
        }

        public bool ExisteProduct(string CodigoProducto)
        {
            return _bd.Productos.Any(p => p.CodigoProducto == CodigoProducto);
        }

        public ICollection<Producto> GetFiltroPorCodigo(string CodigoProducto, int IdMarca, int IdFamilia)
        {
            return _bd.Productos
                 .Where(p =>

                     (CodigoProducto != null && p.CodigoProducto.Equals(CodigoProducto)) ||
                     (IdMarca != null && p.IdMarca == IdMarca) ||
                     (IdFamilia != null && p.IdFamilia == IdFamilia)

                 )
                 .OrderBy(p => p.FechaModificacion)
                 .ToList();
        }


        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}

       
         

