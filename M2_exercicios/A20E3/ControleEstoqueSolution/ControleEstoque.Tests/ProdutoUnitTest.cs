using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Excecoes;
using NUnit.Framework;

namespace ControleEstoque.Tests
{
    public class ProdutoUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Quando_DeduzirQuantidade_E_QtdEmEstoqueForMenorQueZero_NaoDeveConcluirAAcao()
        {
            var produto = new Produto("Batom", "Cor Rosa");

            Assert.Throws<EstoqueInsuficienteException>(() => produto.DeduzirQuantidade(1));
        }
    }
}