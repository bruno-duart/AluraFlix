using AluraFlix.Data;
using AluraFlix.Data.CategoriasDTOS;
using AluraFlix.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AluraFlix.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private static List<Categorias> lista = new List<Categorias>();
        private static int Id = 0;
        private AluraFlixDBContext _context;
        private IMapper _mapper;

        public CategoriasController(AluraFlixDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Categorias> GetCategorias()
        {
            //return _context.Categorias;
            return lista;
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoriasById(int id)
        {
            //Categorias ReadCategoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == CategoriaId);
            Categorias ReadCategoria = lista.FirstOrDefault(categoria => categoria.Id == id);

            if (ReadCategoria == null)
            {
                return NotFound();
            }
            ReadCategoriasDTO ReadCatDTO = _mapper.Map<ReadCategoriasDTO>(ReadCategoria);
            
            return Ok(ReadCatDTO);

        }

        [HttpPost]
        public Categorias PostCategorias([FromBody] CreateCategoriasDTO categoriasDTO)
        {
            /*Categorias NovaCategoria = new Categorias()
            {
                Id = Id++,
                Titulo = categoriasDTO.Titulo,
                Cor = categoriasDTO.Cor
            };*/
            Categorias NovaCategoria = _mapper.Map<Categorias>(categoriasDTO);
            
            NovaCategoria.Id = Id++;
            lista.Add(NovaCategoria);

            return NovaCategoria;
            //_context.Categorias.Add(NovaCategoria);
            //_context.SaveChanges();
            //return CreatedAtAction(nameof(GetCategoriasById), new { Id = NovaCategoria.Id }, NovaCategoria);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoriasById(int id, [FromBody] UpdateCategoriasDTO categoriasDTO)
        {
            //Categorias AtualizaCategoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            Categorias AtualizaCategoria = lista.FirstOrDefault(categoria => categoria.Id == id);
            if (AtualizaCategoria == null)
            {
                return NotFound();
            }
            AtualizaCategoria = _mapper.Map(categoriasDTO, AtualizaCategoria);
            return Ok(AtualizaCategoria);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoriasById(int id)
        {
            //Categorias AtualizaCategoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            Categorias AtualizaCategoria = lista.FirstOrDefault(categoria => categoria.Id == id);
            if (AtualizaCategoria == null)
            {
                return NotFound();
            }
            lista.Remove(AtualizaCategoria);
            return Ok();
        }
    }
}
