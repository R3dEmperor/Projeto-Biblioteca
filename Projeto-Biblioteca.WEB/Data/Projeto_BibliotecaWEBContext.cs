using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Biblioteca.WEB.Models;

namespace Projeto_Biblioteca.WEB.Data
{
    public class Projeto_BibliotecaWEBContext : DbContext
    {
        public Projeto_BibliotecaWEBContext (DbContextOptions<Projeto_BibliotecaWEBContext> options)
            : base(options)
        {
        }

        public DbSet<Projeto_Biblioteca.WEB.Models.Genero> Genero { get; set; } = default!;
        public DbSet<Projeto_Biblioteca.WEB.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<Projeto_Biblioteca.WEB.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<Projeto_Biblioteca.WEB.Models.Produto> Produto { get; set; } = default!;
        public DbSet<Projeto_Biblioteca.WEB.Models.Reserva> Reserva { get; set; } = default!;
        public DbSet<Projeto_Biblioteca.WEB.Models.Registro> Registro { get; set; } = default!;
    }
}
