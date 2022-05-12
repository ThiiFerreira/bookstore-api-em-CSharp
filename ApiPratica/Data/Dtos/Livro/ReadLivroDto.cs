using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Data.Dtos.Livro
{
    public class ReadLivroDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Nome_autor { get; set; }

        public string Texto { get; set; }

        public int CategoriaId { get; set; }
    }
}
