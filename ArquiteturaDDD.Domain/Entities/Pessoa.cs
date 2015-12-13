using System.ComponentModel.DataAnnotations;

namespace ArquiteturaDDD.Domain.Entities
{
    public class Pessoa : DbAuditTrail
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [MaxLength(300)]
        public string Observacao { get; set; }
    }
}
