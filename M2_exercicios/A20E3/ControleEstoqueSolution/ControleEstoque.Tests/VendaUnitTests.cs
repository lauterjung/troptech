using NUnit.Framework;

namespace ControleEstoque.Tests
{
    public class VendaUnitTests
    {
        // Quando criar venda entao deve vincular a venda ao produto
        [Test]
        public void Quando_CriarVenda_Entao_DeveVincularAProduto()
        {
           // Arrange
           var produto = new Produto("Batom", "Cor vermelho");

           // Action
           var venda = new Venda(produto);

           // Assert
           Assert.IsNotNull(venda.Produto);
        }
    }
}