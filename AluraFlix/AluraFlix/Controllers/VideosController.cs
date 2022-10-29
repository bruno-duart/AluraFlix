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
        private AluraFlixDBContext _context;
        private IMapper _mapper;

        public VideosController(AluraFlixDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Videos> GetVideos()
        {
            return _context.Videos;
        }

        [HttpGet("{id}")]
        public IActionResult GetVideoById(int id)
        {
            Videos Video = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (Video == null)
            {
                return NotFound();
            }
            ReadVideosDTO read = _mapper.Map<ReadVideosDTO>(Video);
            return Ok(Video);
        }

        [HttpPost]
        public IActionResult PostVideos([FromBody] CreateVideosDTO NovoVideoDTO)
        {
            /*Videos NovoVideo = new Videos()
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
            return NovoVideo;*/

            Videos NovoVideo = _mapper.Map<Videos>(NovoVideoDTO);
            _context.Videos.Add(NovoVideo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetVideoById), new { Id = NovoVideo.Id }, NovoVideo);
        }

        [HttpPut("{id}")]
        public IActionResult PutVideosById(int id, [FromBody] UpdateVideosDTO UpdateVidDTO)
        {
            /*Videos UpdateVideo = ListaVideos.FirstOrDefault(video => video.Id == id);
            if(UpdateVideo == null)
            {
                return null;
            }
            UpdateVideo.Titulo = UpdateVidDTO.Titulo;
            UpdateVideo.Descricao = UpdateVidDTO.Descricao;
            UpdateVideo.Url = UpdateVidDTO.Url;
            return UpdateVideo;*/
            Videos Videos = _context.Videos.FirstOrDefault(video => video.Id == id);
            if (Videos == null)
            {
                return NotFound(Videos);
            }
            Videos = _mapper.Map(UpdateVidDTO, Videos);
            _context.SaveChanges();
            return Ok(Videos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideosById(int id)
        {
            /*Videos DeleteVideo = ListaVideos.FirstOrDefault(video => video.Id == id);
            if(DeleteVideo == null)
            {
                Console.WriteLine("Não há vídeo com este Id");
                return;
            }
            ListaVideos.Remove(DeleteVideo);
            Console.WriteLine($"Vídeo {id} removido");*/
            Videos Videos = _context.Videos.FirstOrDefault(Videos => Videos.Id == id);
            if (Videos == null)
            {
                return NotFound();
            }
            _context.Videos.Remove(Videos);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
