using System;
using System.Runtime.Serialization;

namespace ControleEstoque.Excecoes
{
    public class QuantidadeMenorOuIgualAZeroException : Exception
    {
        public QuantidadeMenorOuIgualAZeroException() : base("Quantidade de itens deve ser maior que zero")
        {
        }
    }
}