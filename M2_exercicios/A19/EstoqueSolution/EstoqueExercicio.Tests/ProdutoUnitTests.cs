using EstoqueExercicio.Library;
using NUnit.Framework;

namespace EstoqueExercicio.Tests
{
    public class ProdutoUnitTests
    {
        /*
        Quando validar produto
        E nome não for informado
        Então deve resultar em produto inválido
        */
        [Test]
        public void Quando_ValidarProduto_E_NomeNaoForInformado_Entao_DeveResultarEmProdutoInvalido()
        {
            // arrange
            var produto = new Produto();
            produto.Codigo = 1;
            produto.DataValidade = System.DateTime.Now.AddDays(3);
            produto.Preco = 35;

            // action
            var ehValido = produto.Validar();

            // assert
            Assert.IsFalse(ehValido);
        }

        /*
        Quando validar produto
        E nome está vazio
        Então deve resultar em produto inválido
        */


        [Test]
        public void Quando_ValidarProduto_E_NomeForVazio_Entao_DeveResultarEmProdutoInvalido()
        {
            // arrange
            var produto = new Produto();
            produto.Codigo = 1;
            produto.DataValidade = System.DateTime.Now.AddDays(3);
            produto.Preco = 35;
            produto.Nome = "";

            // action
            var ehValido = produto.Validar();

            // assert
            Assert.IsFalse(ehValido);
        }

        /*
        Quando validar produto
        E código é igual a zero 
        Então deve resultar em produto inválido
        */
        [Test]
        public void Quando_ValidaProduto_E_CodigoForIgualAZero_Entao_DeveResultarEmProdutoInvalido()
        {
            var produto = new Produto();
            produto.Codigo = 0;
            produto.DataValidade = System.DateTime.Now.AddDays(3);
            produto.Preco = 35;
            produto.Nome = "Produto";

            var ehValido = produto.Validar();

            Assert.IsFalse(ehValido);
        }

        /*
        Quando validar produto
        E produto estiver vencido
        Então deve resultar em produto inválido
        */
        [Test]
        public void Quando_ValidarProduto_E_ProdutoEstiverVencido_Entao_DeveResultarEmProdutoInvalido()
        {
            var produto = new Produto();
            produto.Codigo = 1;
            produto.DataValidade = System.DateTime.Now.AddDays(-3);
            produto.Preco = 35;
            produto.Nome = "Produto";

            var ehValido = produto.Validar();

            Assert.IsFalse(ehValido);
        }

        /*
        Quando validar produto
        E nome é diferente de vazio
        E código maior que zero
        E preço maior que zero
        E data de validade maior que dia atual
        Então deve resultar em produto válido
        */
        [Test]
        public void Quando_ValidarProduto_E_ProdutoEstiverComTodasAsInformacoesAdequadas_Entao_DeveResultarEmProdutoValido()
        {
            var produto = new Produto();
            produto.Codigo = 1;
            produto.DataValidade = System.DateTime.Now.AddDays(3);
            produto.Preco = 35;
            produto.Nome = "Produto";

            var ehValido = produto.Validar();

            Assert.IsTrue(ehValido);
        }
    }
}
