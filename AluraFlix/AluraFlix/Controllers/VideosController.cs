using AluraFlix.Data;
using AluraFlix.Data.VideosDTOS;
using AluraFlix.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AluraFlix.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private static List<Videos> ListaVideos = new List<Videos>();
        private static int Id = 0;
        private IMapper _mapper;

        public VideosController()
        {
        }

        [HttpGet]
        public List<Videos> GetVideos()
        {
            return ListaVideos;
        }

        [HttpGet("{id}")]
        public Videos GetVideoById(int id)
        {
            return ListaVideos.FirstOrDefault(video => video.Id == id);
        }

        [HttpPost]
        public Videos PostVideos([FromBody] CreateVideosDTO NovoVideoDTO)
        {
            Videos NovoVideo = new Videos()
            {
                Id = Id++,
                Titulo = NovoVideoDTO.Titulo,
                Descricao = NovoVideoDTO.Descricao,
                Url = NovoVideoDTO.Url
            };
            ListaVideos.Add(NovoVideo);
            Console.WriteLine(NovoVideo.Titulo);
            Console.WriteLine(NovoVideo.Descricao);
            Console.WriteLine(NovoVideo.Url);
            Console.WriteLine(NovoVideo.Id);
            return NovoVideo;
        }

        [HttpPut("{id}")]
        public Videos PutVideosById(int id, [FromBody] UpdateVideosDTO UpdateVidDTO)
        {
            Videos UpdateVideo = ListaVideos.FirstOrDefault(video => video.Id == id);
            if(UpdateVideo == null)
            {
                return null;
            }
            UpdateVideo.Titulo = UpdateVidDTO.Titulo;
            UpdateVideo.Descricao = UpdateVidDTO.Descricao;
            UpdateVideo.Url = UpdateVidDTO.Url;
            return UpdateVideo;
        }

        [HttpDelete("{id}")]
        public void DeleteVideosById(int id)
        {
            Videos DeleteVideo = ListaVideos.FirstOrDefault(video => video.Id == id);
            if(DeleteVideo == null)
            {
                Console.WriteLine("Não há vídeo com este Id");
                return;
            }
            ListaVideos.Remove(DeleteVideo);
            Console.WriteLine($"Vídeo {id} removido");
        }
    }
}
