using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Domain.Interfaces.Application;
using ArquiteturaDDD.Domain.Interfaces.Service;

namespace ArquiteturaDDD.Application
{
    public class PessoaApplication : ApplicationBase<Pessoa>, IPessoaApplication
    {
        private readonly IPessoaService _pessoaService;
        public PessoaApplication(IPessoaService pessoaService) : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }
        public void FullDelete(Pessoa pessoa)
        {
            _pessoaService.FullDelete(pessoa);
        }

        public void FullDelete(int id)
        {
            _pessoaService.FullDelete(id);
        }
    }
}
