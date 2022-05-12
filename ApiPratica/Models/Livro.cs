using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Nome_autor { get; set; }

        [Required]
        public string Texto { get; set; }
        public virtual Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

    }
}
