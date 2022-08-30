using System;
using System.Collections.Generic;
using ContaDeLuz.Domain;
using ContaDeLuz.Domain.Exceptions;
using ContaDeLuz.Infra.Data;

namespace ContaDeLuz.ConsoleApp
{
    public static class ElectricBillActions
    {
        private static string _userInput;
        private static ElectricBillRepository _electricBillRepository = new ElectricBillRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("======= CONTA DE LUZ =======");
            Console.WriteLine("[1] Cadastrar Conta de Luz");
            Console.WriteLine("[2] Editar Conta de Luz");
            Console.WriteLine("[3] Deletar Conta de Luz");
            Console.WriteLine("[4] Buscar todas as Contas de Luz");
            Console.WriteLine("[5] Buscar Conta de Luz por identificador");
            Console.WriteLine("[6] Buscar Conta de Luz por mês e ano");
            Console.WriteLine("[7] Pagar Conta de Luz");
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
                    AddElectricBill();
                    break;
                case "2":
                    UpdateElectricBill();
                    break;
                case "3":
                    DeleteElectricBill();
                    break;
                case "4":
                    SearchAllElectricBills();
                    break;
                case "5":
                    SearchElectricBillsById();
                    break;
                case "6":
                    SearchElectricBillByUniqueDate();
                    break;
                case "7":
                    PayElectricBill();
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();

            Menu();
        }

        public static void AddElectricBill()
        {
            try
            {
                System.Console.Write("Digite o número da leitura: ");
                float readingNumber = Convert.ToInt64(Console.ReadLine());
                System.Console.Write("Digite a data da leitura (AAAA-MM-DD): ");
                DateTime readingDate = Convert.ToDateTime(Console.ReadLine());
                // System.Console.Write("Digite a data de validade (AAAA-MM-DD): ");
                // DateTime? paymentDate = Convert.ToDateTime(Console.ReadLine());
                System.Console.Write("Digite o consumo (kW): ");
                double consumedKw = Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Digite o valor da conta (R$): ");
                double billValue = Convert.ToDouble(Console.ReadLine());
                System.Console.Write("Digite o consumo médio (kW): ");
                double averageConsumption = Convert.ToDouble(Console.ReadLine());

                ElectricBill electricBill = new ElectricBill(readingNumber, readingDate, null, consumedKw, billValue, averageConsumption);

                _electricBillRepository.AddElectricBill(electricBill);
                System.Console.WriteLine("Conta de Luz cadastrada com sucesso!");
            }
            catch (ExistingElectricBill ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void UpdateElectricBill()
        {
            try
            {
                System.Console.Write("Digite o ano da conta a ser atualizada: ");
                int year = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o mês da conta a ser atualizada: ");
                int month = Convert.ToInt32(Console.ReadLine());

                ElectricBill electricBill = _electricBillRepository.SearchElectricBillByUniqueDate(year, month);

                System.Console.WriteLine(electricBill.ToString());

                if (ConfirmAction())
                {
                    System.Console.Write("Digite a data da leitura (AAAA-MM-DD): ");
                    electricBill.ReadingDate = Convert.ToDateTime(Console.ReadLine());
                    System.Console.Write("Digite o consumo (kW): ");
                    electricBill.ConsumedKw = Convert.ToDouble(Console.ReadLine());
                    System.Console.Write("Digite o valor da conta (R$): ");
                    electricBill.BillValue = Convert.ToDouble(Console.ReadLine());
                    System.Console.Write("Digite o consumo médio (kW): ");
                    electricBill.AverageConsumption = Convert.ToDouble(Console.ReadLine());
                    electricBill.PaymentDate = null;

                    _electricBillRepository.UpdateElectricBill(electricBill);
                    System.Console.WriteLine("Conta de Luz alterada com sucesso!");
                }
            }
            catch (ElectricBillNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void DeleteElectricBill()
        {
            try
            {
                System.Console.Write("Qual o número da leitura da Conta de Luz a ser deletada? ");
                float readingNumber = Convert.ToInt64(Console.ReadLine());

                ElectricBill searchedElectricBill = _electricBillRepository.SearchElectricBillByReadingNumber(readingNumber);

                System.Console.WriteLine(searchedElectricBill.ToString());

                if (ConfirmAction())
                {
                    _electricBillRepository.DeleteElectricBill(searchedElectricBill.ReadingNumber);
                    System.Console.WriteLine("Conta de Luz deletada com sucesso!");
                }
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllElectricBills()
        {
            try
            {
                List<ElectricBill> electricBillList = _electricBillRepository.SearchAllElectricBills();
                Console.Clear();

                foreach (ElectricBill electricBill in electricBillList)
                {
                    System.Console.WriteLine(electricBill.ToString());
                }
            }
            catch (ZeroElectricBillsRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static void SearchElectricBillsById()
        {
            try
            {
                System.Console.Write("Qual o número da leitura da Conta de Luz a ser buscada? ");
                float electricBillReadingNumber = Convert.ToInt64(Console.ReadLine());

                ElectricBill electricBill = _electricBillRepository.SearchElectricBillByReadingNumber(electricBillReadingNumber);

                Console.Clear();
                System.Console.WriteLine(electricBill.ToString());
            }
            catch (ElectricBillNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }
        public static void SearchElectricBillByUniqueDate()
        {
            try
            {
                System.Console.Write("Digite o ano: ");
                int year = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o mês: ");
                int month = Convert.ToInt32(Console.ReadLine());

                ElectricBill electricBill = _electricBillRepository.SearchElectricBillByUniqueDate(year, month);

                System.Console.WriteLine(electricBill.ToString());
            }
            catch (ElectricBillNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void PayElectricBill()
        {
            try
            {
                System.Console.Write("Digite o ano da conta a ser paga: ");
                int year = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o mês da conta a ser paga: ");
                int month = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite a data do pagamento (YYYY-MM-DD): ");
                DateTime paymentDate = Convert.ToDateTime(Console.ReadLine());

                ElectricBill electricBill = _electricBillRepository.SearchElectricBillByUniqueDate(year, month);
                _electricBillRepository.PayElectricBill(electricBill, paymentDate);

                System.Console.WriteLine("Conta paga com sucesso!");
            }
            catch (ElectricBillNotFound ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (ElectricBillAlreadyPaid ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }
        public static bool ConfirmAction()
        {
            bool answer = false;
            System.Console.Write("Digite 'S' caso você realmente deseja alterar/deletar esse Conta de Luz ");
            string inputString = Console.ReadLine();
            if (inputString.ToLower() == "s")
            {
                answer = true;
            }
            return answer;
        }

        public static void Run()
        {
            Menu();
        }
    }
}
