using System.ComponentModel.DataAnnotations.Schema;

namespace prjCapelo.Models
{
    [Table("Sala")]
    class Sala : BaseModel
    {
        public string Nome { get; set; }
    }
}
