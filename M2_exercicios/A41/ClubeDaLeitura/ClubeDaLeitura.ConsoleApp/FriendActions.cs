using System;
using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Infra.Data;

namespace ClubeDaLeitura
{
    public static class FriendActions
    {
        private static string _userInput;
        private static FriendDAO _friendDAO = new FriendDAO();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========== AMIGOS ==========");
            Console.WriteLine("[1] Cadastrar Amigo");
            Console.WriteLine("[2] Buscar todas as Amigos");
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
                    AddFriend();
                    break;
                case "2":
                    SearchAllAddFriends();
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

        public static void AddFriend()
        {
            try
            {
                System.Console.Write("Digite o nome: ");
                string name = Console.ReadLine();
                System.Console.Write("Digite o nome da mãe: ");
                string motherName = Console.ReadLine();
                System.Console.Write("Digite o telefone: ");
                string phone = Console.ReadLine();
                System.Console.Write("Digite 0 se o amigo é da escola e 1 se é do prédio: ");
                int place = Convert.ToInt32(Console.ReadLine());

                Friend friend = new Friend(name, motherName, phone, (FriendPlaces)place);

                _friendDAO.AddFriend(friend);
                System.Console.WriteLine("Amigo cadastrado com sucesso!");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllAddFriends()
        {
            List<Friend> friendList = new List<Friend>();
            friendList = _friendDAO.SearchAllFriends();
            Console.Clear();

            if (friendList.Count == 0)
            {
                System.Console.WriteLine("Nenhum amigo encontrado!");
                return;
            }

            foreach (Friend friend in friendList)
            {
                System.Console.WriteLine(friend.ToString());
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}
