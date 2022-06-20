namespace A14E2
{
    public static class AcoesDoSistema
    {
        private static string _userInput;
        private static Estoque estoque = new Estoque();

        public static void InserirDados()
        {
            while (!estoque.Validar())
            {
                Console.WriteLine("Digite o nome do estabelecimento:");
                estoque.Estabelecimento = Console.ReadLine();
                Console.WriteLine("Digite o nome do gerente:");
                estoque.Gerente = Console.ReadLine();
            }
        }
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Adicionar produto no estoque");
            Console.WriteLine("[2] Quantidade de produtos no estoque");
            Console.WriteLine("[3] Listar produtos do estoque");
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
                    CadastrarProduto();
                    break;
                case "2":
                    Console.WriteLine($"Quantidade: {estoque.QtdProdutos}");
                    break;
                case "3":
                    ListarProdutos();
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

        public static void ListarProdutos()
        {
            if (estoque.ListaProdutos.Count != 0)
            {
                Console.WriteLine(estoque);
            }
            else
            {
                Console.WriteLine("Nenhuma produto no estoque!");
            }
        }

        public static void CadastrarProduto()
        {
            Console.Clear();
            Produto produto = new Produto();

            Console.WriteLine("Digite o código:");
            produto.Codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o nome:");
            produto.Nome = Console.ReadLine();
            Console.WriteLine("Digite o preço:");
            produto.Preco = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Digite o Data: (dd/mm/yyyy)");
            produto.Validade = DateTime.Parse(Console.ReadLine());

            bool isValidProduto = produto.Validar();
            bool produtoNaoExiste = estoque.VerificarProduto(produto);

            if (isValidProduto && produtoNaoExiste)
            {
                estoque.AdicionarProduto(produto);
            }
        }
        public static void RodarPrograma()
        {
            InserirDados();
            while (true)
            {
                ChamarMenu();
                PedirInput();
                RealizarEscolha();
            }
        }
    }
}