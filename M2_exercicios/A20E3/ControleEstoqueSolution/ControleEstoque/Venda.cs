using System;

namespace ControleEstoque
{
    public class Venda
    {
        private Produto _produto;
        public Produto Produto { get => _produto; }
        private int _quantidade;
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }
        private double _precoTotal;
        public double PrecoTotal
        {
            get { return _precoTotal; }
            set { _precoTotal = value; }
        }
        
        
        public Venda(Produto produto)
        {
            _produto = produto;
            _quantidade = 1;
            _precoTotal = Math.Round(produto.Preco, 2);
            
        }
        public Venda(Produto produto, int quantidade) : this(produto)
        {
            _quantidade = quantidade;
            _precoTotal = Math.Round(produto.Preco * quantidade, 2);
        }
    }
}