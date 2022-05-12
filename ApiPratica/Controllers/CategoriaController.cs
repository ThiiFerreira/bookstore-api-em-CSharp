using ApiPratica.Data.Dtos.Categoria;
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
    [Route("{controller}")]
    public class CategoriaController : ControllerBase
    {
        private CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] CreateCategoriaDto createDto)
        {
            ReadCategoriaDto readDto = _categoriaService.AdicionaCategoria(createDto);
            return CreatedAtAction(nameof(RecuperaCategoriaPorId), new { id = readDto.Id }, readDto);

        }
        [HttpGet]
        public IActionResult RecuperaCategorias()
        {
            List<ReadCategoriaDto> readDto = _categoriaService.RecuperaCategorias();
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCategoriaPorId(int id)
        {
            ReadCategoriaDto readDto = _categoriaService.RecuperaCategoriaPorId(id);
            if (readDto == null) return NotFound("Categoria não encontrada");
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCategoria(int id, [FromBody] CreateCategoriaDto createDto)
        {
            Result resultado = _categoriaService.AtualizaCategoria(id, createDto);
            if (resultado.IsFailed) return NotFound(resultado.Reasons);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCategoria(int id)
        {
            Result resultado = _categoriaService.DeletaCategoria(id);
            if (resultado.IsFailed) return NotFound(resultado.Reasons);
            return NoContent();
        }

    }
}
