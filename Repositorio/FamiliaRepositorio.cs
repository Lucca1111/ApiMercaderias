using APImercaderias.Modelos;
using APImercaderias.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APImercaderias.Repositorio
{
    public class FamiliaRepositorio : IFamiliaRepositorio
    {
        private readonly UsersContext _bd;

        public FamiliaRepositorio(UsersContext bd)
        {
            _bd = bd;
        }

        public bool AltaFamilia(Familia familia)
        {
            familia.FechaModificacion = DateTime.Now;
            _bd.Familia.Add(familia);
            return Guardar();
        }

        //public bool BajaFamilia(Familia familia)
        //{
        //    familia.FechaBaja = DateTime.Now;
        //    using (var UsersContext = new UsersContext())
        //    {
        //        var Familia = _bd.Familia.SingleOrDefault(f => f.Id == IdFamilia);

        //        if (familia != null)
        //        {
        //            var productosConFamilia = _bd.Productos.Where(p => p.IdFamilia == familia.Id).ToList();
        //            if (productosConFamilia.Any())
        //            {
        //                Console.WriteLine("La familia no puede ser eliminada debido a que tiene un producto activo asociado");
        //            }
        //            else
        //            {
        //                _bd.Familia.Remove(familia);
        //                return Guardar();
        //            }
        //        }
        //    }
        public bool BajaFamilia(Familia familia)
        {
            familia.FechaBaja = DateTime.Now;
            using (var context = new UsersContext())
            {
                var familiaDb = context.Familia.SingleOrDefault(f => f.Id == familia.Id);

                if (familiaDb != null)
                {
                    var productosConFamilia = context.Productos.Where(p => p.IdFamilia == familiaDb.Id).ToList();
                    if (productosConFamilia.Any())
                    {
  
                        return false;
                    }
                    else
                    {
                        context.Familia.Remove(familiaDb);
                        context.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        public bool ModificacionFamilia(Familia familia)
        {
            familia.FechaModificacion = DateTime.Now;
            _bd.Familia.Update(familia);
            return Guardar();
        }

        public ICollection<Familia> GetFamilia()
        {
            return _bd.Familia.OrderBy(f => f.Descripcion).ToList();
        }

        public Familia GetFamilia(int IdFamilia)
        {
            return _bd.Familia.FirstOrDefault(f => f.Id == IdFamilia);
        }
        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public bool ExisteFamilia(string Descripcion)
        {
            bool valor = _bd.Familia.Any(f => f.Descripcion.ToLower().Trim() == Descripcion.ToLower().Trim());
            return valor;
        }

        public bool ExisteFamilia(int id)
        {
            return _bd.Familia.Any(f => f.Id == id);
        }
    }
}
