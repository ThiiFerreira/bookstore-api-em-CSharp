using ApiPratica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPratica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Livro>()
                .HasOne(livro => livro.Categoria)
                .WithMany(categoria => categoria.Livros)
                .HasForeignKey(livro => livro.CategoriaId);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
