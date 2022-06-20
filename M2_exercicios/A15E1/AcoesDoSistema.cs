namespace A15
{
    public static class AcoesDoSistema
    {
        private static string _userInput;
        private static List<Solicitacao> listaSolicitacoes = new List<Solicitacao>();
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar Solicitacao");
            Console.WriteLine("[2] Listar Solicitações");
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
                    CadastrarSolicitacao();
                    break;
                case "2":
                    ListarSolicitacoes();
                    break;
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();
        }

        public static void ListarSolicitacoes()
        {
            Console.Clear();
            if (listaSolicitacoes.Count != 0)
            {
                listaSolicitacoes.OrderBy(x => x.DataAbertura);
                foreach (Solicitacao item in listaSolicitacoes)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nenhuma solicitação registrada!");
            }
        }
        public static void CadastrarSolicitacao()
        {
            Console.Clear();
            Solicitacao solicitacao = new Solicitacao();

            Console.WriteLine("Digite a categoria:");
            solicitacao.Categoria = Console.ReadLine();
            Console.WriteLine("Digite a subcategoria:");
            solicitacao.Subcategoria = Console.ReadLine();
            Console.WriteLine("Digite a descrição:");
            solicitacao.Descricao = Console.ReadLine();
            Console.WriteLine("Digite o Data: (dd/mm/yyyy)");
            solicitacao.DataAbertura = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome:");
            solicitacao.Autor = Console.ReadLine();

            bool isValidSolicitacao = solicitacao.Validar();

            try
            {
                if (isValidSolicitacao)
                {
                    listaSolicitacoes.Add(solicitacao);
                }
            }
            catch (SolicitacaoException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void RodarPrograma()
        {
            while (true)
            {
                ChamarMenu();
                PedirInput();
                RealizarEscolha();
            }
        }
    }
}