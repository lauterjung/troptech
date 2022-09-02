using System;
using System.Collections.Generic;
using SalaReunioes.Domain;
using SalaReunioes.Domain.Exceptions;
using SalaReunioes.Infra.Data;

namespace SalaReunioes.ConsoleApp
{
    public static class RoomActions
    {
        private static string _userInput;
        private static RoomRepository _roomRepository = new RoomRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========== SALAS ==========");
            Console.WriteLine("[1] Pesquisar todas as Salas");
            Console.WriteLine("[0] Voltar");
            Console.WriteLine("============================\n");

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
            Console.Clear();
            switch (_userInput)
            {
                case "1":
                    SearchAllRooms();
                    break;
                case "0":
                    _userInput = "";
                    SystemActions.Menu();
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();

            Menu();
        }

        public static void SearchAllRooms()
        {
            try
            {
                List<Room> roomList = new List<Room>();
                roomList = _roomRepository.SearchAllRooms();
                Console.Clear();

                foreach (Room Room in roomList)
                {
                    System.Console.WriteLine(Room.ToString());
                }
            }
            catch (ZeroRoomsRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}
