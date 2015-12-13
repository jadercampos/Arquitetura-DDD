using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArquiteturaDDD.Application;
using ArquiteturaDDD.Service;
using ArquiteturaDDD.Infra.Data;
using ArquiteturaDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ArquiteturaDDD.UnitTest
{
    [TestClass]
    public class PessoaApplicationUnitTest
    {
        public PessoaApplication application = new PessoaApplication(new PessoaService(new PessoaRepository()));
        [TestInitialize]
        public void Setup()
        {
            Pessoa p = new Pessoa() { Nome = "Fulano Setup", Sobrenome = "Silva", Observacao = "Ok Ok" };
            application.Add(p);
            application.SaveChanges();
            Assert.IsNotNull(p.Id);
        }

        [TestMethod]
        public void CadastrarUsuario()
        {
            Pessoa p = new Pessoa() { Nome = "Fulano Inclusão", Sobrenome = "Silva", Observacao = "Ok Ok" };
            application.Add(p);
            application.SaveChanges();
            Assert.IsNotNull(p.Id);
        }

        [TestMethod]
        public void AlteraUsuario()
        {
            List<Pessoa> lista = new List<Pessoa>(application.GetAll());
            Pessoa p = lista.FirstOrDefault();
            p.Nome = "Fulano Alterado";
            application.Update(p);
            application.SaveChanges();
            Assert.IsNotNull(p.DtAlt);
        }
        [TestMethod]
        public void ExcluiUsuario()
        {

            List<Pessoa> lista = new List<Pessoa>(application.GetAll());
            Pessoa p = lista.LastOrDefault();
            application.Delete(p);
            application.SaveChanges();
            Assert.IsNotNull(p.DtAlt);
        }
        [TestMethod]
        public void ExcluiFullUsuario()
        {
            List<Pessoa> lista = new List<Pessoa>(application.GetAll());
            Pessoa p = lista.FirstOrDefault();
            application.FullDelete(p.Id);
            application.SaveChanges();
            p = null;
            Assert.IsNull(p);
        }
    }
}
