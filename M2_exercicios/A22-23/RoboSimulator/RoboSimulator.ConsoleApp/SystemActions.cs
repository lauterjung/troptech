using RoboSimulator.Library;
using RoboSimulator.Library.Exceptions;

namespace RoboSimulator.ConsoleApp
{
    public static class SystemActions
    {
        private static string _userInput;
        private static RobotFactory _factory = new RobotFactory();
        public static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar robô");
            Console.WriteLine("[2] Mover robô");
            Console.WriteLine("[3] Destruir robô");
            Console.WriteLine("[4] Listar robôs");
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
                    RegisterRobot();
                    break;
                case "2":
                    MoveRobot();
                    break;
                case "3":
                    RemoveRobot();
                    break;
                case "4":
                    ListRobots();
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

        private static void RegisterRobot()
        {
            Console.WriteLine("Qual tipo de robô você deseja criar?\n" +
                              "[0] Pequeno\n" +
                              "[1] Médio\n" +
                              "[2] Grande");
            var type = Convert.ToInt32(Console.ReadLine());

            try
            {
                _factory.CreateRobot((RobotType)type);

                if (type == 1)
                {
                    return;
                }

                Console.WriteLine("Robô cadastrado com sucesso!");
            }
            catch (InvalidTypeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MoveRobot()
        {
            int input;
            ListRobots();
            Console.WriteLine();
            Console.WriteLine("Qual robô você deseja mover?");

            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                System.Console.WriteLine("Input não é número!");
                return;
            }

            Robot searchedRobot = new Robot("");

            try
            {
                searchedRobot = _factory.RobotList[input - 1];
            }
            catch (Exception)
            {
                System.Console.WriteLine("Índice inexistente!");
                return;
            }

            Console.WriteLine("Quais as instruções?");
            string instructions = Console.ReadLine();
            try
            {
                searchedRobot.Move(instructions);
                Console.WriteLine("Robô movido com sucesso!");
            }
            catch (MoveRobotException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RemoveRobot()
        {
            ListRobots();
            Console.WriteLine();
            Console.WriteLine("Qual robô você deseja destruir?");
            string name = Console.ReadLine();

            try
            {
                _factory.DestroyRobot(name);
                Console.WriteLine("Robô destruído com sucesso!");
            }
            catch (InexistingRobotException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListRobots()
        {
            Console.WriteLine("======== Robôs criados ========");
            foreach (Robot robot in _factory.RobotList)
            {
                Console.Write($"ID: {_factory.RobotList.IndexOf(robot) + 1} | ");
                Console.WriteLine(robot.ToString());
            };
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