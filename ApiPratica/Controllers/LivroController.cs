using ApiPratica.Data.Dtos.Livro;
using ApiPratica.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        public IActionResult AdicionaLivro([FromBody] CreateLivroDto createDto)
        {
            ReadLivroDto readDto = _livroService.AdicionaLivro(createDto);
            return CreatedAtAction(nameof(RecuperaLivroPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaLivros(int? categoria)
        {
            List<ReadLivroDto> readDto = _livroService.RecuperaLivros(categoria);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaLivroPorId(int id)
        {
            ReadLivroDto readDto = _livroService.RecuperaLivroPorId(id);
            if (readDto == null) return NotFound("Livro não encontrado");
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaLivro(int id, [FromBody] CreateLivroDto createDto)
        {
            Result resultado = _livroService.AtualizaLivro(id, createDto);
            if (resultado.IsFailed) return NotFound(resultado.Reasons);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLivro (int id)
        {
            Result resultado = _livroService.DeletaLivro(id);
            if (resultado.IsFailed) return NotFound(resultado.Reasons);
            return NoContent();
        }
    }
}
