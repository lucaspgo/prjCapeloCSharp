using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace prjCapelo.Models
{
    class Context : DbContext
    {
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Aula> Aula{ get; set; }
        public DbSet<Disciplina> Disciplina { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Sala> Sala { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\mssqllocaldb;DataBase=NovoBanco;Trusted_Connection=true");
        }
    }
}
