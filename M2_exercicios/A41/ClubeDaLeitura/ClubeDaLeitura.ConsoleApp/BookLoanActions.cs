using System;
using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Infra.Data;

namespace ClubeDaLeitura
{
    public static class BookLoanActions
    {
        private static string _userInput;
        private static BookLoanDAO _bookLoanDAO = new BookLoanDAO();
        private static FriendDAO _friendDAO = new FriendDAO();
        private static ComicBookDAO _comicBookDAO = new ComicBookDAO();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("======== EMPRÉSTIMOS =======");
            Console.WriteLine("[1] Cadastrar Emprestimo");
            Console.WriteLine("[2] Buscar todas as Emprestimos");
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
                    AddBookLoan();
                    break;
                case "2":
                    SearchAllAddBookLoans();
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

        public static void AddBookLoan()
        {
            // try
            // {
                System.Console.Write("Digite o ID do amigo: ");
                string friendId = Console.ReadLine();
                Friend friend = _friendDAO.SearchFriendById(friendId);

                if (friend.FriendId == 0)
                {
                    System.Console.WriteLine("Amigo não encontrado! Use o menu de amigos para cadastrá-lo...");
                    return;
                }

                System.Console.Write("Digite o ID da revista: ");
                string comicBookId = Console.ReadLine();
                ComicBook comicBook = _comicBookDAO.SearchComicBookById(comicBookId); ;

                if (comicBook.ComicBookId == 0)
                {
                    System.Console.WriteLine("Revista não encontrada!");
                    Console.ReadLine();
                    return;
                }

                System.Console.Write("Digite o preço: ");
                double price = Convert.ToDouble(Console.ReadLine());

                BookLoan bookLoan = new BookLoan(friend, comicBook, price);
                _bookLoanDAO.AddBookLoan(bookLoan);
                System.Console.WriteLine("Empréstimo cadastrado com sucesso!");
            }
            // catch (NegativePrice ex)
            // {
            //     System.Console.WriteLine(ex.Message);
            // }
            // catch (Exception)
            // {
            //     System.Console.WriteLine("Input inválido!");
            // }
        // }

        public static void SearchAllAddBookLoans()
        {
            List<BookLoan> bookLoanList = new List<BookLoan>();
            bookLoanList = _bookLoanDAO.SearchAllBookLoans();
            Console.Clear();

            if (bookLoanList.Count == 0)
            {
                System.Console.WriteLine("Nenhum empréstimo encontrada!");
                return;
            }

            foreach (BookLoan bookLoan in bookLoanList)
            {
                System.Console.WriteLine(bookLoan.ToString());
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}
