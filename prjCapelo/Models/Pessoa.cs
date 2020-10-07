using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCapelo.Models
{
    [Table("Pessoa")]
    class Pessoa : BaseModel
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }        
        public string Cpf { get; set; }        
        public string Sexo { get; set; }
        public string Email { get; set; }
    }
}
