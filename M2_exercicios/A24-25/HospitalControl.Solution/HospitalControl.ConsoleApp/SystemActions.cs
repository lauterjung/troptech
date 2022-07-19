using HospitalControl;
using HospitalControl.Exceptions;

namespace HospitalControl.ConsoleApp
{
    public static class SystemActions
    {
        private static string _userInput;
        private static HospitalControl _hospitalControl = new HospitalControl();
        // private static HospitalTeam _hospitalControl.HospitalTeam = new HospitalTeam();
        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar colaborador");
            Console.WriteLine("[2] Remover colaborador");
            Console.WriteLine("[3] Informar horas trabalhadas");
            Console.WriteLine("[4] Pagar colaboradores");
            Console.WriteLine("[5] Exibir salários pagos");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("============================\n");
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
            Console.Clear();
        }

        public static void DoOperation()
        {
            switch (_userInput)
            {
                case "1":
                    RegisterMember();
                    break;
                case "2":
                    RemoveMember();
                    break;
                case "3":
                    InformWorkedHours();
                    break;
                case "4":
                    MakePayments();
                    break;
                case "5":
                    ShowPayments();
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

        private static void RegisterMember()
        {
            Console.Write("Informe a identificação do colaborador: ");
            string identification = Console.ReadLine();

            Console.WriteLine("Qual tipo de membro você deseja cadastrar?\n" +
                              "[0] Administrador(a)\n" +
                              "[1] Médico(a)\n" +
                              "[2] Enfermeiro(a)" +
                              "[3] Contratado(a)");
            string type = Console.ReadLine();

            try
            {
                switch (type)
                {
                    case "0":
                        Admin admin = new Admin(identification);
                        _hospitalControl.HospitalPayable.AddMember(admin);
                        break;
                    case "1":
                        Medic medic = new Medic(identification);
                        _hospitalControl.HospitalPayable.AddMember(medic);
                        break;
                    case "2":
                        Nurse nurse = new Nurse(identification);
                        _hospitalControl.HospitalPayable.AddMember(nurse);
                        break;
                    case "3":
                        Nurse nurse = new Nurse(identification);
                        _hospitalControl.HospitalPayable.AddMember(nurse);
                        break;
                    default:
                        Console.WriteLine("Não entendi o comando. Pressione qualquer tecla para continuar...");
                        Console.ReadLine();
                        return;
                }
                Console.WriteLine("Membro adicionado com sucesso!");
            }
            catch (InvalidSearchException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveMember()
        {
            Console.WriteLine("Qual colaborador deseja remover?");
            string name = Console.ReadLine();

            try
            {
                _hospitalControl.HospitalPayable.RemoveMember(name);
                Console.WriteLine("Membro removido com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void InformWorkedHours()
        {
            Console.Write("Digite a identificação do membro: ");
            string identification = Console.ReadLine();

            try
            {
                _hospitalControl.HospitalPayable.SearchMember(identification);
            }
            catch (NegativeHoursException e)
            {
                Console.WriteLine(e.Message);
                return;
            }


            Console.Write("Digite o número de horas trabalhadas: ");
            int workedHours = Convert.ToInt32(Console.ReadLine());

            try
            {
                _hospitalControl.InformHours(identification, workedHours);
                Console.WriteLine("Horas registradas com sucesso!");
                Console.ReadKey();
            }
            catch (NegativeHoursException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (LimitHoursException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        private static void MakePayments()
        {
            _hospitalControl.MakePayments();
            Console.WriteLine("Pagamentos realizados com sucesso!");
            Console.ReadKey();
        }

        private static void ShowPayments()
        {
            Console.Write("Digite a identificação do membro: ");
            var identification = Console.ReadLine();

            try
            {
                _hospitalControl.HospitalPayable.SearchMember(identification);
                Console.WriteLine("Salários pagos:");
                foreach (Payments payment in _hospitalControl.ShowPayments(identification))
                {
                    System.Console.WriteLine(payment.ToString());
                }
            }
            catch (InvalidSearchException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void RunProgram()
        {
            while (true)
            {
                StartMenu();
                AskForInput();
                DoOperation();
            }
        }
    }
}