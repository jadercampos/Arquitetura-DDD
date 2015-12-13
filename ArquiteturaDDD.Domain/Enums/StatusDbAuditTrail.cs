using System.ComponentModel;

namespace ArquiteturaDDD.Domain.Enums
{
    public enum StatusDbAuditTrail
    {
        [Description("Inativo")]
        Inativo = 0,
        [Description("Ativo")]
        Ativo = 1,
        [Description("Excluído")]
        Excluido = 2,
        [Description("Recuperado")]
        Recuperado = 3
    }
}
