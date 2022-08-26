using System;
using System.Collections.Generic;
using ClubeDaLeitura.Domain;
using ClubeDaLeitura.Domain.Exceptions;
using ClubeDaLeitura.Infra.Data;

namespace ClubeDaLeitura
{
    public static class BookLoanActions
    {
        private static string _userInput;
        private static BookLoanRepository _bookLoanRepository = new BookLoanRepository();

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
            try
            {
                System.Console.Write("Digite o nome do amigo: ");
                string friendName = Console.ReadLine();

                System.Console.Write("Digite o tipo de coleção da revista: ");
                string comicBookCollectionType = Console.ReadLine();
                System.Console.Write("Digite o ano da revista: ");
                string comicBookYear = Console.ReadLine();
                System.Console.Write("Digite a edição da revista: ");
                string comicBookEditionNumber = Console.ReadLine();

                _bookLoanRepository.AddBookLoan(friendName, comicBookCollectionType, comicBookYear, comicBookEditionNumber);
                System.Console.WriteLine("Empréstimo cadastrado com sucesso!");
            }
            catch (FriendNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (ComicBookNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllAddBookLoans()
        {
            try
            {
                Console.Clear();
                List<BookLoan> bookLoanList = _bookLoanRepository.SearchAllBookLoans();

                foreach (BookLoan bookLoan in bookLoanList)
                {
                    System.Console.WriteLine(bookLoan.ToString());
                }
            }
            catch (ZeroBookLoansRegistered ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}
