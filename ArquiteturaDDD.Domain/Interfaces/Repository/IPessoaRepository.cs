using ArquiteturaDDD.Domain.Entities;

namespace ArquiteturaDDD.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        void FullDelete(int id);

        void FullDelete(Pessoa pessoa);
    }
}
