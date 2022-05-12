using ApiPratica.Data;
using ApiPratica.Data.Dtos.Livro;
using ApiPratica.Models;
using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Services
{
    public class LivroService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public LivroService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadLivroDto AdicionaLivro(CreateLivroDto createDto)
        {
            Livro livro = _mapper.Map<Livro>(createDto);
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return _mapper.Map<ReadLivroDto>(livro);
        }

        public List<ReadLivroDto> RecuperaLivros(int? categoria)
        {
            List<Livro> livros;
            
            if(categoria == null)
            {
                livros = _context.Livros.ToList();
            }
            else
            {
                livros = _context
                    .Livros.Where(livro => livro.CategoriaId == categoria).ToList();
            }

            if(livros != null)
            {
                return _mapper.Map<List<ReadLivroDto>>(livros);
            }
            return null;

        }

        public ReadLivroDto RecuperaLivroPorId(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if( livro != null)
            {
                return _mapper.Map<ReadLivroDto>(livro);
            }
            return null;
        }


        public Result AtualizaLivro(int id, CreateLivroDto createDto)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null) return Result.Fail("Livro não encontrado");
            _mapper.Map(createDto, livro);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaLivro(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null) return Result.Fail("Livro não encontrado");
            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
