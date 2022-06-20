namespace MiguelBusarelloLauterjungM2P3
{
    public class ProfessorActions
    {
        private static string _userInput;
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Ver dúvidas");
            Console.WriteLine("[2] Responder dúvida");
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
                    ViewEmails();
                    break;
                case "2":
                    SendAnswerEmail(); // only if there is
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
        public static void ViewEmails()
        {
            Console.Clear();

            if (StudentActions.questionEmails.Count() == 0 || StudentActions.questionEmails.All(x => x.IsAnswered == true))
            {
                Console.WriteLine("Não existem e-mails!");
            }

            foreach (QuestionEmail item in StudentActions.questionEmails.OrderByDescending(x => x.ID))
            {
                if (!item.IsAnswered)
                {
                    item.Show();
                    Console.WriteLine();
                }
            }
        }
        public static bool isValidId(int inputId)
        {
            if (StudentActions.questionEmails.Any(x => x.ID == inputId))
            {
                return true;
            }
            return false;
        }
        public static void AddAnswer(int inputId, List<QuestionEmail> questionEmails)
        {
            Console.WriteLine($"Digite a resposta para o e-mail {inputId}:");
            string answer = Console.ReadLine();
            AnswerEmail answerEmail = new AnswerEmail(answer);
            answerEmail.QuestionID = inputId;

            foreach (QuestionEmail item in questionEmails)
            {
                if (item.ID == inputId)
                {
                    item.Answer = answerEmail;
                    item.IsAnswered = true;
                    answerEmail.Question = item;
                }
            }
            Console.WriteLine("E-mail respondido com sucesso!");
        }
        public static void SendAnswerEmail()
        {
            Console.Clear();

            if (StudentActions.questionEmails.Count() == 0 || StudentActions.questionEmails.All(x => x.IsAnswered == true))
            {
                Console.WriteLine("Não existem e-mails!");
                return;
            }

            Console.Write("Digite o ID do e-mail a ser respondido: ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            if (isValidId(inputId))
            {
                AddAnswer(inputId, StudentActions.questionEmails);
            }
            else
            {
                System.Console.WriteLine("E-mail inválido!");
                return;
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