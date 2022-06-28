using System.Collections.Generic;
using NUnit.Framework;

namespace ControleEstoque.Tests
{
    public class CaixaServiceUnitTests
    {
        // Se o produto não existir a venda não pode ser realizada
        // Quando_RealizarVenda_E_ProdutoNaoExistir_Entao_NaoDeveConcluirVenda

        [Test]
        public void Quando_RealizarVenda_E_ProdutoNaoExistir_Entao_NaoDeveConcluirVenda()
        {
            // Arrange
            var estoque = new Estoque();

            var caixaService = new CaixaService(estoque);

            // Action
            double venda = caixaService.RealizarVenda(0);

            // Assert
            Assert.IsNaN(venda);
        }

        // Quando ocorrer uma venda deve ser dada baixa do item no estoque
        // Quando_RealizarVenda_Entao_DeveOcorrerBaixaDoItemNoEstoque
        [Test]
        public void Quando_RealizarVenda_Entao_DeveOcorrerBaixaDoItemNoEstoque()
        {
            // Arrange
            var produtoCadastrado = new Produto("Batom", "Cor vermelho", 5);
            var produtosCadastrados = new List<Produto> { produtoCadastrado };
            var estoque = new Estoque(produtosCadastrados);

            var caixaService = new CaixaService(estoque);

            // Action
            var venda = caixaService.RealizarVenda(0);

            // Assert
            Assert.AreEqual(4, produtoCadastrado.QuantidadeEmEstoque);
        }

        // Se o produto não tiver disponibiliza a venda não pode ser realizada
        // Quando_RealizarVenda_E_ProdutoNaoEstiverDisponivel_Entao_NaoDeveConcluirVenda
        [Test]
        public void Quando_RealizarVenda_E_ProdutoNaoEstiverDisponivel_Entao_NaoDeveConcluirVenda()
        {
            // Arrange
            var produtoCadastrado = new Produto("Batom", "Cor vermelho");
            var produtosCadastrados = new List<Produto> { produtoCadastrado };
            var estoque = new Estoque(produtosCadastrados);

            var caixaService = new CaixaService(estoque);

            // Action
            var venda = caixaService.RealizarVenda(0);

            // Assert
            Assert.IsNaN(venda);
        }

        // Se produto tiver disponibilidade então a venda pode ser realizada
        // Quando_RealizarVenda_E_ProdutoTiverDisponibilidade_Entao_VendaDeveSerRealizada
        [Test]
        public void Quando_RealizarVenda_E_ProdutoTiverDisponibilidade_Entao_VendaDeveSerRealizada()
        {
            // Arrange
            var produtoCadastrado = new Produto("Batom", "Cor vermelho", 3, 5.2);
            var produtosCadastrados = new List<Produto> { produtoCadastrado };
            var estoque = new Estoque(produtosCadastrados);

            var caixaService = new CaixaService(estoque);

            // Action
            var preco = caixaService.RealizarVenda(0);

            // Assert
            Assert.AreEqual(preco, 5.2);
        }

        [Test]
        public void Quando_RealizarVenda_E_QuantidadeForMaiorQue1EProdutoTiverDisponibilidade_Entao_VendaDeveSerRealizada()
        {
            // Arrange
            int quantidadeVenda = 2;
            var produtoCadastrado = new Produto("Batom", "Cor vermelho", 3, 5.3);
            var produtosCadastrados = new List<Produto> { produtoCadastrado };
            var estoque = new Estoque(produtosCadastrados);

            var caixaService = new CaixaService(estoque);

            // Action
            var preco = caixaService.RealizarVenda(0, quantidadeVenda);

            // Assert
            // Assert.IsTrue(produtoCadastrado.Equals(venda.Produto));
            Assert.AreEqual(preco, 10.6);
        }
    }
}