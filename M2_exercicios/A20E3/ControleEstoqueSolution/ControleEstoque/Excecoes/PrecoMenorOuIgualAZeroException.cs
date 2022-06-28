using System;
using System.Runtime.Serialization;

namespace ControleEstoque.Excecoes
{
    public class PrecoMenorOuIgualAZeroException : Exception
    {
        public PrecoMenorOuIgualAZeroException() : base("Preço deve ser maior que zero")
        {
        }
    }
}