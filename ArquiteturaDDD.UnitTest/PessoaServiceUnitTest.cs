using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArquiteturaDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using ArquiteturaDDD.Service;
using ArquiteturaDDD.Infra.Data;

namespace ArquiteturaDDD.UnitTest
{
    [TestClass]
    public class PessoaServiceUnitTest
    {
        public PessoaService servico = new PessoaService(new PessoaRepository());
        [TestInitialize]
        public void Setup()
        {
            Pessoa p = new Pessoa() { Nome = "Fulano Setup", Sobrenome = "Silva", Observacao = "Ok Ok" };
            servico.Add(p);
            servico.SaveChanges();
            Assert.IsNotNull(p.Id);
        }

        [TestMethod]
        public void CadastrarUsuario()
        {
            Pessoa p = new Pessoa() { Nome = "Fulano Inclusão", Sobrenome = "Silva", Observacao = "Ok Ok" };
            servico.Add(p);
            servico.SaveChanges();
            Assert.IsNotNull(p.Id);
        }

        [TestMethod]
        public void AlteraUsuario()
        {
            List<Pessoa> lista = new List<Pessoa>(servico.GetAll());
            Pessoa p = lista.FirstOrDefault();
            p.Nome = "Fulano Alterado";
            servico.Update(p);
            servico.SaveChanges();
            Assert.IsNotNull(p.DtAlt);
        }
        [TestMethod]
        public void ExcluiUsuario()
        {

            List<Pessoa> lista = new List<Pessoa>(servico.GetAll());
            Pessoa p = lista.LastOrDefault();
            servico.Delete(p);
            servico.SaveChanges();
            Assert.IsNotNull(p.DtAlt);
        }
        [TestMethod]
        public void ExcluiFullUsuario()
        {
            List<Pessoa> lista = new List<Pessoa>(servico.GetAll());
            Pessoa p = lista.FirstOrDefault();
            servico.FullDelete(p.Id);
            servico.SaveChanges();
            p = null;
            Assert.IsNull(p);
        }
    }
}
