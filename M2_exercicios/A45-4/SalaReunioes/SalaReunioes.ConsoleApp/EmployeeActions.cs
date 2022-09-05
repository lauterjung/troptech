using System;
using System.Collections.Generic;
using SalaReunioes.Domain;
using SalaReunioes.Domain.Exceptions;
using SalaReunioes.Infra.Data;

namespace SalaReunioes.ConsoleApp
{
    public static class EmployeeActions
    {
        private static string _userInput;
        private static EmployeeRepository _employeeRepository = new EmployeeRepository();

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("======= FUNCIONÁRIOS =======");
            Console.WriteLine("[1] Adicionar Funcionário");
            Console.WriteLine("[2] Pesquisar todos os Funcionários");
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
                    AddEmployee();
                    break;
                case "2":
                    SearchAllEmployees();
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

        public static void AddEmployee()
        {
            try
            {
                System.Console.Write("Digite o nome do funcionário: ");
                string name = Console.ReadLine();
                System.Console.Write("Digite o cargo do funcionário: ");
                string job = Console.ReadLine();
                System.Console.Write("Digite o ramal do funcionário: ");
                string phone = Console.ReadLine();

                Employee employee = new Employee(name, job, phone);

                _employeeRepository.AddEmployee(employee);
                string newId = _employeeRepository.GetLastId().ToString();

                Console.Clear();
                System.Console.WriteLine("Funcionário cadastrado com sucesso!");
                System.Console.WriteLine($"Seu ID é: {newId}");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Input inválido!");
            }
        }

        public static void SearchAllEmployees()
        {
            try
            {
                List<Employee> employeeList = new List<Employee>();
                employeeList = _employeeRepository.SearchAllEmployees();
                Console.Clear();

                foreach (Employee employee in employeeList)
                {
                    System.Console.WriteLine(employee.ToString());
                }
            }
            catch (ZeroEmployeesRegistered ex)
            {
                System.Console.WriteLine(ex.Message); ;
            }
        }

        public static void Run()
        {
            Menu();
        }
    }
}
