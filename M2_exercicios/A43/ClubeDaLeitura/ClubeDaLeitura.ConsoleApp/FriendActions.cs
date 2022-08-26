using System;
using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;
using ClubeDaLeitura.Infra.Data;

namespace ClubeDaLeitura
{
    public static class FriendActions
    {
        private static string _userInput;
        private static FriendRepository _friendRepository = new FriendRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========== AMIGOS ==========");
            Console.WriteLine("[1] Cadastrar Amigo");
            Console.WriteLine("[2] Buscar todas os Amigos");
            Console.WriteLine("[3] Gerar relatório do Amigo");
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
                case "3":
                    GenerateComicBooksReport();
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
                System.Console.Write("O amigo é da escola ou do prédio? ");
                FriendPlaces place = StringToFriendPlaces(Console.ReadLine());

                Friend friend = new Friend(name, motherName, phone, place);
                _friendRepository.AddFriend(friend);

                System.Console.WriteLine("Amigo cadastrado com sucesso!");
            }
            catch (InexistingPlace ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllAddFriends()
        {
            try
            {
                Console.Clear();
                List<Friend> friendList = _friendRepository.SearchAllFriends();

                foreach (Friend friend in friendList)
                {
                    System.Console.WriteLine(friend.ToString());
                }
            }
            catch (ZeroFriendsRegistered ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static void GenerateComicBooksReport()
        {
            try
            {
                System.Console.Write("Digite o nome do amigo: ");
                string friendName = Console.ReadLine();

                List<ComicBook> comicBookList = _friendRepository.GenerateComicBooksReport(friendName);

                foreach (ComicBook comicBook in comicBookList)
                {
                    System.Console.WriteLine(comicBook.ToString());
                }
            }
            catch (ZeroFriendsRegistered ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static FriendPlaces StringToFriendPlaces(string friendPlaceStr)
        {
            int n;
            bool isNumeric = int.TryParse(friendPlaceStr, out n);
            if (isNumeric == true)
            {
                throw new InexistingPlace();
            }

            string titleCaseStr = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(friendPlaceStr.ToLower());

            FriendPlaces placesValue;
            if (Enum.TryParse(titleCaseStr, out placesValue))
            {
                return placesValue;
            }
            else
            {
                throw new InexistingPlace();
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}
