using APImercaderias.Modelos;

namespace APImercaderias.Repositorio.IRepositorio
{
    public interface IProductosRepositorio
    {
        ICollection<Producto> GetProductos();
        Producto GetProductos(string CodigoProducto);
        bool ExisteProducto(string DescripcionProducto);
        bool ExisteProduct(string CodigoProducto);
        bool AltaProducto(Producto productos);

        bool ModificacionProducto(Producto productos);
        bool BajaProducto(Producto productos);

        ICollection<Producto> GetFiltroPorCodigo(string CodigoProducto, int IdMarca, int IdFamilia);


        bool Guardar();
    }
}
