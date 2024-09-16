using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade1309.Models
{
    [Table("fornecedor")]
    public class Fornecedor
    {
        [Key]
        [Column("fornecedorid")]
        public int Id { get; set; }

        [Column("nome")]
        public string nome { get; set; }
    }
}
