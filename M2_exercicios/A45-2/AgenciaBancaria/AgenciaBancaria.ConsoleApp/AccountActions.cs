using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Domain.Enums;
using AgenciaBancaria.Infra.Data;

namespace AgenciaBancaria.ConsoleApp
{
    public static class AccountActions
    {
        private static string _userInput;
        private static AccountRepository _accountRepository = new AccountRepository();
        private static ClientRepository _clientRepository = new ClientRepository();

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
                Client owner = _clientRepository.SearchClientById(ownerCpf);

                System.Console.Write("Digite o número da conta: ");
                int accountNumber = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o dígito: ");
                int digit = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite a agência: ");
                int branch = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o tipo da conta: ");
                AccountTypes type = StringToAccountTypes(Console.ReadLine());
                System.Console.Write("Digite o saldo (R$): ");
                double balance = Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Digite o limite (R$) (pode ser vazio): ");
                string limitString = Console.ReadLine();
                double? limit = String.IsNullOrEmpty(limitString) ? null : Convert.ToDouble(limitString);
                System.Console.Write("Digite a cesta (pode ser vazia): ");
                string businessBasketString = Console.ReadLine();
                BusinessBaskets? businessBasket = String.IsNullOrEmpty(businessBasketString) ? null : StringToBusinessBaskets(businessBasketString);
                DateTime openingDate = DateTime.Now;

                Account newAccount = new Account(accountNumber, digit, branch, type, balance, limit, openingDate, businessBasket, owner);

                _accountRepository.AddAccount(newAccount);
                System.Console.WriteLine("Conta cadastrada com sucesso!");
            }
            catch (ClientNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (ExistingAccount ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InexistingBusinessBasket ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InexistingAccountType ex)
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
                System.Console.Write("Digite o CPF do cliente: ");
                string cpf = Console.ReadLine();

                List<Account> accountList = _accountRepository.SearchAccountsByClientId(cpf);
                Console.Clear();

                foreach (Account account in accountList)
                {
                    System.Console.WriteLine(account.ToString());
                }
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

        public static AccountTypes StringToAccountTypes(string accountTypeStr)
        {
            AccountTypes accountType;

            int n;
            bool isNumeric = int.TryParse(accountTypeStr, out n);
            if (isNumeric == true && !Enum.IsDefined(typeof(AccountTypes), n))
            {
                throw new InexistingAccountType();
            }

            if (Enum.TryParse(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(accountTypeStr.ToLower()), out accountType))
            {
                return accountType;
            }

            throw new InexistingAccountType();
        }

        public static BusinessBaskets? StringToBusinessBaskets(string businessBasketStr)
        {
            BusinessBaskets businessBasket;

            int n;
            bool isNumeric = int.TryParse(businessBasketStr, out n);
            if (isNumeric == true && !Enum.IsDefined(typeof(BusinessBaskets), n))
            {
                throw new InexistingBusinessBasket();
            }

            if (Enum.TryParse(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(businessBasketStr.ToLower()), out businessBasket))
            {
                return businessBasket;
            }

            throw new InexistingBusinessBasket();
        }

        public static void Run()
        {
            Menu();
        }
    }
}
