namespace MiguelBusarelloLauterjungM2P3
{
    public static class StudentActions
    {
        private static string _userInput;
        public static List<QuestionEmail> questionEmails = new List<QuestionEmail>();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Enviar e-mail de dúvida");
            Console.WriteLine("[2] Listar e-mails");
            Console.WriteLine("[0] Voltar");
            Console.WriteLine("============================\n");
        }
        public static void AskInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }
        public static void MenuChoice()
        {
            switch (_userInput)
            {
                case "1":
                    SendQuestionEmail();
                    break;
                case "2":
                    ViewEmails();
                    break;
                case "0":
                    SystemActions.RunMenu();
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }
        public static void SendQuestionEmail()
        {
            Console.WriteLine("Digite sua dúvida: ");
            string message = Console.ReadLine();

            QuestionEmail email = new QuestionEmail(message);
            questionEmails.Add(email);
            Console.WriteLine("E-mail enviado com sucesso!");
        }
        public static void ViewEmails()
        {
            Console.Clear();

            if (questionEmails.Count() == 0)
            {
                Console.WriteLine("Não existem e-mails!");
            }

            else
            {
                foreach (QuestionEmail item in questionEmails.OrderByDescending(x => x.ID))
                {
                    if (item.IsAnswered)
                    {
                        item.Answer.Show();
                        Console.WriteLine();
                    }
                    item.Show();
                    Console.WriteLine();
                }
            }
        }
        public static void RunMenu()
        {
            while (true)
            {
                Menu();
                AskInput();
                MenuChoice();
            }
        }
    }
}