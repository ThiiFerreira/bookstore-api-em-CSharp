using ApiPratica.Data;
using ApiPratica.Data.Dtos.Categoria;
using ApiPratica.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Services
{
    public class CategoriaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadCategoriaDto AdicionaCategoria(CreateCategoriaDto createDto)
        {
            Categoria categoria = _mapper.Map<Categoria>(createDto);
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return _mapper.Map<ReadCategoriaDto>(categoria);
        }

        public ReadCategoriaDto RecuperaCategoriaPorId(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(contato => contato.Id == id);
            if(categoria != null)
            {
                return _mapper.Map<ReadCategoriaDto>(categoria);
            }
            return null;
        }

        public List<ReadCategoriaDto> RecuperaCategorias()
        {
            List<Categoria> categoria = _context.Categorias.ToList();

            if(categoria != null)
            {
                return _mapper.Map<List<ReadCategoriaDto>>(categoria);
            }
            return null;
        }

        public Result AtualizaCategoria(int id, CreateCategoriaDto createDto)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null) return Result.Fail("Categoria não encontrada");
            _mapper.Map(createDto, categoria);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null) return Result.Fail("Categoria não encontrada");
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
