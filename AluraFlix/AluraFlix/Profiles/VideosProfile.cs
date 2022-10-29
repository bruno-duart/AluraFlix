using AluraFlix.Data.VideosDTOS;
using AluraFlix.Models;
using AutoMapper;

namespace AluraFlix.Profiles
{
    public class VideosProfile: Profile
    {
        public VideosProfile()
        {
            CreateMap<CreateVideosDTO, Videos>();
            CreateMap<Videos, ReadVideosDTO>();
            CreateMap<UpdateVideosDTO, Videos>();
        }
    }
}
