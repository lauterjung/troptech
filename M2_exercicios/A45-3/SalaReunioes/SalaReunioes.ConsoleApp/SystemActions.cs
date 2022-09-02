using System;

namespace SalaReunioes.ConsoleApp
{
    public static class SystemActions
    {
        private static string _userInput;

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========  SELECIONAR MENU ========");
            Console.WriteLine("[1] Salas");
            Console.WriteLine("[2] Reservas");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("===================================\n");

            AskForInput();
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();

            ChooseOption();
        }

        public static void ChooseOption()
        {
            switch (_userInput)
            {
                case "1":
                    RoomActions.Menu();
                    break;
                case "2":
                    ReservationActions.Menu();
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();

            Menu();
        }

        public static void Run()
        {
            Menu();
        }
    }
}

