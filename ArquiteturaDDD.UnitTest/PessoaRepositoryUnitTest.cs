using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace ArquiteturaDDD.UnitTest
{
    [TestClass]
    public class PessoaRepositoryUnitTest
    {
        public PessoaRepository repositorio = new PessoaRepository();
        [TestInitialize]
        public void Setup()
        {
            Pessoa p = new Pessoa() { Nome = "Fulano Setup", Sobrenome = "Silva", Observacao = "Ok Ok" };
            repositorio.Add(p);
            repositorio.SaveChanges();
            Assert.IsNotNull(p.Id);
        }

        [TestMethod]
        public void CadastrarUsuario()
        {
            Pessoa p = new Pessoa() { Nome = "Fulano Inclusão", Sobrenome = "Silva", Observacao = "Ok Ok" };
            repositorio.Add(p);
            repositorio.SaveChanges();
            Assert.IsNotNull(p.Id);
        }

        [TestMethod]
        public void AlteraUsuario()
        {
            List<Pessoa> lista = new List<Pessoa>(repositorio.GetAll());
            Pessoa p = lista.FirstOrDefault();
            p.Nome = "Fulano Alterado";
            repositorio.Update(p);
            repositorio.SaveChanges();
            Assert.IsNotNull(p.DtAlt);
        }
        [TestMethod]
        public void ExcluiUsuario()
        {

            List<Pessoa> lista = new List<Pessoa>(repositorio.GetAll());
            Pessoa p = lista.FirstOrDefault();
            repositorio.Delete(p);
            repositorio.SaveChanges();
            Assert.IsNotNull(p.DtAlt);
        }
        [TestMethod]
        public void ExcluiFullUsuario()
        {
            List<Pessoa> lista = new List<Pessoa>(repositorio.GetAll());
            Pessoa p = lista.FirstOrDefault();
            repositorio.FullDelete(p.Id);
            repositorio.SaveChanges();
            p = null;
            Assert.IsNull(p);
        }
    }

}
