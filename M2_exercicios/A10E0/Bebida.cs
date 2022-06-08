namespace A10E1
{
    public class Bebida : ItemDoCardapio
    {
        public Bebida(int codigo, string nome, string descricao, double preco) : base(codigo, nome, descricao, preco)
        {
            Desconto = 0.05;
        }

        public override void ImprimirDesconto2()
        {
            System.Console.WriteLine($"Desconto de R$ {0.05 * Preco} aplicado!");
        }
    }
}