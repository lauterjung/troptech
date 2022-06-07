namespace MiguelBusarelloLauterjungM2P2
{
    public static class AcoesDoSistema
    {
        private static string _userInput;
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar Cliente");
            Console.WriteLine("[2] Exibir todos os Clientes");
            Console.WriteLine("[3] Pesquisar Cliente");
            Console.WriteLine("[4] Remover Cliente");
            Console.WriteLine("[5] Cadastrar Venda");
            Console.WriteLine("[6] Exibir todas as Vendas");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("============================\n");
        }

        public static void PedirInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }

        public static void RealizarEscolha()
        {
            switch (_userInput)
            {
                case "1":
                    AcoesCliente.CadastrarCliente();
                    break;
                case "2":
                    AcoesCliente.ExibirClientes(false); // pesquisa = false
                    break;
                case "3":
                    AcoesCliente.ExibirClientes(true); // pesquisa = true
                    break;
                case "4":
                    AcoesCliente.RemoverCliente();
                    break;
                case "5":
                    AcoesVenda.CadastrarVenda();
                    break;
                case "6":
                    AcoesVenda.ExibirVendas();
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }

        public static void RodarPrograma()
        {
            ChamarMenu();
            PedirInput();
            RealizarEscolha();
        }
    }
}