using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


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

        [Key]
        public int Matricula { get; set; }

        public int DataIngresso { get; set; }

        public string Senha { get; set; }

        public Disciplina Disciplina { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
