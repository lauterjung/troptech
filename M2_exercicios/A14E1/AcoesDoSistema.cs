namespace A14
{
    public static class AcoesDoSistema
    {
        private static string _userInput;
        private static List<Conta> listaContas = new List<Conta>();

        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar Conta");
            Console.WriteLine("[2] Exibir todos as Contas");
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
                    CadastraConta();
                    break;
                case "2":
                    ListaContas();
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

        public static void ListaContas()
        {
            if (listaContas.Count != 0)
            {
                foreach (Conta conta in listaContas)
                {
                    Console.WriteLine(conta);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
            }
            Console.ReadKey();
        }

        public static void CadastraConta()
        {
            Console.Clear();
            Conta conta = new Conta();

            Console.Write("Digite a agência: ");
            conta.Agencia = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o número: ");
            conta.Numero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Digite o nome do cliente:" );
            conta.Nome = Console.ReadLine();
            Console.Write("Digite o CPF: ");
            conta.Cpf = Console.ReadLine();
            Console.Write("Digite o tipo da conta: ");
            conta.TipoConta = (Conta.Tipo)Convert.ToInt32(Console.ReadLine());

            bool contaIsValid = conta.Validate();

            if (contaIsValid)
            {
                listaContas.Add(conta);
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