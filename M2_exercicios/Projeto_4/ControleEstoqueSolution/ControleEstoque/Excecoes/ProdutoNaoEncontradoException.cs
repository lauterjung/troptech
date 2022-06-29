using System;
using System.Runtime.Serialization;

namespace ControleEstoque.Excecoes
{
    public class ProdutoNaoEncontradoException : Exception
    {
        public ProdutoNaoEncontradoException() : base("Produto não cadastrado no estoque")
        {
        }
    }
}