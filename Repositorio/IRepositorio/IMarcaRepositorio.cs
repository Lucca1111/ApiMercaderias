using APImercaderias.Modelos;

namespace APImercaderias.Repositorio.IRepositorio
{
    public interface IMarcaRepositorio
    {
        ICollection<Marca> GetMarca();
        Marca GetMarca(int IdMarca);
        bool AltaMarca(Marca marca);
        bool ExisteMarca(string Descripcion);
        bool ExisteMarca(int id);
        bool ModificacionMarca(Marca marca);

        bool BajaMarca(Marca marca);

        bool Guardar();
    }
}
