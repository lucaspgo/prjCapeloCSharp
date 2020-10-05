using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System;

namespace prjCapelo.Models
{
    [Table("Aluno")]
    class Aluno 
    {
        public Aluno()
        {
            Pessoa = new Pessoa();
        }
        [Key]
        public int Matricula { get; set; }

        public DateTime DataIngresso { get; set; }

        public string Senha { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
