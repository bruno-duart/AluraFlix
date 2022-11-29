using AluraFlix.Data.CategoriasDTOS;
using AluraFlix.Models;
using AutoMapper;

namespace AluraFlix.Profiles
{
    public class CategoriasProfile : Profile
    {
        public CategoriasProfile()
        {
            CreateMap<CreateCategoriasDTO, Categorias>();
            CreateMap<Categorias, ReadCategoriasDTO>();
            CreateMap<UpdateCategoriasDTO, Categorias>();
        }
    }
}
