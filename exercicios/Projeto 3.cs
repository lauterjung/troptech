using System;

namespace MiguelBusarelloLauterjungProjeto3
{
    class Program
    {
        static void Main(string[] args)
        {
            // login
            string correctUser = "Aluno";
            string correctPassword = "123456";
            int loginAttempts = 1;

            while(loginAttempts <= 3)
            {       
                loginAttempts++;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------- LOGIN ---------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Usuário: ");
                string usernameInput = Console.ReadLine();
                Console.Write("Senha: ");
                string passwordInput = Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;

                if(usernameInput == correctUser && passwordInput == correctPassword)
                {
                    break;
                }

                if(usernameInput != correctUser && passwordInput != correctPassword)
                {
                    Console.Write("Usuário e senha incorretos!");
                }
                else if(usernameInput != correctUser)
                {
                    Console.WriteLine("Usuário incorreto!");
                } else
                {
                    Console.Write("Senha incorreta!");
                }
                Console.ReadKey();
            }

            if(loginAttempts >= 3)
            {
                Console.Clear();
                Console.Write("Você excedeu o número de tentativas! O programa será encerrado.");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }
            Console.ForegroundColor = ConsoleColor.White;

            // calculadora
            string menuChoice = "";
            string submenuChoice;
            string operation = "";
            double firstNumber;
            double secondNumber;
            double result;
            bool startSubmenu = false;

            while (true)
            {
                if (menuChoice == "")
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Usuário: {correctUser}");
                    Console.WriteLine("---------- MENU ----------");
                    Console.WriteLine("Escolha o código da operação desejada:");
                    Console.WriteLine("[1] + Soma");
                    Console.WriteLine("[2] - Subtração");
                    Console.WriteLine("[3] x Multiplicação");
                    Console.WriteLine("[4] / Divisão");
                    Console.WriteLine("[5] > Sair");
                    Console.WriteLine("--------------------------");
                    Console.Write("=> ");

                    menuChoice = Console.ReadLine();
                }
                Console.Clear();

                switch (menuChoice)
                {
                    case "1":
                        operation = "+";
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Usuário: {correctUser}");
                        Console.WriteLine($"------- OPERAÇÃO {operation} -------");
                        Console.WriteLine("Digite o primeiro número: ");
                        Console.Write("=> ");
                        firstNumber = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Digite o segundo número: ");
                        Console.Write("=> ");
                        secondNumber = Convert.ToDouble(Console.ReadLine());
                        result = firstNumber + secondNumber;
                        Console.WriteLine($"Resultado: {firstNumber} {operation} {secondNumber} = {result}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        startSubmenu = true;
                        break;

                    case "2":
                        operation = "-";
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Usuário: {correctUser}");
                        Console.WriteLine($"------- OPERAÇÃO {operation} -------");
                        Console.WriteLine("Digite o primeiro número: ");
                        Console.Write("=> ");
                        firstNumber = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Digite o segundo número: ");
                        Console.Write("=> ");
                        secondNumber = Convert.ToDouble(Console.ReadLine());
                        result = firstNumber - secondNumber;
                        Console.WriteLine($"Resultado: {firstNumber} {operation} {secondNumber} = {result}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        startSubmenu = true;
                        break;

                    case "3":
                        operation = "x";
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Usuário: {correctUser}");
                        Console.WriteLine($"------- OPERAÇÃO {operation} -------");
                        Console.WriteLine("Digite o primeiro número: ");
                        Console.Write("=> ");
                        firstNumber = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Digite o segundo número: ");
                        Console.Write("=> ");
                        secondNumber = Convert.ToDouble(Console.ReadLine());
                        result = firstNumber * secondNumber;
                        Console.WriteLine($"Resultado: {firstNumber} {operation} {secondNumber} = {result}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        startSubmenu = true;
                        break;

                    case "4":
                        operation = "/";
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Usuário: {correctUser}");
                        Console.WriteLine($"------- OPERAÇÃO {operation} -------");
                        Console.WriteLine("Digite o primeiro número: ");
                        Console.Write("=> ");
                        firstNumber = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Digite o segundo número: ");
                        Console.Write("=> ");
                        secondNumber = Convert.ToDouble(Console.ReadLine());
                        result = firstNumber / secondNumber;
                        Console.WriteLine($"Resultado: {firstNumber} {operation} {secondNumber} = {result}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        startSubmenu = true;
                        break;

                    case "5":
                        Console.WriteLine("Obrigado por usar o programa e até a próxima!");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Insira uma opção válida.");
                        Console.ReadKey();
                        menuChoice = "";
                        break;
                }

                while (startSubmenu == true)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Usuário: {correctUser}");
                    Console.WriteLine($"------- OPERAÇÃO {operation} -------");
                    Console.WriteLine("Escolha uma das opções abaixo:");
                    Console.WriteLine("[1] Refazer operação");
                    Console.WriteLine("[2] Voltar ao menu principal");
                    Console.WriteLine("--------------------------");
                    submenuChoice = Console.ReadLine();
                    Console.WriteLine(submenuChoice);

                    if (submenuChoice == "1")
                    {
                        startSubmenu = false;
                        break;
                    }
                    else if (submenuChoice == "2")
                    {
                        menuChoice = "";
                        startSubmenu = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insira uma opção válida.");
                        Console.ReadKey();
                    }
                }

            }
            
        }
    }
}

