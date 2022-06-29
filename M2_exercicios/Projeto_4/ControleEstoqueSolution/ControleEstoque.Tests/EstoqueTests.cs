using System.Collections.Generic;
using ControleEstoque;
using ControleEstoque.Excecoes;
using NUnit.Framework;

namespace ControleEstoque.Tests
{
    public class EstoqueTests
    {
        [Test]
        public void CadastrarProdutoNoEstoque_AddNewProduct_ProductSuccessfullyAdded()
        {
            // arrange
            string name = "A";
            string description = "";
            Produto product = new Produto(name, description);
            Estoque inventory = new Estoque();
            List<Produto> expected = new List<Produto>();
            expected.Add(product);

            // act
            Produto result = inventory.CadastrarProdutoNoEstoque(name, description);

            // assert
            Assert.AreEqual(product, result);
            CollectionAssert.AreEqual(expected, inventory.Produtos);
        }

        [Test]
        public void CadastrarProdutoNoEstoque_AddExistingProduct_ThrowsProdutoJaCadastradoException()
        {
            // arrange
            string name = "A";
            string description = "";
            Produto product = new Produto(name, description);
            List<Produto> startingList = new List<Produto>() { product };
            Estoque inventory = new Estoque(startingList);

            // act
            ProdutoJaCadastradoException ex = Assert.Throws<ProdutoJaCadastradoException>(() => inventory.CadastrarProdutoNoEstoque(name, description));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Produto já existe no estoque"));
            CollectionAssert.AreEqual(startingList, inventory.Produtos);
        }

        [Test]
        public void RegistrarEntradaDeProduto_AddToInexistingProduct_ThrowsProdutoNaoEncontradoException()
        {
            // arrange
            int productId = 0;
            int quantityToAdd = 1;
            Estoque inventory = new Estoque();

            // act
            ProdutoNaoEncontradoException ex = Assert.Throws<ProdutoNaoEncontradoException>(() => inventory.RegistrarEntradaDeProduto(productId, quantityToAdd));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Produto não cadastrado no estoque"));
        }

        [Test]
        public void RegistrarEntradaDeProduto_Add5ToExistingProduct_IncrementsValueBy5()
        {
            // arrange
            string name = "A";
            string description = "";
            int productId = 0;
            int quantityToAdd = 5;
            Estoque inventory = new Estoque();
            inventory.CadastrarProdutoNoEstoque(name, description); // dependency

            // act
            Produto product = inventory.RegistrarEntradaDeProduto(productId, quantityToAdd);

            // assert
            Assert.AreEqual(5, product.QuantidadeEmEstoque);
        }

        [Test]
        public void RegistrarSaidaDeProduto_RemoveFromInexistingProduct_ThrowsProdutoNaoEncontradoException()
        {
            // arrange
            int productId = 0;
            int quantityToRemove = 1;
            Estoque inventory = new Estoque();

            // act
            ProdutoNaoEncontradoException ex = Assert.Throws<ProdutoNaoEncontradoException>(() => inventory.RegistrarSaidaDeProduto(productId, quantityToRemove));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Produto não cadastrado no estoque"));
        }

        [Test]
        public void RegistrarSaidaDeProduto_Remove5FromExistingProductWithQuantity5_ReducesValueBy5()
        {
            // arrange
            string name = "A";
            string description = "";
            int productId = 0;
            int quantityToAdd = 5;
            int quantityToRemove = 5;
            Estoque inventory = new Estoque();
            inventory.CadastrarProdutoNoEstoque(name, description); // dependency
            Produto product = inventory.RegistrarEntradaDeProduto(productId, quantityToAdd); // dependency

            // act
            product = inventory.RegistrarSaidaDeProduto(productId, quantityToRemove);

            // assert
            Assert.AreEqual(0, product.QuantidadeEmEstoque);
        }

        [Test]
        public void HaProdutosEmEstoque_ZeroProducts_ReturnsFalse()
        {
            // arrange
            Estoque inventory = new Estoque();

            // act
            bool result = inventory.HaProdutosEmEstoque();

            // assert
            Assert.False(result);
        }

        [Test]
        public void HaProdutosEmEstoque_MoreThan0Products_ReturnsTrue()
        {
            // arrange
            string name = "A";
            string description = "";
            int productId = 0;
            int quantityToAdd = 1;
            Estoque inventory = new Estoque();
            inventory.CadastrarProdutoNoEstoque(name, description); // dependency
            Produto product = inventory.RegistrarEntradaDeProduto(productId, quantityToAdd); // dependency

            // act
            bool result = inventory.HaProdutosEmEstoque();

            // assert
            Assert.True(result);
        }
    }
}