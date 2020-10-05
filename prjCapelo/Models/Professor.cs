using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace prjCapelo.Models
{
    [Table("Professor")]
    class Professor
    {
        public Professor()
        {
            Disciplina = new Disciplina();
            Pessoa = new Pessoa();
        }

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Matricula { get; set; }

        public DateTime DataIngresso { get; set; }

        public string Senha { get; set; }

        public Disciplina Disciplina { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
