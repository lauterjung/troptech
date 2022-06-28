using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ControleEstoque.Tests
{
    public class EstoqueUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Quando_VerificarSeProdutoExiste_E_ProdutoNaoExistir_Entao_DeveRetornarQueNaoExiste()
        {
            var estoque = new Estoque();
            var produto = new Produto("nome", "descricao");

            var produtoExiste = estoque.ProdutoExisteNoEstoque(produto);

            Assert.IsFalse(produtoExiste);
        }

        [Test]
        public void Quando_VerificarSeProdutoExiste_E_ProdutoExistir_Entao_DeveRetornarQueExiste()
        {
            var produtoCadastrado = new Produto("nome", "descricao");
            var produtosCadastrados = new List<Produto> { produtoCadastrado };
            var estoque = new Estoque(produtosCadastrados);

            var produto = new Produto("nome", "descricao");

            var produtoExiste = estoque.ProdutoExisteNoEstoque(produto);

            Assert.IsTrue(produtoExiste);
        }
    }
}