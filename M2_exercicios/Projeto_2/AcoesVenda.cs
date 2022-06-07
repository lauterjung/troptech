namespace MiguelBusarelloLauterjungM2P2
{
    public static class AcoesVenda
    {
        public static List<Venda> listaVendas = new List<Venda>();

        public static void CadastrarVenda()
        {
            Console.Clear();
            Cliente cliente;
            System.Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            string tipoCliente = AcoesCliente.PerguntarTipoPessoa();

            if (tipoCliente == "F")
            {
                if (!AcoesCliente.PesquisarClienteFisico(nomeCliente).Any(x => x.Nome == nomeCliente))
                {
                    System.Console.WriteLine("Cliente não existente!");
                    return;
                }
                else
                {
                    cliente = AcoesCliente.PesquisarClienteFisico(nomeCliente)[0];
                }
            }
            else
            {
                if (!AcoesCliente.PesquisarClienteJuridico(nomeCliente).Any(x => x.Nome == nomeCliente))
                {
                    System.Console.WriteLine("Cliente não existente!");
                    return;
                }
                else
                {
                    cliente = AcoesCliente.PesquisarClienteJuridico(nomeCliente)[0];
                }
            }

            System.Console.Write("Digite a descrição da venda: ");
            string descricao = Console.ReadLine();
            System.Console.Write("Digite o valor total da venda: ");
            decimal valorTotal = Convert.ToDecimal(Console.ReadLine());

            Venda venda = new Venda(cliente);
            listaVendas.Add(venda);
            System.Console.WriteLine("Venda cadastrada com sucesso!");
        }
        public static void ExibirVendas(bool isPesquisa = false)
        {
            Console.Clear();
            System.Console.WriteLine("VENDAS");
            foreach (Venda venda in listaVendas)
            {
                System.Console.WriteLine("--------------------------");
                System.Console.WriteLine(venda.ToString());
            }
        }
    }
}
