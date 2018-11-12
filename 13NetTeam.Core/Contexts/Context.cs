using _13NetTeam.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _13NetTeam.Core.Contexts
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) :
             base(options)
        {

        }

        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
