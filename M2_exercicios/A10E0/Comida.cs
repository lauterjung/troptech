using System.Collections;

namespace A10E1
{
    public class Comida : ItemDoCardapio
    {
        public Comida(int codigo, string nome, string descricao, double preco) : base(codigo, nome, descricao, preco)
        {
            Desconto = 0.1;
        }

        public override void ImprimirDesconto2()
        {
            System.Console.WriteLine($"Desconto de R$ {0.1 * Preco} aplicado!");
        }
    }
}
