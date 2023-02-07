using APImercaderias.Modelos;
using APImercaderias.Repositorio.IRepositorio;

namespace APImercaderias.Repositorio
{
    public class MarcaRepositorio : IMarcaRepositorio
    {
        private readonly UsersContext _bd;

        public MarcaRepositorio(UsersContext bd)
        {
            _bd = bd;
        }
        public bool AltaMarca(Marca marca)
        {
            marca.FechaModificacion = DateTime.Now;
            _bd.Marcas.Add(marca);
            return Guardar();
        }

        public bool BajaMarca(Marca marca)
        {
            marca.FechaBaja = DateTime.Now;
            using (var context = new UsersContext())
            {
                var marcaDb = context.Marcas.SingleOrDefault(m => m.Id == marca.Id);

                if (marcaDb != null)
                {
                    var productosConMarca = context.Productos.Where(p => p.IdMarca == marcaDb.Id).ToList();
                    if (productosConMarca.Any())
                    {
                        return false;
                    }
                    else
                    {
                        context.Marcas.Remove(marcaDb);
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        public bool ExisteMarca(string Descripcion)
        {
            bool valor = _bd.Marcas.Any(m => m.Descripcion.ToLower().Trim() == Descripcion.ToLower().Trim());
            return valor;
        }

        public bool ExisteMarca(int id)
        {
            return _bd.Marcas.Any(m => m.Id == id);
        }

        public ICollection<Marca> GetMarca()
        {
            return _bd.Marcas.OrderBy(m => m.Descripcion).ToList();
        }

        public Marca GetMarca(int IdMarca)
        {
            return _bd.Marcas.FirstOrDefault(m => m.Id == IdMarca);
        }

 
        public bool ModificacionMarca(Marca marca)
        {
            marca.FechaModificacion = DateTime.Now;
            _bd.Marcas.Update(marca);
            return Guardar();
        }
        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

    } 

}


