using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace prjCapelo.Models
{
    [Table("Disciplina")]
    class Disciplina : BaseModel
    {
        public string Nome { get; set; }

        public string Sigla { get; set; }
    }
}
