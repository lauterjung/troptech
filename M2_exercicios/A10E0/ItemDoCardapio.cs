namespace A10E1
{
    public class ItemDoCardapio
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public double Desconto { get; set; }

        public ItemDoCardapio(int codigo, string nome, string descricao, double preco)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Desconto = 0.07;
        }
        public void ImprimirDesconto()
        {
            System.Console.WriteLine($"Desconto de R$ {Desconto * Preco} aplicado!");
        }
        public virtual void ImprimirDesconto2()
        {
            System.Console.WriteLine($"Desconto de R$ {0.07 * Preco} aplicado!");
        }
    }
}