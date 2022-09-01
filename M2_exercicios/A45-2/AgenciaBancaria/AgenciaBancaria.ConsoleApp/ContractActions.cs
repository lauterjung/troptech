using System;
using System.Collections.Generic;
using AgenciaBancaria.Domain;
using AgenciaBancaria.Domain.Enums;
using AgenciaBancaria.Domain.Exceptions;
using AgenciaBancaria.Infra.Data;

namespace AgenciaBancaria.ConsoleApp
{
    public static class ContractActions
    {
        private static string _userInput;
        private static ContractRepository _contractRepository = new ContractRepository();
        private static ClientRepository _clientRepository = new ClientRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("========= CONTRATOS =========");
            Console.WriteLine("[1] Adicionar Contrato");
            Console.WriteLine("[2] Pesquisar todos os Contratos");
            Console.WriteLine("[3] Pesquisar Contrato por CPF");
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
                    AddContract();
                    break;
                case "2":
                    SearchAllContracts();
                    break;
                case "3":
                    SearchContractsByClientId();
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

        public static void AddContract()
        {
            try
            {
                System.Console.Write("Digite o CPF do dono: ");
                string ownerCpf = Console.ReadLine();
                Client contractOwner = _clientRepository.SearchClientById(ownerCpf);

                System.Console.Write("Digite o número da Contrato: ");
                int contractNumber = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o tipo do contrato: ");
                ContractTypes contractType = StringToContractTypes(Console.ReadLine());
                System.Console.Write("Digite o valor total (R$): ");
                double totalValue = Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Digite o número de parcelas: ");
                int numberOfInstallments = Convert.ToInt32(Console.ReadLine());

                DateTime startDate = DateTime.Now;

                Contract newContract = new Contract(contractNumber, contractType, totalValue, numberOfInstallments, startDate, contractOwner);

                _contractRepository.AddContract(newContract);
                System.Console.WriteLine("Contrato cadastrada com sucesso!");
            }
            catch (ClientNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (ExistingContract ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (InexistingContractType ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllContracts()
        {
            try
            {
                List<Contract> contractList = new List<Contract>();
                contractList = _contractRepository.SearchAllContracts();
                Console.Clear();

                foreach (Contract contract in contractList)
                {
                    System.Console.WriteLine(contract.ToString());
                }
            }
            catch (ZeroContractsRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static void SearchContractsByClientId()
        {
            try
            {
                System.Console.Write("Digite o CPF do cliente: ");
                string cpf = Console.ReadLine();

                List<Contract> contractList = _contractRepository.SearchContractsByClientId(cpf);
                Console.Clear();

                foreach (Contract contract in contractList)
                {
                    System.Console.WriteLine(contract.ToString());
                }
            }
            catch (ContractNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static ContractTypes StringToContractTypes(string contractTypeStr)
        {
            int n;
            bool isNumeric = int.TryParse(contractTypeStr, out n);
            if (isNumeric == true)
            {
                throw new InexistingContractType();
            }

            ContractTypes contractType;
            if (Enum.TryParse(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(contractTypeStr.ToLower()), out contractType))
            {
                return contractType;
            }
            else
            {
                throw new InexistingContractType();
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}