using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atividade1309.Models
{
    
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Column("clienteid")]
        public int Id { get; set; }

        [Column("nome")]                
        public string nome { get; set; }

        [Column("cpf")]
        public string cpf { get; set; }
    }
}
