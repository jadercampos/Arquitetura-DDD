using ArquiteturaDDD.Domain.Entities;

namespace ArquiteturaDDD.Domain.Interfaces.Application
{
    public interface IPessoaApplication : IApplicationBase<Pessoa>
    {
        void FullDelete(int id);

        void FullDelete(Pessoa pessoa);
    }
}
