using System;

namespace ControleEstoque.Excecoes
{
    public class NomeNaoPodeSerNuloException : Exception
    {
        public NomeNaoPodeSerNuloException() : base("Nome não pode ser vazio")
        {
        }
    }
}