using ControlePonto.ClassLibs;

namespace ControlePonto.ConsoleApp
{
    public class AcoesDoSistema
    {
        private static string _userInput;
        private static List<Funcionario> funcionariosList = new List<Funcionario>();
        private static List<Ponto> pontosList = new List<Ponto>();

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("[1] Cadastrar Funcionário");
            Console.WriteLine("[2] Listar Funcionários");
            Console.WriteLine("[3] Bater Ponto");
            Console.WriteLine("[4] Listar Pontos");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("==========================\n");
        }
        public static void AskInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }
        public static void MainMenuChoice()
        {
            switch (_userInput)
            {
                case "1":
                    CadastrarFuncionario();
                    break;
                case "2":
                    ListarFuncionarios();
                    break;
                case "3":
                    BaterPonto();
                    break;
                case "4":
                    ListarPontos();
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

        public static void CadastrarFuncionario()
        {
            Funcionario funcionario = new Funcionario();

            System.Console.Write("Digite o nome: ");
            funcionario.Nome = Console.ReadLine();
            System.Console.Write("Digite a função: ");
            funcionario.Funcao = Console.ReadLine();
            System.Console.Write("Digite a idade: ");
            funcionario.Idade = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (funcionario.Validar())
                {
                    funcionariosList.Add(funcionario);
                    System.Console.WriteLine("Funcionário cadastrado!");
                }
            }
            catch (FuncionarioException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static void ListarFuncionarios()
        {
            if (funcionariosList.Count > 0)
            {
                foreach (Funcionario item in funcionariosList)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
            else
            {
                System.Console.WriteLine("Sem funcionários registrados!");
            }
        }
        public static void BaterPonto()
        {
            Ponto ponto = new Ponto();

            System.Console.Write("Digite a data: ");
            ponto.Data = Convert.ToDateTime(Console.ReadLine());
            System.Console.Write("Digite a hora: ");
            ponto.Hora = Console.ReadLine();
            System.Console.Write("Digite o tipo (0 - Entrada | 1 - Saída): ");
            ponto.Tipo = (Ponto.TipoPonto)Convert.ToInt32(Console.ReadLine());

            System.Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();
            Funcionario funcionario = new Funcionario();

            if (funcionariosList.Any(x => x.Nome == nome))
            {
                funcionario = AcharFuncionario(nome, funcionariosList);
            }
            else
            {
                System.Console.WriteLine("Funcionário não encontrado!");
                funcionario = null;
            }

            ponto.Funcionario = funcionario;

            try
            {
                if (ponto.Validar())
                {
                    pontosList.Add(ponto);
                    System.Console.WriteLine("Ponto batido!");
                }
            }
            catch (PontoException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
        public static Funcionario AcharFuncionario(string nome, List<Funcionario> funcionariosList)
        {
            Funcionario funcionario = new Funcionario();
            foreach (Funcionario item in funcionariosList)
            {
                if (nome == item.Nome)
                {
                    funcionario = item;
                }
            }
            return funcionario;
        }
        public static void ListarPontos()
        {
            if (pontosList.Count > 0)
            {
                foreach (Ponto item in pontosList)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
            else
            {
                System.Console.WriteLine("Sem pontos registrados!");
            }
        }
        public static void RunMenu()
        {
            while (true)
            {
                MainMenu();
                AskInput();
                MainMenuChoice();
            }
        }
    }
}
