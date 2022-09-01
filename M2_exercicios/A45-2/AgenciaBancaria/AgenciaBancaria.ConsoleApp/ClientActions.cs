using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Infra.Data;

namespace AgenciaBancaria.ConsoleApp
{
    public static class ClientActions
    {
        private static string _userInput;
        private static ClientRepository _clientRepository = new ClientRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========= CLIENTES =========");
            Console.WriteLine("[1] Pesquisar todos os Clientes");
            Console.WriteLine("[2] Pesquisar o Cliente por CPF");
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
                    SearchAllClients();
                    break;
                case "2":
                    SearchClientById();
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

        public static void SearchAllClients()
        {
            try
            {
                List<Client> clientList = new List<Client>();
                clientList = _clientRepository.SearchAllClients();
                Console.Clear();

                foreach (Client client in clientList)
                {
                    System.Console.WriteLine(client.ToString());
                }
            }
            catch (ZeroClientsRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static void SearchClientById()
        {
            try
            {
                System.Console.Write("Digite o CPF do cliente ");
                string cpf = Console.ReadLine();

                Client searchedClient = _clientRepository.SearchClientById(cpf);
                Console.Clear();

                System.Console.WriteLine(searchedClient.ToString());
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

        public static void Run()
        {
            Menu();
        }
    }
}
