namespace MiguelBusarelloLauterjungM2P3
{
    public class SystemActions
    {
        private static string _userInput;
        private static List<Email> emailList = new List<Email>();

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("========  Selecionar Conta ========");
            Console.WriteLine("[1] Aluno");
            Console.WriteLine("[2] Professor");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("===================================\n");
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
                    StudentActions.RunMenu();
                    break;
                case "2":
                    ProfessorActions.RunMenu();
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