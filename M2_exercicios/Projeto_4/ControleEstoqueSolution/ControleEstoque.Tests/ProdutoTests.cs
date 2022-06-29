using ControleEstoque.Excecoes;
using NUnit.Framework;

namespace ControleEstoque.Tests
{
    public class ProdutoTests
    {
        [Test]
        public void AcrescentarQuantidade_Add5FromInitial20_Returns25()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 20;
            Produto product = new Produto(name, description, quantity);

            // act
            int result = product.AcrescentarQuantidade(5);

            // assert
            Assert.AreEqual(25, result);
        }

        [Test]
        public void AcrescentarQuantidade_Add0FromInitial20_ThrowsQuantidadeMenorOuIgualAZeroException()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 20;
            Produto product = new Produto(name, description, quantity);

            // act
            QuantidadeMenorOuIgualAZeroException ex = Assert.Throws<QuantidadeMenorOuIgualAZeroException>(() => product.AcrescentarQuantidade(0));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Quantidade de itens deve ser maior que zero"));
            Assert.AreEqual(20, product.QuantidadeEmEstoque);
        }

        [Test]
        public void AcrescentarQuantidade_AddMinus5FromInitial20_ThrowsQuantidadeMenorOuIgualAZeroException()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 20;
            Produto product = new Produto(name, description, quantity);

            // act
            QuantidadeMenorOuIgualAZeroException ex = Assert.Throws<QuantidadeMenorOuIgualAZeroException>(() => product.AcrescentarQuantidade(-5));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Quantidade de itens deve ser maior que zero"));
            Assert.AreEqual(20, product.QuantidadeEmEstoque);
        }

        [Test]
        public void DeduzirQuantidade_Remove5FromInitial20_Returns15()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 20;
            Produto product = new Produto(name, description, quantity);

            // act
            int result = product.DeduzirQuantidade(5);

            // assert
            Assert.AreEqual(15, result);
        }

        [Test]
        public void DeduzirQuantidade_Remove0FromInitial20_ThrowsQuantidadeMenorOuIgualAZeroException()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 20;
            Produto product = new Produto(name, description, quantity);

            // act
            QuantidadeMenorOuIgualAZeroException ex = Assert.Throws<QuantidadeMenorOuIgualAZeroException>(() => product.DeduzirQuantidade(0));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Quantidade de itens deve ser maior que zero"));
            Assert.AreEqual(20, product.QuantidadeEmEstoque);
        }

        [Test]
        public void DeduzirQuantidade_RemoveMinus5FromInitial20_ThrowsQuantidadeMenorOuIgualAZeroException()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 20;
            Produto product = new Produto(name, description, quantity);

            // act
            QuantidadeMenorOuIgualAZeroException ex = Assert.Throws<QuantidadeMenorOuIgualAZeroException>(() => product.DeduzirQuantidade(-5));

            // assert
            Assert.That(ex.Message, Is.EqualTo("Quantidade de itens deve ser maior que zero"));
            Assert.AreEqual(20, product.QuantidadeEmEstoque);
        }

        [Test]
        public void DeduzirQuantidade_Remove6FromInitial5_Returns0()
        {
            // arrange
            string name = "A";
            string description = "";
            int quantity = 5;
            Produto product = new Produto(name, description, quantity);

            // act
            int result = product.DeduzirQuantidade(6);

            // assert
            Assert.AreEqual(0, result);
        }
    }
}