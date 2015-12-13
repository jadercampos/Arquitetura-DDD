using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Enums;
using ArquiteturaDDD.Domain.Interfaces.Repository;

namespace ArquiteturaDDD.Infra.Data
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public new void Add(Pessoa pessoa)
        {
            if (!pessoa.StatusDbAuditTrail.HasValue)
                pessoa.StatusDbAuditTrail = StatusDbAuditTrail.Ativo;
            base.Add(pessoa);
        }
        public override void Delete(int id)
        {
            LogicDelete(id);
        }
        public override void Delete(Pessoa pessoa)
        {
            LogicDelete(pessoa);
        }

        public new void FullDelete(int id)
        {
            base.FullDelete(id);
        }
        public new void FullDelete(Pessoa pessoa)
        {
            base.FullDelete(pessoa);
        }
    }
}
