using System.Collections.Generic;
using EstoqueExercicio.Library;
using NUnit.Framework;

namespace EstoqueExercicio.Tests
{
    public class EstoqueUnitTests
    {
        /*
        Quando verificar se produto existe
        E produto não estar na lista de produtos no estoque
        Então deve retornar que ele não existe

        Quando verificar se produto existe
        E produto estar na lista de produtos no estoque
        Então deve retornar que ele existe
        */
        [Test]
        public void Quando_VerificarSeProdutoExiste_E_ProdutoNaoEstarNaListaDoEstoque_Entao_DeveRetornarQueProdutoNaoExiste()
        {
            //arrange
            var produtoNoEstoque = new Produto();
            produtoNoEstoque.Codigo = 1;
            produtoNoEstoque.DataValidade = System.DateTime.Now.AddDays(3);
            produtoNoEstoque.Preco = 35;
            produtoNoEstoque.Nome = "Produto";

            var listaInicial = new List<Produto>() { produtoNoEstoque };
            var estoque = new Estoque(listaInicial);

            var produtoParaVerificar = new Produto();
            produtoParaVerificar.Codigo = 2;
            produtoParaVerificar.DataValidade = System.DateTime.Now.AddDays(3);
            produtoParaVerificar.Preco = 35;
            produtoParaVerificar.Nome = "Produto";

            // action
            var produtoExiste = estoque.VerificaSeProdutoExiste(produtoParaVerificar);

            // assert
            Assert.IsFalse(produtoExiste);
        }

        [Test]
        public void Quando_VerificarSeProdutoExiste_E_ProdutoEstarNaListaDoEstoque_Entao_DeveRetornarQueProdutoExiste()
        {
            //arrange
            var produtoNoEstoque = new Produto();
            produtoNoEstoque.Codigo = 1;
            produtoNoEstoque.DataValidade = System.DateTime.Now.AddDays(3);
            produtoNoEstoque.Preco = 35;
            produtoNoEstoque.Nome = "Produto";

            var listaInicial = new List<Produto>() { produtoNoEstoque };
            var estoque = new Estoque(listaInicial);

            var produtoParaVerificar = new Produto();
            produtoParaVerificar.Codigo = 1;
            produtoParaVerificar.DataValidade = System.DateTime.Now.AddDays(3);
            produtoParaVerificar.Preco = 35;
            produtoParaVerificar.Nome = "Produto";

            // action
            var produtoExiste = estoque.VerificaSeProdutoExiste(produtoParaVerificar);

            // assert
            Assert.IsTrue(produtoExiste);
        }

        /*
        Quando adicionar produto no estoque
        E produto já existir no estoque
        Então não deve adicionar o novo produto

        Quando adicionar produto no estoque
        E produto não existir no estoque
        Então deve adicionar novo produto
        */
        [Test]
        public void Quando_AdicionarProduto_E_ProdutoJaExistirNoEstoque_Entao_NaoDeveAdicionarNovoProduto()
        {
            //arrange
            var produtoNoEstoque = new Produto();
            produtoNoEstoque.Codigo = 1;
            produtoNoEstoque.DataValidade = System.DateTime.Now.AddDays(3);
            produtoNoEstoque.Preco = 35;
            produtoNoEstoque.Nome = "Produto";

            var listaInicial = new List<Produto>() { produtoNoEstoque };
            var estoque = new Estoque(listaInicial);

            var produtoParaAdicionar = new Produto();
            produtoParaAdicionar.Codigo = 1;
            produtoParaAdicionar.DataValidade = System.DateTime.Now.AddDays(3);
            produtoParaAdicionar.Preco = 35;
            produtoParaAdicionar.Nome = "Produto";

            // action
            var adicionouOProduto = estoque.AdicionarProduto(produtoParaAdicionar);

            // assert
            Assert.IsFalse(adicionouOProduto);

            var produtoFoiAdicionado = estoque.ListaProdutos.Contains(produtoParaAdicionar);
            Assert.IsFalse(produtoFoiAdicionado);
        }

        [Test]
        public void Quando_AdicionarProduto_E_ProdutoNaoExistirNoEstoque_Entao_DeveAdicionarNovoProduto()
        {
            //arrange
            var produtoNoEstoque = new Produto();
            produtoNoEstoque.Codigo = 1;
            produtoNoEstoque.DataValidade = System.DateTime.Now.AddDays(3);
            produtoNoEstoque.Preco = 35;
            produtoNoEstoque.Nome = "Produto";

            var listaInicial = new List<Produto>() { produtoNoEstoque };
            var estoque = new Estoque(listaInicial);

            var produtoParaAdicionar = new Produto();
            produtoParaAdicionar.Codigo = 2;
            produtoParaAdicionar.DataValidade = System.DateTime.Now.AddDays(6);
            produtoParaAdicionar.Preco = 30;
            produtoParaAdicionar.Nome = "Produto 2";

            // action
            var adicionouOProduto = estoque.AdicionarProduto(produtoParaAdicionar);

            // assert
            Assert.IsTrue(adicionouOProduto);

            var produtoFoiAdicionado = estoque.ListaProdutos.Contains(produtoParaAdicionar);
            Assert.IsTrue(produtoFoiAdicionado);
        }
    }
}