using APImercaderias.Modelos;
using APImercaderias.Modelos.Dtos;
using AutoMapper;

namespace APImercaderias.MercaderiaMapper
{
    public class MercaderiaMapper : Profile
    {
        public MercaderiaMapper()
        {
            CreateMap<Producto, ProductosDto>().ReverseMap();
            CreateMap<Producto, ModProductoDto>().ReverseMap();
            CreateMap<Producto, ListadoProductosDto>().ReverseMap();
            CreateMap<Producto, BajaProductoDto>().ReverseMap();
            CreateMap<Familia, FamiliaDto>().ReverseMap();
            CreateMap<Familia, ModFamiliaDto>().ReverseMap();
            CreateMap<Marca, AltaMarcaDto>().ReverseMap();
            CreateMap<Marca, ModMarcaDto>().ReverseMap();
        }
    }
}
