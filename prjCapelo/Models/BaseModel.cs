using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCapelo.Models
{
    class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
