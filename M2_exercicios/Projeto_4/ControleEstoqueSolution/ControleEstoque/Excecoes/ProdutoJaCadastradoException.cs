using System;
using System.Runtime.Serialization;

namespace ControleEstoque.Excecoes
{
    public class ProdutoJaCadastradoException : Exception
    {
        public ProdutoJaCadastradoException() : base("Produto já existe no estoque")
        {
        }
    }
}