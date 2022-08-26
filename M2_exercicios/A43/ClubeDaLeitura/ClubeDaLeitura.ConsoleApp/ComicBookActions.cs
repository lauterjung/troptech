using System;
using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;
using ClubeDaLeitura.Infra.Data;

namespace ClubeDaLeitura
{
    public static class ComicBookActions
    {
        private static string _userInput;
        private static ComicBookRepository _comicBookRepository = new ComicBookRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========= REVISTAS =========");
            Console.WriteLine("[1] Cadastrar Revista");
            Console.WriteLine("[2] Buscar todas as Revistas");
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
                    AddComicBook();
                    break;
                case "2":
                    SearchAllComicBooks();
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

        public static void AddComicBook()
        {
            try
            {
                System.Console.Write("Digite o tipo da coleção: ");
                string collectionType = Console.ReadLine();
                System.Console.Write("Digite o número da edição: ");
                int editionNumber = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o ano: ");
                int comicBookYear = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite a cor da caixa (preta, azul, vermelha, amarela): ");
                BoxColors boxColor = StringToBoxColors(Console.ReadLine());
                
                ComicBook comicBook = new ComicBook(collectionType, editionNumber, comicBookYear, boxColor);

                _comicBookRepository.AddComicBook(comicBook);
                System.Console.WriteLine("Revista cadastrada com sucesso!");
            }
            catch (InexistingColor ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllComicBooks()
        {
            try
            {
                List<ComicBook> comicBookList = _comicBookRepository.SearchAllComicBooks();
                Console.Clear();

                foreach (ComicBook comicBook in comicBookList)
                {
                    System.Console.WriteLine(comicBook.ToString());
                }
            }
            catch (ZeroComicBooksRegistered ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static BoxColors StringToBoxColors(string boxColorStr)
        {
            int n;
            bool isNumeric = int.TryParse(boxColorStr, out n);
            if (isNumeric == true)
            {
                throw new InexistingColor();
            }

            BoxColors boxColorValue;
            if (Enum.TryParse(boxColorStr.ToLower(), out boxColorValue))
            {
                return boxColorValue;
            }
            else
            {
                throw new InexistingColor();
            }
        }
        public static void Run()
        {
            Menu();
        }
    }
}
