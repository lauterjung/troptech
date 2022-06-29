using ControleEstoque.Excecoes;
using System;

namespace ControleEstoque
{
    public class Produto
    {
        private static int _contadorId;

        private int _id;
        private string _nome;
        private string _descricao;

        private int _quantidadeEmEstoque;

        public int Id { get => _id; }
        public string Nome { get => _nome; }
        public int QuantidadeEmEstoque { get => _quantidadeEmEstoque; }

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

        public int DefineId()
        {
            _id = _contadorId++;
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
                _quantidadeEmEstoque = 0;

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