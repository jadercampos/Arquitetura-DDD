using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces.Repository;
using ArquiteturaDDD.Domain.Interfaces.Service;

namespace ArquiteturaDDD.Service
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public void FullDelete(Pessoa pessoa)
        {
            _pessoaRepository.FullDelete(pessoa);
        }

        public void FullDelete(int id)
        {
            _pessoaRepository.FullDelete(id);
        }
    }
}
