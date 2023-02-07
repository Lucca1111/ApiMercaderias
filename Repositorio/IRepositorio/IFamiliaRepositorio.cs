using APImercaderias.Modelos;

namespace APImercaderias.Repositorio.IRepositorio
{
    public interface IFamiliaRepositorio
    {

        ICollection<Familia> GetFamilia();
        Familia GetFamilia(int IdFamilia);
        bool AltaFamilia(Familia familia);
        bool ExisteFamilia(string Descripcion);
        bool ExisteFamilia(int id);
        bool ModificacionFamilia(Familia familia);

        bool BajaFamilia(Familia familia);

        bool Guardar();
    }
}
