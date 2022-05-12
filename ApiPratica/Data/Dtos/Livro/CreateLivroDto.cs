using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Data.Dtos.Livro
{
    public class CreateLivroDto
    {
        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Nome_autor { get; set; }

        public string Texto { get; set; }

        [Required]
        public int CategoriaId { get; set; }
    }
}
