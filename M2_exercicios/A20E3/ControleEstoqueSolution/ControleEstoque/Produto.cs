using ControleEstoque.Excecoes;
using System;

namespace ControleEstoque
{
    public class Produto
    {
        private int _id;
        private string _nome;
        private string _descricao;
        private int _quantidadeEmEstoque;
        private double _preco;

        public int Id { get => _id; }
        public string Nome { get => _nome; }
        public int QuantidadeEmEstoque { get => _quantidadeEmEstoque; }
        public double Preco {get => _preco; }

        public Produto(string nome, string descricao)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new NomeNaoPodeSerNuloException();

            _nome = nome;

            _descricao = descricao == string.Empty ? "(sem descrição)" : descricao;
            _quantidadeEmEstoque = 0;
        }

        public Produto(string nome, string descricao, int quantidadeEmEstoque) : this(nome, descricao)
        {
            if (quantidadeEmEstoque <= 0)
                throw new QuantidadeMenorOuIgualAZeroException();

            _quantidadeEmEstoque = quantidadeEmEstoque;
        }
        public Produto(string nome, string descricao, int quantidadeEmEstoque, double preco) : this(nome, descricao, quantidadeEmEstoque)
        {
            if (preco <= 0)
                throw new PrecoMenorOuIgualAZeroException();

            _preco = preco;
        }

        public int DefineId(int contador)
        {
            _id = contador;
            return _id;
        }

        /// <summary>
        /// Acrescenta o valor passado por parâmetro à quantidade de itens
        /// </summary>
        /// <param name="quantidade">Quantidade que será acrescentada</param>
        /// <returns>Retornar a quantidade de itens do produto após acréscimo</returns>
        public int AcrescentarQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new QuantidadeMenorOuIgualAZeroException();

            _quantidadeEmEstoque += quantidade;

            return _quantidadeEmEstoque;
        }

        /// <summary>
        /// Deduz o valor passado por parâmetro da quantidade de itens
        /// </summary>
        /// <param name="quantidade">Quantidade que será deduzida</param>
        /// <returns>Retornar a quantidade de itens do produto após dedução</returns>
        public int DeduzirQuantidade(int quantidade)
        {
            if (quantidade <= 0)
                throw new QuantidadeMenorOuIgualAZeroException();

            var resultado = _quantidadeEmEstoque - quantidade;

            if (resultado >= 0)
                _quantidadeEmEstoque = resultado;
            else
                throw new EstoqueInsuficienteException();

            return _quantidadeEmEstoque;
        }

        public override bool Equals(object obj)
        {
            if (obj is Produto)
            {
                var produto = (Produto)obj;

                return produto._nome == _nome;
            }

            return false;
        }

        public bool Equals(int codigoProduto)
        {
            return _id == codigoProduto;
        }

        public override string ToString()
        {
            return $"Cód. {_id} / Nome: {_nome} / Descrição: {_descricao} / Quantidade: {_quantidadeEmEstoque}";
        }

    }
}