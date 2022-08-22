using System;
using System.Collections.Generic;
using MercadoSeuZe.ClassLib;

namespace MercadoSeuZe
{
    public static class SystemActions
    {
        private static string _userInput;

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========  Selecionar Menu ========");
            Console.WriteLine("[1] Produtos");
            Console.WriteLine("[2] Clientes");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("===================================\n");
        }

        public static void AskForInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }

        public static void ChooseOption()
        {
            switch (_userInput)
            {
                case "1":
                    ProductActions.Run();
                    break;
                case "2":
                    ClientActions.Run();
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

        public static void RunProgram()
        {
            while (true)
            {
                Menu();
                AskForInput();
                ChooseOption();
            }
        }
    }
}
