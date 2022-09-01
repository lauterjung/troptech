using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Infra.Data;

namespace AgenciaBancaria.ConsoleApp
{
    public static class AccountActions
    {
        private static string _userInput;
        private static AccountRepository _accountRepository = new AccountRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========== CONTAS ===========");
            Console.WriteLine("[1] Adicionar Conta");
            Console.WriteLine("[2] Pesquisar todas as Contas");
            Console.WriteLine("[3] Pesquisar Conta por CPF");
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
                    AddAccount();
                    break;
                case "2":
                    SearchAllAccounts();
                    break;
                case "3":
                    SearchAccountsByClientId();
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

        public static void AddAccount()
        {
            try
            {
                System.Console.Write("Digite o CPF do dono: ");
                string ownerCpf = Console.ReadLine();
                _accountRepository.TryExistingClient(ownerCpf);

                System.Console.Write("Digite o número da conta: ");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o dígito: ");
                int digit = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite a agência: ");
                int branch = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o tipo da conta: ");
                string type = Console.ReadLine();
                System.Console.Write("Digite o saldo (R$): ");
                double balance = Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Digite o limite (R$) (pode ser vazio): ");
                string limitString = Console.ReadLine();
                double? limit = String.IsNullOrEmpty(limitString) ? null : Convert.ToDouble(limitString);
                System.Console.Write("Digite a cesta (pode ser vazia): ");
                string businessBasketString = Console.ReadLine();
                int? businessBasket = String.IsNullOrEmpty(businessBasketString) ? null : Convert.ToInt32(businessBasketString);
                DateTime openingDate = DateTime.Now;

                Account newAccount = new Account(accountNumber, digit, branch, type, balance, limit, openingDate, businessBasket, ownerCpf);

                _accountRepository.AddAccount(newAccount);
                System.Console.WriteLine("Conta cadastrada com sucesso!");
            }
            catch (ClientNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllAccounts()
        {
            try
            {
                List<Account> accountList = new List<Account>();
                accountList = _accountRepository.SearchAllAccounts();
                Console.Clear();

                foreach (Account account in accountList)
                {
                    System.Console.WriteLine(account.ToString());
                }
            }
            catch (ZeroAccountsRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static void SearchAccountsByClientId()
        {
            try
            {
                System.Console.Write("Digite o CPF do cliente ");
                string cpf = Console.ReadLine();

                Account searchedAccount = _accountRepository.SearchAccountByClientId(cpf);
                Console.Clear();

                System.Console.WriteLine(searchedAccount.ToString());
            }
            catch (AccountNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        // public static bool ConfirmAction()
        // {
        //     bool answer = false;
        //     System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse produto ");
        //     string inputString = Console.ReadLine();
        //     if (inputString.ToLower() == "s")
        //     {
        //         answer = true;
        //     }
        //     return answer;
        // }

        public static void Run()
        {
            Menu();
        }
    }
}
