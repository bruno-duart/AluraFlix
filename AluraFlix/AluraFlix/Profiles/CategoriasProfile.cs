using AluraFlix.Data.VideosDTOS;
using AluraFlix.Models;
using AutoMapper;

namespace AluraFlix.Profiles
{
    public class CategoriasProfile : Profile
    {
        public CategoriasProfile()
        {
            CreateMap<CreateVideosDTO, Categorias>();
            CreateMap<Categorias, ReadVideosDTO>();
            CreateMap<UpdateVideosDTO, Categorias>();
        }
    }
}
