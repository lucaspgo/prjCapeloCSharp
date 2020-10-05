using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace prjCapelo.Models
{
    [Table("Aula")]
    class Aula : BaseModel
    {        
        public Aula()
        {
            Aluno = new Aluno();
            Professor = new Professor();
            Sala = new Sala();
        }
        
        public Aluno Aluno { get; set; }
        public Professor Professor { get; set; }        
        public Sala Sala { get; set; }
        public DateTime DataInicio { get; set; } 
        public DateTime DataFim { get; set; }

    }
}
