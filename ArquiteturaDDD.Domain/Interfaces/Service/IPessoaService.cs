using ArquiteturaDDD.Domain.Entities;

namespace ArquiteturaDDD.Domain.Interfaces.Service
{
    public interface IPessoaService : IServiceBase<Pessoa>
    {
        void FullDelete(int id);

        void FullDelete(Pessoa pessoa);
    }
}
